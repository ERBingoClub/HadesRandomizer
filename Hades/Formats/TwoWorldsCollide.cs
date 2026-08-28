using System.IO;
using System.Security.Cryptography;
using System.Text;
using EldenRingParamsEditor;
using Hades.Config;
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

        // // Shop Talisman
        // var talismanResult = getTalismans(baseSeed);
        // randomizeTalismans(editor, talismanResult);
        //
        // // Shop AoW
        // var aowResult = getRandomAoW(baseSeed);
        // randomizeAoW(editor, aowResult);

        // Classes
        var classResult = ArmorRandomizerService.GetRandomArmoredClasses(baseSeed, ArmorLocation.Both);
        randomizeClasses(editor, classResult);

        editor.WriteToRegulationPath(regulationFilepath);

        statusCallback?.Invoke("successfully randomized!");
    }

    public void Launch()
    {
        _launcherService.LaunchEldenRingFromMe3File(Me3File);
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
