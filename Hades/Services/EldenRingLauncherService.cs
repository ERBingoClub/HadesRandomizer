// SPDX-License-Identifier: GPL-3.0-only
using System.Diagnostics;
using Hades.Constants;

namespace Hades.Services;

public enum LaunchMode
{
    Base,
    BaseDlc,
    DLC,
}

public class EldenRingLauncherService
{
    public void LaunchEldenRingFromMe3File(string path)
    {
        Process.Start(
            new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c \"\"launch-me3.bat\" \"{path}\"\"",
                WorkingDirectory = GlobalConstants.ModEngineWorkingDirectory,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        );
    }

    // For Debug
    // public void LaunchEldenRingFromMe3File(string path)
    // {
    //     var process = new Process
    //     {
    //         StartInfo = new ProcessStartInfo
    //         {
    //             FileName = "cmd.exe",
    //             Arguments = $"/c \"\"launch-me3.bat\" \"{path}\"\"",
    //             WorkingDirectory = GlobalConstants.ModEngineWorkingDirectory,
    //             UseShellExecute = false,
    //             CreateNoWindow = true,
    //             RedirectStandardOutput = true,
    //             RedirectStandardError = true,
    //         },
    //     };
    //
    //     process.OutputDataReceived += (_, e) =>
    //     {
    //         if (e.Data != null)
    //             Console.WriteLine($"[ME3] {e.Data}");
    //     };
    //
    //     process.ErrorDataReceived += (_, e) =>
    //     {
    //         if (e.Data != null)
    //             Console.Error.WriteLine($"[ME3 ERROR] {e.Data}");
    //     };
    //
    //     process.Start();
    //
    //     process.BeginOutputReadLine();
    //     process.BeginErrorReadLine();
    // }
}
