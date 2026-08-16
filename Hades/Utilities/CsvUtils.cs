// SPDX-License-Identifier: GPL-3.0-only
using System.Globalization;
using System.IO;
using CsvHelper;

namespace Hades.Utilities;

public class CsvReaderUtils
{
    public static List<T> Read<T>(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<T>().ToList();
        return records;
    }
}

public static class CsvDirectoryUtils
{
    public static (List<string> csvFiles, List<string> validSubdirectories) GetCsvStructure(
        string rootDir
    )
    {
        if (!Directory.Exists(rootDir))
        {
            throw new DirectoryNotFoundException($"Directory not found: {rootDir}");
        }

        // Top-level CSV files
        List<string> csvFiles = Directory
            .GetFiles(rootDir, "*.csv", SearchOption.TopDirectoryOnly)
            .ToList();

        List<string> validSubdirectories = new();

        foreach (
            string subDir in Directory.GetDirectories(rootDir, "*", SearchOption.TopDirectoryOnly)
        )
        {
            var fileNames = Directory
                .GetFiles(subDir, "*.csv", SearchOption.TopDirectoryOnly)
                .Select(Path.GetFileName)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            if (fileNames.Contains("targets.csv"))
            {
                validSubdirectories.Add(subDir);
            }
        }

        return (csvFiles, validSubdirectories);
    }
}
