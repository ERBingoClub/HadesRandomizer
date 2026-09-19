using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using EldenRingParamsEditor;
using Hades.Constants;
using Hades.Services;

namespace Hades.Formats;

class TwoWorldsCollide : IRandomizerFormat
{
    public string Id => "twc";
    public string DisplayName => "Two Worlds Collide";
    public string Me3File => "twc.me3";
    private EldenRingLauncherService _launcherService = new EldenRingLauncherService();

    public void Exec(
        string baseSeed,
        Action<string>? statusCallback = null,
        Action<string>? seedCallback = null
    )
    {
        try
        {
            if (baseSeed == "")
            {
                var seed = Utils.RandoUtils.GenerateRandomString();
                seedCallback?.Invoke(seed);
                baseSeed = seed;
            }

            statusCallback?.Invoke($"seeding...: {baseSeed}");

            // Formatting seed
            baseSeed = $"sote3_{baseSeed}_{Utils.RandoUtils.GetVersion()}";

            var regulationFilepath = Path.Combine(
                GlobalConstants.ModEngineWorkingDirectory,
                Id,
                "bingo",
                "regulation.bin"
            );
            if (!File.Exists(regulationFilepath))
            {
                var msg = $"regulation.bin not found at {Path.GetFullPath(regulationFilepath)}";
                statusCallback?.Invoke(msg);
                System.Windows.MessageBox.Show(
                    msg,
                    "TWC Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error
                );
                return;
            }

            var editor = ParamsEditor.ReadFromRegulationPath(regulationFilepath);

            // Randomization Logic
            var swTotal = System.Diagnostics.Stopwatch.StartNew();

            var urr = new UniversalReplacementRandomizer.OptimizedReplacementRandomizer(
                "twc",
                Utils.RandoUtils.GetStableSeed(baseSeed)
            );

            // Weapons
            var allNormalWeapons = Weapons.GuaranteedWeapons.Concat(Weapons.ChanceWeapons).ToList();

            var weaponCategories = allNormalWeapons
                .GroupBy(w => w.Category)
                .OrderBy(g => g.Key.ToString())
                .ToList();
            foreach (var group in weaponCategories)
            {
                var category = group.Key;
                var weaponsInCategory = group.ToList();
                var sw = System.Diagnostics.Stopwatch.StartNew();

                WeaponRandomizerService.RandomizeWeaponWorldGroup(
                    editor,
                    urr,
                    $"weapon_category_{category}",
                    weaponsInCategory,
                    weaponsInCategory
                );
                sw.Stop();
            }

            // Remembrance Weapons
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                ShopRandomizerService.RandomizeRemembranceWeaponShops(
                    editor,
                    urr,
                    "shop_remembrance_weapons"
                );
                sw.Stop();
            }

            // Spells
            var worldSpells = Spells.WorldSpells;
            var remSpells = Spells.RemembranceSpells;
            var spellGroups = worldSpells
                .GroupBy(s => s.Type)
                .OrderBy(g => g.Key.ToString())
                .ToList();
            foreach (var group in spellGroups)
            {
                var spellType = group.Key;
                var spellsInType = group.ToList();
                var sw = System.Diagnostics.Stopwatch.StartNew();

                SpellRandomizerService.RandomizeSpellWorldGroup(
                    editor,
                    urr,
                    $"spell_type_{spellType}",
                    spellsInType,
                    spellsInType
                );
                sw.Stop();
            }

            // Weapons in Shop
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                ShopRandomizerService.RandomizeWeaponShopsByCategory(
                    editor,
                    urr,
                    "shop_weapon_category_",
                    includeRemembranceInPool: false
                );
                sw.Stop();
            }
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                ShopRandomizerService.RandomizeSpellShopsByCategory(editor, urr);
                sw.Stop();
            }
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                ShopRandomizerService.RandomizeRemembranceSpellShops(editor, urr);
                sw.Stop();
            }

            // Class Armor
            var classResult = ArmorRandomizerService.GetRandomArmoredClasses(
                baseSeed,
                ArmorLocation.Both
            );
            randomizeClasses(editor, classResult);

            // Starting Stats
            StartingClassService.RandomizeStats(editor, baseSeed + "_statrando", StatRandomizer);

            // Class Weapons + deficit description (WeaponName (-X) with 2H Str buff)
            StartingClassService.RandomizeAllStartingWeaponsWithDescriptions(
                editor,
                baseSeed + "_classweapons"
            );

            // Twin Maiden Shop
            RandomizeTwinMaidenShop(editor, baseSeed + "_twinmaiden");

            editor.WriteToRegulationPath(regulationFilepath);

            statusCallback?.Invoke("successfully randomized!");
        }
        catch (Exception ex)
        {
            try
            {
                File.AppendAllText("Hades.crash.log", $"[{DateTime.Now}] TWC Exec crash: {ex}\n");
            }
            catch { }
            statusCallback?.Invoke($"crashed: {ex.Message}");
            System.Windows.MessageBox.Show(
                $"TWC randomization crashed:\n{ex.Message}\n\nCheck Hades.crash.log for details.\n\n{ex}",
                "Hades Crash",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Error
            );
        }
    }

    public void Launch()
    {
        _launcherService.LaunchEldenRingFromMe3File(Me3File);
    }

    public void RandomizeTwinMaidenShop(ParamsEditor editor, string seed)
    {
        // Talismans
        {
            var talis = TWCConstants.TalismanPool;

            for (int i = 0; i < 4; i++)
            {
                var shopID = TWCConstants.ShopLineupMap[$"talisman_{i + 1}"];

                var ind = Utils.RandoUtils.GetRandomNumber(
                    seed + $"_talisman_{i + 1}",
                    talis.Count()
                );

                editor.SetShopLineupEquipId(shopID, talis[ind]);
                talis.RemoveAt(ind);
            }
        }

        //  Physick Tear
        {
            var tears = TWCConstants.PhysickTearPool;

            for (int i = 0; i < 4; i++)
            {
                var shopID = TWCConstants.ShopLineupMap[$"physick_{i + 1}"];

                var ind = Utils.RandoUtils.GetRandomNumber(
                    seed + $"_physick_{i + 1}",
                    tears.Count()
                );

                editor.SetShopLineupEquipId(shopID, tears[ind]);
                tears.RemoveAt(ind);
            }
        }
    }

    public int StatRandomizer(string seed)
    {
        var isExtreme = Utils.RandoUtils.GetRandomNumber(seed + "_extremity", 10) >= 7;
        if (isExtreme)
        {
            // stat to be between [8,10] U [21,23]
            var stat = Utils.RandoUtils.GetRandomNumber(seed + "_stat", 6);
            if (stat < 3)
            {
                return 8 + stat;
            }
            else
            {
                return 21 + stat - 3;
            }
        }
        else
        {
            // Higher weight to a stat between [11,20]
            return Utils.RandoUtils.GetRandomNumber(seed + "_stat", 10) + 11;
        }
    }

    private void randomizeClasses(ParamsEditor editor, ClassArmorResults results)
    {
        randomizeClass(editor, GlobalConstants.CharaInitClassMap["Vagabond"], results.Vagabond);
        randomizeClass(editor, GlobalConstants.CharaInitClassMap["Warrior"], results.Warrior);
        randomizeClass(editor, GlobalConstants.CharaInitClassMap["Hero"], results.Hero);
        randomizeClass(editor, GlobalConstants.CharaInitClassMap["Astrologer"], results.Astrologer);
        randomizeClass(editor, GlobalConstants.CharaInitClassMap["Prophet"], results.Prophet);
        randomizeClass(editor, GlobalConstants.CharaInitClassMap["Confessor"], results.Confessor);
        randomizeClass(editor, GlobalConstants.CharaInitClassMap["Bandit"], results.Bandit);
        randomizeClass(editor, GlobalConstants.CharaInitClassMap["Samurai"], results.Samurai);
        randomizeClass(editor, GlobalConstants.CharaInitClassMap["Prisoner"], results.Prisoner);
    }

    private void randomizeClass(ParamsEditor editor, int classId, ArmorResults result)
    {
        editor.SetInitialEquipArm(
            classId,
            Armors.Get(Gauntlets.All, ArmorLocation.Both).ElementAt(result.Arms).Id
        );
        editor.SetInitialEquipHelm(
            classId,
            Armors.Get(Helms.All, ArmorLocation.Both).ElementAt(result.Helm).Id
        );
        editor.SetInitialEquipLeg(
            classId,
            Armors.Get(Greaves.All, ArmorLocation.Both).ElementAt(result.Legs).Id
        );
        editor.SetInitialEquipTorso(
            classId,
            Armors.Get(ChestArmor.All, ArmorLocation.Both).ElementAt(result.Chest).Id
        );
    }
}
