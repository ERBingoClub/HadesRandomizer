// SPDX-License-Identifier: GPL-3.0-only
using System.Diagnostics;
using System.IO;
using EldenRingParamsEditor;
using Hades.Models;
using UniversalReplacementRandomizer;

namespace Hades.Utilities;

internal partial class ReplacementUtils
{
    public static void RandomizeItemLotMap<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string rootDir,
        Dictionary<int, List<ItemLotEntry>> itemLotMapLocations
    )
        where T : IGameItem
    {
        (List<string> files, List<string> directories) = CsvDirectoryUtils.GetCsvStructure(rootDir);

        foreach (var file in files)
        {
            RandomizeAndReplaceItemLotMapFile<T>(editor, urr, file, itemLotMapLocations);
        }

        foreach (var directory in directories)
        {
            RandomizeAndReplaceItemLotMapDir<T>(editor, urr, directory, itemLotMapLocations);
        }
    }

    public static void RandomizeAndReplaceItemLotMapFile<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupFilePath,
        Dictionary<int, List<ItemLotEntry>> itemLotMapLocations
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
        ApplyItemLotMapReplacements(editor, replacementIndexes, group, group, itemLotMapLocations);
    }

    public static void RandomizeAndReplaceItemLotMapDir<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupDirectoryPath,
        Dictionary<int, List<ItemLotEntry>> itemLotMapLocations
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

        ApplyItemLotMapReplacements(
            editor,
            replacementIndexes,
            group.Targets,
            group.Replacements,
            itemLotMapLocations
        );
    }

    public static void ApplyItemLotMapReplacements<T>(
        ParamsEditor editor,
        int[] replacementIndexes,
        List<T> targets,
        List<T> replacements,
        Dictionary<int, List<ItemLotEntry>> itemLotMapLocations
    )
        where T : IGameItem
    {
        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            T target = targets[i];
            T replacement = replacements[replacementIndexes[i]];

            ApplyItemLotMapReplacement(editor, target, replacement, itemLotMapLocations);
        }
    }

    public static void ApplyItemLotMapReplacement<T>(
        ParamsEditor editor,
        T target,
        T replacement,
        Dictionary<int, List<ItemLotEntry>> itemLotMapLocations
    )
        where T : IGameItem
    {
        List<ItemLotEntry>? locations;

        // replace ItemLotParam_map locations
        if (itemLotMapLocations.TryGetValue(target.ID, out locations))
        {
            foreach (ItemLotEntry location in locations)
            {
                foreach (int itemSlot in location.LotItems)
                {
                    editor.SetItemLotMapLotItemId(location.ID, itemSlot, replacement.ID);
                    editor.SetItemLotMapCategory(location.ID, itemSlot, replacement.Category);
                }
            }
        }
    }
}
