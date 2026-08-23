using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Hades.ViewModels;

public class TwoWorldsCollideViewModel : INotifyPropertyChanged
{
    public string Title { get; set; } = "";
    private string _seed = "";
    public string Seed
    {
        get => _seed;
        set
        {
            _seed = value;
            OnPropertyChanged();
        }
    }
    private string _statusText = "";
    public string StatusText
    {
        get => _statusText;
        set
        {
            _statusText = value;
            OnPropertyChanged();
        }
    }

    public ICommand RandomizeCommand { get; set; } = null!;
    public ICommand LaunchCommand { get; set; } = null!;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
