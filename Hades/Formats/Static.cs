using System.Security.Cryptography;
using System.Text;
using Hades.Commands;
using Hades.ViewModels;

namespace Hades.Formats;

public static class FormatRegistry
{
    public static IReadOnlyList<FormatEntry> AvailableFormats { get; } = BuildEntries();

    private static IReadOnlyList<FormatEntry> BuildEntries()
    {
        var sote3 = new ShowdownOfTheErdtree3();
        var sote3Vm = new ShowdownOfTheErdtree3ViewModel { Title = sote3.DisplayName };

        sote3Vm.RandomizeCommand = new RelayCommand(() =>
        {
            sote3.Exec(
                baseSeed: sote3Vm.Seed,
                statusCallback: status => sote3Vm.StatusText = status,
                seedCallback: seed => sote3Vm.Seed = seed
            );
        });
        sote3Vm.LaunchCommand = new RelayCommand(() =>
        {
            sote3.Launch();
        });

        return new FormatEntry[] { new FormatEntry(sote3, sote3Vm) };
    }
}
