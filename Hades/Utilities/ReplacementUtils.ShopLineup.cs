// SPDX-License-Identifier: GPL-3.0-only
using System.Diagnostics;
using System.IO;
using EldenRingParamsEditor;
using Hades.Models;
using UniversalReplacementRandomizer;

namespace Hades.Utilities;

internal partial class ReplacementUtils
{
    public static void RandomizeShopLineup<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string rootDir,
        Dictionary<int, List<int>> shopLineupLocations
    )
        where T : IGameItem
    {
        (List<string> files, List<string> directories) = CsvDirectoryUtils.GetCsvStructure(rootDir);

        foreach (var file in files)
        {
            RandomizeAndReplaceShopLineupFile<T>(editor, urr, file, shopLineupLocations);
        }

        foreach (var directory in directories)
        {
            RandomizeAndReplaceShopLineupDir<T>(editor, urr, directory, shopLineupLocations);
        }
    }

    public static void RandomizeAndReplaceShopLineupFile<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupFilePath,
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
        ApplyShopLineupReplacements(editor, replacementIndexes, group, group, shopLineupLocations);
    }

    public static void RandomizeAndReplaceShopLineupDir<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupDirectoryPath,
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

        ApplyShopLineupReplacements(
            editor,
            replacementIndexes,
            group.Targets,
            group.Replacements,
            shopLineupLocations
        );
    }

    public static void ApplyShopLineupReplacements<T>(
        ParamsEditor editor,
        int[] replacementIndexes,
        List<T> targets,
        List<T> replacements,
        Dictionary<int, List<int>> shopLineupLocations
    )
        where T : IGameItem
    {
        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            T target = targets[i];
            T replacement = replacements[replacementIndexes[i]];

            ApplyShopLineupReplacement(editor, target, replacement, shopLineupLocations);
        }
    }

    public static void ApplyShopLineupReplacement<T>(
        ParamsEditor editor,
        T target,
        T replacement,
        Dictionary<int, List<int>> shopLineupLocations
    )
        where T : IGameItem
    {
        // replace ShopLineupParam locations
        if (shopLineupLocations.TryGetValue(target.ID, out List<int>? shopLocations))
        {
            foreach (int shopLineupId in shopLocations)
            {
                editor.SetShopLineupEquipId(shopLineupId, replacement.ID);
                editor.SetShopLineupEquipType(shopLineupId, replacement.EquipType);
            }
        }
    }
}
