using Hades.Formats;

namespace Hades.ViewModels;

public class MainWindowViewModel
{
    public IReadOnlyList<FormatEntry> AvailableFormats => FormatRegistry.AvailableFormats;

    public FormatEntry? SelectedFormat { get; set; }

    public MainWindowViewModel()
    {
        SelectedFormat = AvailableFormats.FirstOrDefault();
    }
}
