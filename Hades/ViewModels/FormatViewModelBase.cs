using System.IO;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hades.Formats;

namespace Hades.ViewModels;

public abstract class FormatViewModelBase : ObservableObject
{
    private readonly IRandomizerFormat _format;

    protected FormatViewModelBase(IRandomizerFormat format)
    {
        _format = format;
        Title = format.DisplayName;
        RandomizeCommand = new AsyncRelayCommand(RandomizeAsync);
        LaunchCommand = new RelayCommand(format.Launch, () => !IsBusy);
    }

    public string Title { get; }
    private string _seed = "";
    public string Seed
    {
        get => _seed;
        set => SetProperty(ref _seed, value);
    }

    private string _statusText = "";
    public string StatusText
    {
        get => _statusText;
        set => SetProperty(ref _statusText, value);
    }

    public IAsyncRelayCommand RandomizeCommand { get; }
    public IRelayCommand LaunchCommand { get; }

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        private set
        {
            if (SetProperty(ref _isBusy, value))
                LaunchCommand.NotifyCanExecuteChanged();
        }
    }

    // Override to pass format-specific options to Exec. Return a new object built from the
    // current property values; it is read once per run, on the UI thread, before the format starts.
    protected virtual IRandomizerOptions? Options => null;

    private void HandleException(Exception ex)
    {
        var isRandomizerException = ex is RandomizerException;
        var exceptionToLog = isRandomizerException ? ex.InnerException : ex;
        if (exceptionToLog != null)
        {
            try
            {
                File.AppendAllText("Hades.crash.log", $"[{DateTime.Now}] {_format.Id} crash: {(isRandomizerException ? $"{ex.Message}. " : "")}{exceptionToLog}\n");
            }
            catch { }
        }
        var statusTitle = isRandomizerException ? "Randomization Failed" : "Hades Crashed";
        StatusText = $"{statusTitle}: {ex.Message}{(exceptionToLog != null ? "." : $"\n\nSee {Path.GetFullPath("Hades.crash.log")} for details.")}";
        MessageBox.Show(
            Application.Current.MainWindow,
            $"{StatusText}",
            statusTitle,
            MessageBoxButton.OK,
            isRandomizerException ? MessageBoxImage.Warning : MessageBoxImage.Error
        );
    }

    private async Task RandomizeAsync()
    {
        // Snapshot inputs on the UI thread so edits made while the format runs don't affect it.
        var baseSeed = Seed;
        var options = Options;

        IProgress<string> status = new Progress<string>(text => StatusText = text);
        IProgress<string> seed = new Progress<string>(value => Seed = value);

        IsBusy = true;
        try
        {
            // Run randomization on a background thread to not stall the UI updates being reported from Exec()
            await Task.Run(() => _format.Exec(baseSeed, status.Report, seed.Report, options));
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
