using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hades.Utilities;

internal class DebugTimer : IDisposable
{
    private Stopwatch? timer;
    private string Name = "";

    public DebugTimer(string? name = null)
    {
#if DEBUG
        if (name != null)
        {
            Name = " " + name;
        }
        timer = Stopwatch.StartNew();
#endif
    }

    public void Dispose()
    {
        if (timer != null)
        {
            timer.Stop();
            Debug.WriteLine($"Time taken to run{Name}: {timer.Elapsed}");
        }
    }
}
