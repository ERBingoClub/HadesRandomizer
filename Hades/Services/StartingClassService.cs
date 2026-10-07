using System.IO;
using System.Linq;
using EldenRingParamsEditor;
using Hades.Constants;
using Hades.Utils;
using UniversalReplacementRandomizer;

namespace Hades.Services;

public static class StartingClassService
{
    private static readonly string[] ClassNames =
    {
        "Vagabond",
        "Warrior",
        "Hero",
        "Bandit",
        "Astrologer",
        "Prophet",
        "Confessor",
        "Samurai",
        "Prisoner",
        "Wretch",
        "Heavy Knight",
        "Idus Knight",
    };

    public static void RandomizeAllStartingWeapons(ParamsEditor editor, string seed)
    {
        foreach (var className in ClassNames)
        {
            RandomizeStartingWeapons(editor, className, seed + "_" + className);
        }
    }

    public static void RandomizeAllStartingWeaponsWithDescriptions(ParamsEditor editor, string seed)
    {
        RandomizeAllStartingWeapons(editor, seed);
        MenuBndEditorService? menuEditor = null;
        var candidates = new[]
        {
            Path.Combine(
                GlobalConstants.ModEngineWorkingDirectory,
                "twc",
                "bingo",
                "msg",
                "engus",
                "menu_dlc02.msgbnd.dcx"
            ),
            Path.Combine(
                GlobalConstants.ModEngineWorkingDirectory,
                "twc",
                "msg",
                "engus",
                "menu_dlc02.msgbnd.dcx"
            ),
            Path.Combine(
                GlobalConstants.ModEngineWorkingDirectory,
                "sote3",
                "bingo",
                "msg",
                "engus",
                "menu_dlc02.msgbnd.dcx"
            ),
        };
        var menuOut = Path.Combine(
            GlobalConstants.ModEngineWorkingDirectory,
            "twc",
            "bingo",
            "msg",
            "engus",
            "menu_dlc02.msgbnd.dcx"
        );
        var altIn = Path.Combine("Resources", "Bnd", "vanilla", "menu_dlc02.msgbnd.dcx");
        string? menuIn = candidates.FirstOrDefault(File.Exists);
        if (menuIn != null)
            menuEditor = MenuBndEditorService.ReadFromMenuBndFilePath(menuIn);
        else if (File.Exists(altIn))
            menuEditor = MenuBndEditorService.ReadFromMenuBndFilePath(altIn);
        else
            return;
        if (menuEditor == null)
            return;
        for (int i = 0; i < ParamsEditor.TotalStartingClasses; i++)
        {
            int charaInitId = ParamsEditor.VagabondCharaInitId + i;
            int[] wepIds =
            {
                editor.GetInitialEquipWepRight(charaInitId, 0),
                editor.GetInitialEquipWepRight2(charaInitId),
                editor.GetInitialEquipWepLeft(charaInitId, 0),
                editor.GetInitialEquipWepLeft2(charaInitId),
            };
            int[] buffed = GetBuffedStats(editor, charaInitId);
            var descs = new System.Collections.Generic.List<string>();
            foreach (int wep in wepIds)
            {
                if (wep == -1)
                    continue;
                var entry = Weapons.AllWeapons.FirstOrDefault(w => w.Id == wep);
                string name = entry.Id != 0 ? entry.Name : $"Wep{wep}";
                descs.Add(GetWeaponDescriptionWithDeficit(editor, wep, name, buffed));
            }
            if (descs.Count == 0)
                continue;
            menuEditor.SetClassDescription(i, string.Join(", ", descs));
        }
        for (int i = 10; i < ParamsEditor.TotalStartingClasses && i < ClassNames.Length; i++)
            menuEditor.SetClassName(i, ClassNames[i]);
        menuEditor.WriteToMenuBndFilePath(menuOut);
    }

    public static void RandomizeStartingWeapons(ParamsEditor editor, string className, string seed)
    {
        int charaInitId = GlobalConstants.CharaInitClassMap[className];

        int wep_right_1 = editor.GetInitialEquipWepRight(charaInitId, 0);
        int wep_right_2 = editor.GetInitialEquipWepRight2(charaInitId);
        int wep_left_1 = editor.GetInitialEquipWepLeft(charaInitId, 0);
        int wep_left_2 = editor.GetInitialEquipWepLeft2(charaInitId);

        editor.SetInitialEquipWepLeft(
            charaInitId,
            0,
            GetRandomStartingWeapon(wep_left_1, seed + "_wep_left_1")
        );
        editor.SetInitialEquipWepLeft(
            charaInitId,
            1,
            GetRandomStartingWeapon(wep_left_2, seed + "_wep_left_2")
        );
        editor.SetInitialEquipWepRight(
            charaInitId,
            0,
            GetRandomStartingWeapon(wep_right_1, seed + "_wep_right_1")
        );
        editor.SetInitialEquipWepRight(
            charaInitId,
            1,
            GetRandomStartingWeapon(wep_right_2, seed + "_wep_right_2")
        );
    }

    public static int[] GetClassStats(ParamsEditor editor, int charaInitId)
    {
        return new[]
        {
            (int)editor.GetInitialVigor(charaInitId),
            (int)editor.GetInitialMind(charaInitId),
            (int)editor.GetInitialEndurance(charaInitId),
            (int)editor.GetInitialStrength(charaInitId),
            (int)editor.GetInitialDexterity(charaInitId),
            (int)editor.GetInitialIntelligence(charaInitId),
            (int)editor.GetInitialFaith(charaInitId),
            (int)editor.GetInitialArcane(charaInitId),
        };
    }

    public static int[] GetBuffedStats(ParamsEditor editor, int charaInitId)
    {
        // Str-first order to match GetWeaponDescriptionWithDeficit (j = 0..4).
        int[] stats =
        {
            (int)editor.GetInitialStrength(charaInitId),
            (int)editor.GetInitialDexterity(charaInitId),
            (int)editor.GetInitialIntelligence(charaInitId),
            (int)editor.GetInitialFaith(charaInitId),
            (int)editor.GetInitialArcane(charaInitId),
        };
        int[] armorIds =
        {
            editor.GetInitialEquipHelm(charaInitId),
            editor.GetInitialEquipTorso(charaInitId),
            editor.GetInitialEquipArm(charaInitId),
            editor.GetInitialEquipLeg(charaInitId),
        };
        foreach (int armorId in armorIds)
        {
            if (armorId <= 0)
                continue;
            int spEffectId;
            try
            {
                spEffectId = editor.GetEquipProtectorResidentSpEffectId(armorId);
            }
            catch
            {
                continue;
            }
            if (spEffectId == -1)
                continue;
            for (int j = 0; j < 5; j++)
            {
                try
                {
                    stats[j] += editor.GetSpEffectAddStat(spEffectId, j + 3);
                }
                catch { }
            }
        }
        return stats;
    }

    public static int GetRandomStartingWeapon(int weaponId, string seed)
    {
        if (weaponId == -1)
        {
            return -1;
        }

        // Staff
        if (WeaponUtils.IsStaff(weaponId))
        {
            return WeaponUtils.StaffIds[
                RandoUtils.GetRandomNumber(seed + "_staff", WeaponUtils.StaffIds.Count())
            ];
        }

        // Seal
        if (WeaponUtils.IsSeal(weaponId))
        {
            return WeaponUtils.SealIds[
                RandoUtils.GetRandomNumber(seed + "_seal", WeaponUtils.SealIds.Count())
            ];
        }

        return Weapons
            .GetAllSmithingWeapons()[
                RandoUtils.GetRandomNumber(seed, Weapons.GetAllSmithingWeapons().Count())
            ]
            .Id;
    }

    public static void RandomizeStats(ParamsEditor editor, string seed, Func<string, int> getStat)
    {
        string[] keys = { "vigor", "mind", "end", "str", "dex", "int", "fai", "arc" };
        const int totalPoints = 120;

        foreach (var className in ClassNames)
        {
            int charaInitId = GlobalConstants.CharaInitClassMap[className];
            var stats = new int[keys.Length];

            for (var attempt = 0; ; attempt++)
            {
                var sum = 0;
                for (var i = 0; i < keys.Length; i++)
                {
                    stats[i] = getStat($"{seed}_{className}_{keys[i]}_{attempt}");
                    sum += stats[i];
                }
                if (sum == totalPoints)
                    break;
            }

            editor.SetInitialVigor(charaInitId, (byte)(stats[0] + 5));
            editor.SetInitialMind(charaInitId, (byte)(stats[1] - 5));
            editor.SetInitialEndurance(charaInitId, (byte)stats[2]);
            editor.SetInitialStrength(charaInitId, (byte)stats[3]);
            editor.SetInitialDexterity(charaInitId, (byte)stats[4]);
            editor.SetInitialIntelligence(charaInitId, (byte)stats[5]);
            editor.SetInitialFaith(charaInitId, (byte)stats[6]);
            editor.SetInitialArcane(charaInitId, (byte)stats[7]);
        }
    }

    private static readonly System.Collections.Generic.HashSet<WeaponCategory> NoTwoHandBonusCategories =
        new() { WeaponCategory.Claw, WeaponCategory.Fist };

    private static bool AppliesTwoHandBonus(int weaponId)
    {
        var entry = Weapons.AllWeapons.FirstOrDefault(w => w.Id == weaponId);
        return entry.Id == 0 || !NoTwoHandBonusCategories.Contains(entry.Category);
    }

    public static string GetWeaponDescriptionWithDeficit(
        ParamsEditor editor,
        int weaponId,
        string weaponName,
        int[] buffedStats
    )
    {
        int deficit = 0;
        for (int j = 0; j < 5; j++)
        {
            int req;
            try
            {
                req = editor.GetEquipWeaponProperStat(weaponId, j);
            }
            catch
            {
                continue;
            }
            if (req == 0)
                continue;
            if (j == 0 && AppliesTwoHandBonus(weaponId))
            {
                int num = req * 2;
                req = num % 3 > 0 ? num / 3 + 1 : num / 3;
            }
            if (req > buffedStats[j])
                deficit += req - buffedStats[j];
        }
        return deficit > 0 ? $"{weaponName} (-{deficit})" : weaponName;
    }
}
