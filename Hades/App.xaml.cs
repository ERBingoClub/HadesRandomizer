using System.Configuration;
using System.Data;
using System.Windows;

namespace Hades
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += (s, ex) =>
            {
                try
                {
                    System.IO.File.AppendAllText(
                        "Hades.crash.log",
                        $"[{DateTime.Now}] DispatcherUnhandledException: {ex.Exception}\n"
                    );
                }
                catch { }
                MessageBox.Show(
                    $"Unhandled exception:\n{ex.Exception.Message}\n\nSee Hades.crash.log for details.",
                    "Hades Crash",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                ex.Handled = true;
            };
            AppDomain.CurrentDomain.UnhandledException += (s, ex) =>
            {
                var e2 = ex.ExceptionObject as Exception;
                try
                {
                    System.IO.File.AppendAllText(
                        "Hades.crash.log",
                        $"[{DateTime.Now}] AppDomain: {e2}\n"
                    );
                }
                catch { }
            };
            TaskScheduler.UnobservedTaskException += (s, ex) =>
            {
                try
                {
                    System.IO.File.AppendAllText(
                        "Hades.crash.log",
                        $"[{DateTime.Now}] TaskScheduler: {ex.Exception}\n"
                    );
                }
                catch { }
                ex.SetObserved();
            };
            base.OnStartup(e);
        }
    }
}
