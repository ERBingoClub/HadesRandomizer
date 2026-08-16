using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Athena.Models;
using DotNext.Collections.Generic;
using Hades.Config;
using UniversalReplacementRandomizer;

namespace Hades.Utilities;

internal class SimulationUtils
{
    // mapping: group => targetIndex => replacementIndex => count
    public static Dictionary<string, Dictionary<int, Dictionary<int, int>>> SimulateDlc(
        int numberOfSimulations = 100000
    )
    {
        using DebugTimer _ = new DebugTimer("SimulateDlc");

        List<ArmorSetModel> armorGroup = CsvReaderUtils.Read<ArmorSetModel>(
            $"{Constants.Misc}/dlc/shop_armor_sets.csv"
        );
        List<GameItemModel> shopWeaponsGroup = CsvReaderUtils.Read<GameItemModel>(
            $"{Constants.Misc}/dlc/shop_weapons.csv"
        );
        (List<string> csvFiles, List<string> validSubdirectories) =
            CsvDirectoryUtils.GetCsvStructure($"{Constants.RandomizationGroupsDlc}");

        Dictionary<string, OptimizedRandomizationGroup> groupsByFile = new();

        foreach (string file in csvFiles)
        {
            string key = Path.GetFileName(file);
            List<GameItemModel> groupList = CsvReaderUtils.Read<GameItemModel>(file);
            OptimizedRandomizationGroup group = new(groupList.Count, groupList.Count);
            groupsByFile.Add(key, group);
        }

        Dictionary<string, OptimizedRandomizationGroup> groupsByDirectory = new();
        foreach (string directory in validSubdirectories)
        {
            string key = Path.GetFileName(directory);
            ReplacementGroup<GameItemModel> groupLists = new ReplacementGroup<GameItemModel>(
                directory
            );
            OptimizedRandomizationGroup group = new(
                groupLists.Targets.Count,
                groupLists.Replacements.Count
            );
            groupsByDirectory.Add(key, group);
        }

        Dictionary<string, Dictionary<int, Dictionary<int, int>>> results = new();

        for (int i = 0; i < numberOfSimulations; i++)
        {
            int[] replacementIndexes;

            // let it choose a new random seed each time
            var urr = new OptimizedReplacementRandomizer("dlc");

            // randomize armor set
            int baseSeed = urr.GetBaseSeed();
            SeedManager seedManager = new SeedManager("dlc", baseSeed);
            Random rng = seedManager.GetRandomByKey("armor_sets.csv");
            int armorSetIndex = rng.Next(armorGroup.Count);
            Dictionary<int, Dictionary<int, int>> shopArmorSets = results.GetOrAdd(
                "armorSets",
                k =>
                {
                    return new Dictionary<int, Dictionary<int, int>>();
                }
            );

            Dictionary<int, int> armorCounts = shopArmorSets.GetOrAdd(
                0,
                shopIndex =>
                {
                    return new Dictionary<int, int>();
                }
            );
            int armorCount = armorCounts.GetOrAdd(armorSetIndex, _ => 0);
            armorCounts[armorSetIndex] = armorCount + 1;

            // randomize shop weapons
            OptimizedRandomizationGroup common = new(
                shopWeaponsGroup.Count,
                shopWeaponsGroup.Count
            );
            OptimizedRandomizationGroup merchantMillicentWeapons = new(3, common.M);
            urr.AddGroup("merchantMillicentWeapons", merchantMillicentWeapons);
            replacementIndexes = urr.RandomizeGroup("merchantMillicentWeapons");
            for (int j = 0; j < 3; j++)
            {
                Dictionary<int, Dictionary<int, int>> shopWeapons = results.GetOrAdd(
                    "shopWeapons",
                    k =>
                    {
                        return new Dictionary<int, Dictionary<int, int>>();
                    }
                );
                Dictionary<int, int> weaponCounts = shopWeapons.GetOrAdd(
                    j,
                    shopIndex =>
                    {
                        return new Dictionary<int, int>();
                    }
                );
                int weaponCount = weaponCounts.GetOrAdd(replacementIndexes[j], _ => 0);
                weaponCounts[replacementIndexes[j]] = weaponCount + 1;
            }

            // randomize each weapon group by file
            foreach ((string key, OptimizedRandomizationGroup group) in groupsByFile)
            {
                urr.AddGroup(key, group);
                replacementIndexes = urr.RandomizeGroup(key);
                for (int j = 0; j < group.M; j++)
                {
                    Dictionary<int, Dictionary<int, int>> weaponsGroup = results.GetOrAdd(
                        key,
                        k =>
                        {
                            return new Dictionary<int, Dictionary<int, int>>();
                        }
                    );
                    Dictionary<int, int> weaponsGroupCounts = weaponsGroup.GetOrAdd(
                        j,
                        shopIndex =>
                        {
                            return new Dictionary<int, int>();
                        }
                    );
                    int weaponCount = weaponsGroupCounts.GetOrAdd(replacementIndexes[j], _ => 0);
                    weaponsGroupCounts[replacementIndexes[j]] = weaponCount + 1;
                }
            }

            // randomize each weapon group by directory
            foreach ((string key, OptimizedRandomizationGroup group) in groupsByDirectory)
            {
                urr.AddGroup(key, group);
                replacementIndexes = urr.RandomizeGroup(key);
                for (int j = 0; j < group.M; j++)
                {
                    Dictionary<int, Dictionary<int, int>> weaponsGroup = results.GetOrAdd(
                        key,
                        k =>
                        {
                            return new Dictionary<int, Dictionary<int, int>>();
                        }
                    );
                    Dictionary<int, int> weaponsGroupCounts = weaponsGroup.GetOrAdd(
                        j,
                        shopIndex =>
                        {
                            return new Dictionary<int, int>();
                        }
                    );
                    int weaponCount = weaponsGroupCounts.GetOrAdd(replacementIndexes[j], _ => 0);
                    weaponsGroupCounts[replacementIndexes[j]] = weaponCount + 1;
                }
            }
        }

        return results;
    }

    public static void SimulateDlcToFile(int numberOfSimulations = 100000)
    {
        var simulationResults = SimulateDlc(numberOfSimulations);
        var options = new JsonSerializerOptions
        {
            WriteIndented = true, // for pretty-printing
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // optional
        };

        // Write to a file
        File.WriteAllText(
            $"simulation_results_dlc_{numberOfSimulations}.json",
            JsonSerializer.Serialize(simulationResults, options)
        );
    }
}
