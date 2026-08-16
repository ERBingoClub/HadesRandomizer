// SPDX-License-Identifier: GPL-3.0-only
using System.Diagnostics;
using Hades.Config;

namespace Hades.Services;

public enum LaunchMode
{
    Base,
    BaseDlc,
    DLC,
}

public class EldenRingLauncherService
{
    public void LaunchEldenRing(LaunchMode mode)
    {
        string fileName = mode switch
        {
            LaunchMode.Base => Constants.LaunchEldenRingBase,
            LaunchMode.BaseDlc => Constants.LaunchEldenRingBaseDlc,
            LaunchMode.DLC => Constants.LaunchEldenRingDlc,
            _ => throw new ArgumentOutOfRangeException(),
        };

        //Process.Start(new ProcessStartInfo
        //{
        //    FileName = fileName,
        //    WorkingDirectory = Constants.ModEngineWorkingDirectory,
        //    UseShellExecute = true,
        //    //CreateNoWindow = true
        //});
        Process.Start(
            new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c \"" + fileName + "\"",
                WorkingDirectory = Constants.ModEngineWorkingDirectory,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        );
    }
}
