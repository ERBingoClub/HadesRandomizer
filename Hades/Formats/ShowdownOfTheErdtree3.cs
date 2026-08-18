using System.IO;
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
    private static readonly int[] TalismanIds =
    [
        1700147,
        1700145,
        1700142,
        1700133,
        1700121,
        1700116,
        1700114,
        1700111,
        1700108,
        1700106,
        1700105,
        1700104,
        1700103,
        1700102,
        1700095,
        1700093,
    ];

    public void Exec(int baseSeed, Action<string>? statusCallback = null)
    {
        statusCallback?.Invoke($"seeding...: {baseSeed}");

        var rng = new Random(baseSeed);
        var talismans = TalismanIds.ToList();
        var regulationFilepath = Path.Combine(
            Constants.ModEngineWorkingDirectory,
            Id,
            "bingo",
            "regulation.bin"
        );
        var editor = ParamsEditor.ReadFromRegulationPath(regulationFilepath);

        for (int i = talismans.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (talismans[i], talismans[j]) = (talismans[j], talismans[i]);
        }

        var selectedTalismans = talismans.Take(2).ToList();
        var notSelectedTalismans = talismans.Skip(2).ToList();

        // Enabling
        for (int i = 0; i < selectedTalismans.Count; i++)
        {
            editor.SetShopLineupEventFlagForRelease(selectedTalismans[i], 0);
        }
        // Disabling
        for (int i = 0; i < notSelectedTalismans.Count; i++)
        {
            editor.SetShopLineupEventFlagForRelease(notSelectedTalismans[i], 1);
        }

        editor.WriteToRegulationPath(regulationFilepath);

        statusCallback?.Invoke("successfully randomized!");
    }

    public void Launch()
    {
        _launcherService.LaunchEldenRingFromMe3File(Me3File);
    }
}
