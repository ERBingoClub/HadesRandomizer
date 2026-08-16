using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Hades.Config;

namespace Hades.Services;

public class ModeService
{
    public void UpdateFolder(string targetPath, string? sourcePath)
    {
        if (sourcePath != null && Path.GetFullPath(sourcePath) == Path.GetFullPath(targetPath))
        {
            return;
        }

        Directory.CreateDirectory(targetPath);

        // clear target
        foreach (var file in Directory.GetFiles(targetPath))
        {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
        }

        foreach (var dir in Directory.GetDirectories(targetPath))
        {
            Directory.Delete(dir, true);
        }

        // populate if source exists
        if (sourcePath == null || !Directory.Exists(sourcePath))
            return;

        foreach (var dir in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
        {
            Directory.CreateDirectory(dir.Replace(sourcePath, targetPath));
        }

        foreach (var file in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
        {
            string dest = file.Replace(sourcePath, targetPath);

            Directory.CreateDirectory(Path.GetDirectoryName(dest)!);

            File.Copy(file, dest, true);
        }
    }
}
