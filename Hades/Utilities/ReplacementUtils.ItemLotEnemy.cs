// SPDX-License-Identifier: GPL-3.0-only
using System.Diagnostics;
using System.IO;
using EldenRingParamsEditor;
using Hades.Models;
using UniversalReplacementRandomizer;

namespace Hades.Utilities;

internal partial class ReplacementUtils
{
    public static void RandomizeItemLotEnemy<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string rootDir,
        Dictionary<int, List<ItemLotEntry>> itemLotEnemyLocations
    )
        where T : IGameItem
    {
        (List<string> files, List<string> directories) = CsvDirectoryUtils.GetCsvStructure(rootDir);

        foreach (var file in files)
        {
            RandomizeAndReplaceItemLotEnemyFile<T>(editor, urr, file, itemLotEnemyLocations);
        }

        foreach (var directory in directories)
        {
            RandomizeAndReplaceItemLotEnemyDir<T>(editor, urr, directory, itemLotEnemyLocations);
        }
    }

    public static void RandomizeAndReplaceItemLotEnemyFile<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupFilePath,
        Dictionary<int, List<ItemLotEntry>> itemLotEnemyLocations
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
        ApplyItemLotEnemyReplacements(
            editor,
            replacementIndexes,
            group,
            group,
            itemLotEnemyLocations
        );
    }

    public static void RandomizeAndReplaceItemLotEnemyDir<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupDirectoryPath,
        Dictionary<int, List<ItemLotEntry>> itemLotEnemyLocations
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

        ApplyItemLotEnemyReplacements(
            editor,
            replacementIndexes,
            group.Targets,
            group.Replacements,
            itemLotEnemyLocations
        );
    }

    public static void ApplyItemLotEnemyReplacements<T>(
        ParamsEditor editor,
        int[] replacementIndexes,
        List<T> targets,
        List<T> replacements,
        Dictionary<int, List<ItemLotEntry>> itemLotEnemyLocations
    )
        where T : IGameItem
    {
        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            T target = targets[i];
            T replacement = replacements[replacementIndexes[i]];

            ApplyItemLotEnemyReplacement(editor, target, replacement, itemLotEnemyLocations);
        }
    }

    public static void ApplyItemLotEnemyReplacement<T>(
        ParamsEditor editor,
        T target,
        T replacement,
        Dictionary<int, List<ItemLotEntry>> itemLotEnemyLocations
    )
        where T : IGameItem
    {
        List<ItemLotEntry>? locations;

        // replace ItemLotParam_enemy locations
        if (itemLotEnemyLocations.TryGetValue(target.ID, out locations))
        {
            foreach (ItemLotEntry location in locations)
            {
                foreach (int itemSlot in location.LotItems)
                {
                    editor.SetItemLotEnemyLotItemId(location.ID, itemSlot, replacement.ID);
                    editor.SetItemLotEnemyCategory(location.ID, itemSlot, replacement.Category);
                }
            }
        }
    }
}
