// SPDX-License-Identifier: GPL-3.0-only
using System.Diagnostics;
using System.IO;
using EldenRingParamsEditor;
using Hades.Models;
using UniversalReplacementRandomizer;

namespace Hades.Utilities;

internal struct ReplacementGroup<T>
    where T : IGameItem
{
    public List<T> Targets { get; }
    public List<T> Replacements { get; }

    public ReplacementGroup(string directoryPath)
    {
        if (!File.Exists(Path.Combine(directoryPath, "targets.csv")))
        {
            throw new FileNotFoundException("targets.csv is required in group directory.");
        }

        Targets = CsvReaderUtils.Read<T>(Path.Combine(directoryPath, "targets.csv"));

        string replacementsPath = Path.Combine(directoryPath, "replacements.csv");
        if (File.Exists(replacementsPath))
        {
            Replacements = CsvReaderUtils.Read<T>(replacementsPath);
        }
        else
        {
            Replacements = new List<T>(Targets); // fallback: self-replacement
        }
    }
}

internal partial class ReplacementUtils
{
    public static void Randomize<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string rootDir,
        Dictionary<int, List<ItemLotEntry>> itemLotMapLocations,
        Dictionary<int, List<ItemLotEntry>> itemLotEnemyLocations,
        Dictionary<int, List<int>> shopLineupLocations
    )
        where T : IGameItem
    {
        (List<string> files, List<string> directories) = CsvDirectoryUtils.GetCsvStructure(rootDir);

        foreach (var file in files)
        {
            RandomizeAndReplaceFile<GameItemModel>(
                editor,
                urr,
                file,
                itemLotMapLocations,
                itemLotEnemyLocations,
                shopLineupLocations
            );
        }

        foreach (var directory in directories)
        {
            RandomizeAndReplaceDir<GameItemModel>(
                editor,
                urr,
                directory,
                itemLotMapLocations,
                itemLotEnemyLocations,
                shopLineupLocations
            );
        }
    }

    public static void RandomizeAndReplaceFile<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupFilePath,
        Dictionary<int, List<ItemLotEntry>> itemLotMapLocations,
        Dictionary<int, List<ItemLotEntry>> itemLotEnemyLocations,
        Dictionary<int, List<int>> shopLineupLocations
    )
        where T : IGameItem
    {
        // The file must exist
        if (!File.Exists(groupFilePath))
        {
            throw new FileNotFoundException($"Could not find file {groupFilePath}");
        }

        // The group key is the directory name + file name
        string fileName = Path.GetFileName(groupFilePath);
        string dirName = Path.GetFileName(Path.GetDirectoryName(groupFilePath) ?? "");
        string groupKey = dirName + "/" + fileName;
#if DEBUG
        Debug.WriteLine($"groupKey: {groupKey}");
#endif

        // Randomize the group
        List<T> group = CsvReaderUtils.Read<T>(groupFilePath);
        OptimizedRandomizationGroup randoGroup = new(group.Count, group.Count);
        urr.AddGroup(groupKey, randoGroup);
        int[] replacementIndexes = urr.RandomizeGroup(groupKey);

        // Now apply replacements
        ApplyReplacements(
            editor,
            replacementIndexes,
            group,
            group,
            itemLotMapLocations,
            itemLotEnemyLocations,
            shopLineupLocations
        );
    }

    public static void RandomizeAndReplaceDir<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupDirectoryPath,
        Dictionary<int, List<ItemLotEntry>> itemLotMapLocations,
        Dictionary<int, List<ItemLotEntry>> itemLotEnemyLocations,
        Dictionary<int, List<int>> shopLineupLocations
    )
        where T : IGameItem
    {
        if (!Directory.Exists(groupDirectoryPath))
        {
            throw new DirectoryNotFoundException(
                $"Could not find group directory: {groupDirectoryPath}"
            );
        }

        string groupName = Path.GetFileName(Path.TrimEndingDirectorySeparator(groupDirectoryPath));
        string dirName = Path.GetFileName(Path.GetDirectoryName(groupDirectoryPath)!);

        //string groupKey = Path.GetFileName(Directory.GetParent(groupName)!.FullName) + "/" + groupName;
        string groupKey = dirName + "/" + groupName;

#if DEBUG
        Debug.WriteLine($"groupKey: {groupKey}");
#endif

        var group = new ReplacementGroup<T>(groupDirectoryPath);
        var randoGroup = new OptimizedRandomizationGroup(
            group.Targets.Count,
            group.Replacements.Count
        );
        urr.AddGroup(groupKey, randoGroup);

        int[] replacementIndexes = urr.RandomizeGroup(groupKey);

        ApplyReplacements(
            editor,
            replacementIndexes,
            group.Targets,
            group.Replacements,
            itemLotMapLocations,
            itemLotEnemyLocations,
            shopLineupLocations
        );
    }

    public static void ApplyReplacements<T>(
        ParamsEditor editor,
        int[] replacementIndexes,
        List<T> targets,
        List<T> replacements,
        Dictionary<int, List<ItemLotEntry>> itemLotMapLocations,
        Dictionary<int, List<ItemLotEntry>> itemLotEnemyLocations,
        Dictionary<int, List<int>> shopLineupLocations
    )
        where T : IGameItem
    {
        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            T target = targets[i];
            T replacement = replacements[replacementIndexes[i]];

            // replace world pickups
            ApplyItemLotMapReplacement(editor, target, replacement, itemLotMapLocations);

            // replace enemy pickups
            ApplyItemLotEnemyReplacement(editor, target, replacement, itemLotEnemyLocations);

            // replace shop pickups
            ApplyShopLineupReplacement(editor, target, replacement, shopLineupLocations);
        }
    }
}
