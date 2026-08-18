namespace Hades.Formats;

public class FormatEntry
{
    public IRandomizerFormat Format { get; }
    public object ViewModel { get; }

    public FormatEntry(IRandomizerFormat format, object viewModel)
    {
        Format = format;
        ViewModel = viewModel;
    }
}
