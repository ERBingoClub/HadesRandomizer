using System.IO;
using System.Security.Cryptography;
using System.Text;
using EldenRingParamsEditor;
using Hades.Config;
using Hades.Services;

namespace Hades.Formats;

class ShowdownOfTheErdtree3 : IRandomizerFormat
{
    public string Id => "sote3";
    public string DisplayName => "Showdown Of The Erdtree 3";
    public string Me3File => "sote3.me3";
    private EldenRingLauncherService _launcherService = new EldenRingLauncherService();

    public void Exec(
        string baseSeed,
        Action<string>? statusCallback = null,
        Action<string>? seedCallback = null
    )
    {
        if (baseSeed == "")
        {
            var seed = Utils.GenerateRandomString();
            seedCallback?.Invoke(seed);
            baseSeed = seed;
        }

        statusCallback?.Invoke($"seeding...: {baseSeed}");

        // Formatting seed
        baseSeed = $"sote3_{baseSeed}_{Utils.GetVersion()}";

        var regulationFilepath = Path.Combine(
            Constants.ModEngineWorkingDirectory,
            Id,
            "bingo",
            "regulation.bin"
        );
        var editor = ParamsEditor.ReadFromRegulationPath(regulationFilepath);

        // Randomization Logic

        // Shop Talisman
        var talismanResult = getTalismans(baseSeed);
        randomizeTalismans(editor, talismanResult);

        // Shop AoW
        var aowResult = getRandomAoW(baseSeed);
        randomizeAoW(editor, aowResult);

        // Classes
        var classResult = getRandomArmoredClasses(baseSeed);
        randomizeClasses(editor, classResult);

        editor.WriteToRegulationPath(regulationFilepath);

        statusCallback?.Invoke("successfully randomized!");
    }

    public void Launch()
    {
        _launcherService.LaunchEldenRingFromMe3File(Me3File);
    }

    private int getRandomNumber(string seed, int len)
    {
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(seed));
        var seedInt = BitConverter.ToInt32(hash, 0);
        Random rng = new Random(seedInt);
        return rng.Next(len);
    }

    private AoWResults getRandomAoW(string seed)
    {
        return new AoWResults
        {
            amazingAoW = getRandomNumber(seed + "_amazing", SOTE3Constants.AmazingAoW.Count()),
            goodAoW = getRandomNumber(seed + "_good", SOTE3Constants.GoodAoW.Count()),
            weakAoW = getRandomNumber(seed + "_weak", SOTE3Constants.WeakAoW.Count()),
        };
    }

    private ClassArmorResults getRandomArmoredClasses(string seed)
    {
        return new ClassArmorResults
        {
            Vagabond = getRandomArmor(seed + "_vagabond"),
            Warrior = getRandomArmor(seed + "_warrior"),
            Hero = getRandomArmor(seed + "_hero"),
            Astrologer = getRandomArmor(seed + "_astrologer"),
            Prisoner = getRandomArmor(seed + "_prisoner"),
            Prophet = getRandomArmor(seed + "_prophet"),
            Confessor = getRandomArmor(seed + "_confessor"),
            Samurai = getRandomArmor(seed + "_samurai"),
            Bandit = getRandomArmor(seed + "_bandit"),
        };
    }

    private ArmorResults getRandomArmor(string seed)
    {
        var arm = getRandomNumber(seed + "_arms", Constants.BaseArms.Count());
        var legs = getRandomNumber(seed + "_legs", Constants.BaseLegs.Count());
        var chest = getRandomNumber(seed + "_chest", Constants.BaseChest.Count());
        var helm = getRandomNumber(seed + "_helm", Constants.BaseHelm.Count());

        return new ArmorResults
        {
            Arms = arm,
            Legs = legs,
            Chest = chest,
            Helm = helm,
        };
    }

    private TalismanResults getTalismans(string seed)
    {
        var fillerTali_1 = getRandomNumber(
            seed + "_filler1",
            SOTE3Constants.FillerTalismans.Count()
        );
        var fillerTali_2 = getRandomNumber(
            seed + "_filler2",
            SOTE3Constants.FillerTalismans.Count()
        );
        if (fillerTali_1 == fillerTali_2)
        {
            if (fillerTali_2 == SOTE3Constants.FillerTalismans.Count() - 1)
                fillerTali_2 = 0;
            else
                fillerTali_2++;
        }

        var goodTali_1 = getRandomNumber(seed + "_good1", SOTE3Constants.GoodTalismans.Count());
        var goodTali_2 = getRandomNumber(seed + "_good2", SOTE3Constants.GoodTalismans.Count());
        if (goodTali_1 == goodTali_2)
        {
            if (goodTali_2 == SOTE3Constants.GoodTalismans.Count() - 1)
                goodTali_2 = 0;
            else
                goodTali_2++;
        }

        return new TalismanResults
        {
            fillerTalisman_1 = fillerTali_1,
            fillerTalisman_2 = fillerTali_2,
            goodTalisman_1 = goodTali_1,
            goodTalisman_2 = goodTali_2,
        };
    }

    private void randomizeAoW(ParamsEditor editor, AoWResults aowResults)
    {
        editor.SetShopLineupEquipId(
            SOTE3Constants.shopLineupMap["amazingAoW"],
            SOTE3Constants.AmazingAoW[aowResults.amazingAoW]
        );
        editor.SetShopLineupEquipId(
            SOTE3Constants.shopLineupMap["goodAoW"],
            SOTE3Constants.GoodAoW[aowResults.goodAoW]
        );
        editor.SetShopLineupEquipId(
            SOTE3Constants.shopLineupMap["weakAoW"],
            SOTE3Constants.WeakAoW[aowResults.weakAoW]
        );
    }

    private void randomizeClasses(ParamsEditor editor, ClassArmorResults results)
    {
        randomizeClass(editor, Constants.CharaInitClassMap["Vagabond"], results.Vagabond);
        randomizeClass(editor, Constants.CharaInitClassMap["Warrior"], results.Warrior);
        randomizeClass(editor, Constants.CharaInitClassMap["Hero"], results.Hero);
        randomizeClass(editor, Constants.CharaInitClassMap["Astrologer"], results.Astrologer);
        randomizeClass(editor, Constants.CharaInitClassMap["Prophet"], results.Prophet);
        randomizeClass(editor, Constants.CharaInitClassMap["Confessor"], results.Confessor);
        randomizeClass(editor, Constants.CharaInitClassMap["Bandit"], results.Bandit);
        randomizeClass(editor, Constants.CharaInitClassMap["Samurai"], results.Samurai);
        randomizeClass(editor, Constants.CharaInitClassMap["Prisoner"], results.Prisoner);
    }

    private void randomizeClass(ParamsEditor editor, int classId, ArmorResults result)
    {
        editor.SetInitialEquipArm(classId, Constants.BaseArms[result.Arms]);
        editor.SetInitialEquipHelm(classId, Constants.BaseHelm[result.Helm]);
        editor.SetInitialEquipLeg(classId, Constants.BaseLegs[result.Legs]);
        editor.SetInitialEquipTorso(classId, Constants.BaseChest[result.Chest]);
    }

    private void randomizeTalismans(ParamsEditor editor, TalismanResults results)
    {
        editor.SetShopLineupEquipId(
            SOTE3Constants.shopLineupMap["fillerTalisman_1"],
            SOTE3Constants.FillerTalismans[results.fillerTalisman_1]
        );
        editor.SetShopLineupEquipId(
            SOTE3Constants.shopLineupMap["fillerTalisman_2"],
            SOTE3Constants.FillerTalismans[results.fillerTalisman_2]
        );
        editor.SetShopLineupEquipId(
            SOTE3Constants.shopLineupMap["goodTalisman_1"],
            SOTE3Constants.GoodTalismans[results.goodTalisman_1]
        );
        editor.SetShopLineupEquipId(
            SOTE3Constants.shopLineupMap["goodTalisman_2"],
            SOTE3Constants.GoodTalismans[results.goodTalisman_2]
        );
    }
}
