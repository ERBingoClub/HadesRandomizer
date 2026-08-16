using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Utilities;
using EldenRingParamsEditor;
using Hades.Models;
using UniversalReplacementRandomizer;

namespace Hades.Services;

public class RandomizerServiceStartingClass
{
    private const int TotalStats = 8;
    private const int TotalPoints = 88;
    private const int MinStat = 5;
    private const int MaxStat = 16;
    private const int NumClasses = 10;

    // vigor, mind, endurance, strength, dexterity, intelligence, faith, arcane
    public record ClassStatAllocation(int[] Stats);

    public record ArmorSetAllocation(int HelmetID, int TorsoID, int GauntletsID, int GreavesID);

    public record WeaponSetAllocation(
        string RightWeaponName,
        string LeftWeaponName,
        string AmmunitionName,
        int RightWeaponID,
        int LeftWeaponID,
        int AmmunitionID,
        ushort AmmunitionCount
    );

    public List<ClassStatAllocation> GenerateAllClassStats(OptimizedReplacementRandomizer urr)
    {
        Random rng = urr.GetSeedManager().GetRandomByKey("starting_class_stats");
        List<ClassStatAllocation> results = new();

        for (int i = 0; i < NumClasses; i++)
        {
            int[] stats = i switch
            {
                4 => GenerateRandomStatDistribution(rng, enforceIntelligenceMin: 9), // astrologer
                5 => GenerateRandomStatDistribution(rng, enforceFaithMin: 9), // prophet
                _ => GenerateRandomStatDistribution(rng),
            };

            results.Add(new ClassStatAllocation(stats));
        }

        return results;
    }

    private int[] GenerateRandomStatDistribution(
        Random rng,
        int enforceIntelligenceMin = -1,
        int enforceFaithMin = -1
    )
    {
        int[] stats = Enumerable.Repeat(MinStat, TotalStats).ToArray();
        int remaining = TotalPoints - TotalStats * MinStat;

        while (remaining > 0)
        {
            int index = rng.Next(TotalStats);
            if (stats[index] < MaxStat)
            {
                stats[index]++;
                remaining--;
            }
        }

        if (enforceIntelligenceMin >= 0 && stats[5] < enforceIntelligenceMin)
        {
            return GenerateRandomStatDistribution(rng, enforceIntelligenceMin, enforceFaithMin);
        }
        if (enforceFaithMin >= 0 && stats[6] < enforceFaithMin)
        {
            return GenerateRandomStatDistribution(rng, enforceIntelligenceMin, enforceFaithMin);
        }

        return stats;
    }

    public List<ArmorSetAllocation> GenerateArmorSets(
        OptimizedReplacementRandomizer urr,
        string rootDir
    )
    {
        List<ArmorSetAllocation> armorSets = new();

        List<GameItemModel> helmetsList = CsvReaderUtils.Read<GameItemModel>(
            $"{rootDir}/helmets.csv"
        );
        OptimizedRandomizationGroup helmetsGroup = new(NumClasses, helmetsList.Count);
        urr.AddGroup("starting_helmets", helmetsGroup);
        int[] helmetReplacements = urr.RandomizeGroup("starting_helmets");

        List<GameItemModel> torsosList = CsvReaderUtils.Read<GameItemModel>(
            $"{rootDir}/torsos.csv"
        );
        OptimizedRandomizationGroup torsosGroup = new(NumClasses, torsosList.Count);
        urr.AddGroup("starting_torsos", torsosGroup);
        int[] torsosReplacements = urr.RandomizeGroup("starting_torsos");

        List<GameItemModel> gauntletsList = CsvReaderUtils.Read<GameItemModel>(
            $"{rootDir}/gauntlets.csv"
        );
        OptimizedRandomizationGroup gauntletsGroup = new(NumClasses, gauntletsList.Count);
        urr.AddGroup("starting_gauntlets", gauntletsGroup);
        int[] gauntletsReplacements = urr.RandomizeGroup("starting_gauntlets");

        List<GameItemModel> greavesList = CsvReaderUtils.Read<GameItemModel>(
            $"{rootDir}/greaves.csv"
        );
        OptimizedRandomizationGroup greavesGroup = new(NumClasses, greavesList.Count);
        urr.AddGroup("starting_greaves", greavesGroup);
        int[] greavesReplacements = urr.RandomizeGroup("starting_greaves");

        for (int i = 0; i < NumClasses; i++)
        {
            var armor = new ArmorSetAllocation(
                helmetsList[helmetReplacements[i]].ID,
                torsosList[torsosReplacements[i]].ID,
                gauntletsList[gauntletsReplacements[i]].ID,
                greavesList[greavesReplacements[i]].ID
            );
            armorSets.Add(armor);
        }

        return armorSets;
    }

    public List<WeaponSetAllocation> GenerateWeaponSets(
        OptimizedReplacementRandomizer urr,
        string rootDir
    )
    {
        List<WeaponModel> meleeWeapons = CsvReaderUtils.Read<WeaponModel>($"{rootDir}/melee.csv");
        List<WeaponModel> shields = CsvReaderUtils.Read<WeaponModel>($"{rootDir}/shields.csv");
        List<WeaponModel> rangedWeapons = CsvReaderUtils.Read<WeaponModel>($"{rootDir}/ranged.csv");
        List<WeaponModel> ammunition = CsvReaderUtils.Read<WeaponModel>(
            $"{rootDir}/ammunition.csv"
        );

        // Copy lists to remove used items during allocation
        List<WeaponModel> meleeRemaining = new(meleeWeapons);
        List<WeaponModel> shieldRemaining = new(shields);
        List<WeaponModel> rangedRemaining = new(rangedWeapons);
        List<WeaponModel> ammoRemaining = new(ammunition);

        List<WeaponSetAllocation> results = new();
        Random rng = urr.GetSeedManager().GetRandomByKey("starting_class_weapons");

        for (int i = 0; i < NumClasses; i++)
        {
            // Pick right-hand melee weapon (no exceptions)
            if (meleeRemaining.Count == 0)
            {
                throw new Exception(
                    "Not enough melee weapons to assign a unique right-hand weapon to each class."
                );
            }

            int rightIndex = rng.Next(meleeRemaining.Count);
            WeaponModel right = meleeRemaining[rightIndex];
            meleeRemaining.RemoveAt(rightIndex);

            int leftWeaponId;
            int ammoId = -1;
            ushort ammoCount = 0;
            string leftWeaponName = "";
            string ammunitionName = "";

            // Weighted selection
            int totalWeight = meleeRemaining.Count + shieldRemaining.Count + rangedRemaining.Count;
            if (totalWeight == 0)
            {
                throw new Exception("No valid left-hand options remaining.");
            }

            int roll = rng.Next(totalWeight);

            if (roll < meleeRemaining.Count)
            {
                int idx = roll;
                leftWeaponId = meleeRemaining[idx].ID;
                leftWeaponName = meleeRemaining[idx].Name;
                meleeRemaining.RemoveAt(idx);
            }
            else if (roll < meleeRemaining.Count + shieldRemaining.Count)
            {
                int idx = roll - meleeRemaining.Count;
                leftWeaponId = shieldRemaining[idx].ID;
                leftWeaponName = shieldRemaining[idx].Name;
                shieldRemaining.RemoveAt(idx);
            }
            else
            {
                int idx = roll - meleeRemaining.Count - shieldRemaining.Count;
                WeaponModel ranged = rangedRemaining[idx];
                rangedRemaining.RemoveAt(idx);
                leftWeaponId = ranged.ID;
                leftWeaponName = ranged.Name;

                int ammoType = 0;
                switch (ranged.WepType)
                {
                    case 56: // ballista
                    {
                        ammoType = 85;
                        break;
                    }
                    case 51:
                    case 50: // bow or light bow
                    {
                        ammoType = 81;
                        break;
                    }
                    case 53: // great bow
                    {
                        ammoType = 83;
                        break;
                    }
                    default: // crossbow
                    {
                        ammoType = 85;
                        break;
                    }
                }

                // Try to find corresponding ammo
                var validAmmo = ammoRemaining.Where(a => ammoType == a.WepType).ToList();
                if (validAmmo.Count > 0)
                {
                    WeaponModel chosenAmmo = validAmmo[rng.Next(validAmmo.Count)];
                    ammunitionName = chosenAmmo.Name;
                    ammoId = chosenAmmo.ID;
                    ammoCount = (ushort)rng.Next(10, 21); // Reasonable count range
                    ammoRemaining.Remove(chosenAmmo);
                }
            }

            results.Add(
                new WeaponSetAllocation(
                    RightWeaponName: right.Name,
                    LeftWeaponName: leftWeaponName,
                    AmmunitionName: ammunitionName,
                    RightWeaponID: right.ID,
                    LeftWeaponID: leftWeaponId,
                    AmmunitionID: ammoId,
                    AmmunitionCount: ammoCount
                )
            );
        }

        return results;
    }

    public void ClearLoadout(ParamsEditor editor, int charaInitId)
    {
        for (int j = 0; j < 2; j++)
        {
            editor.SetInitialEquipWepRight(charaInitId, j, -1);
            editor.SetInitialEquipWepLeft(charaInitId, j, -1);
        }
        for (int j = 0; j < 4; j++)
        {
            editor.SetInitialEquipAmmunition(charaInitId, j, -1, 0);
        }
        for (int j = 0; j < 7; j++)
        {
            editor.SetInitialEquipSpell(charaInitId, j, -1);
        }
        editor.SetInitialEquipHelm(charaInitId, -1);
        editor.SetInitialEquipTorso(charaInitId, -1);
        editor.SetInitialEquipArm(charaInitId, -1);
        editor.SetInitialEquipLeg(charaInitId, -1);

        // clear all items
        for (int j = 0; j < 10; j++)
        {
            editor.SetInitialEquipItem(charaInitId, j, -1);
            editor.SetInitialEquipItemAmount(charaInitId, j, 0);
        }
    }

    public void ApplyStatAllocation(
        ParamsEditor editor,
        int charaInitId,
        ClassStatAllocation statAllocation
    )
    {
        editor.SetInitialVigor(charaInitId, (byte)statAllocation.Stats[0]);
        editor.SetInitialMind(charaInitId, (byte)statAllocation.Stats[1]);
        editor.SetInitialEndurance(charaInitId, (byte)statAllocation.Stats[2]);
        editor.SetInitialStrength(charaInitId, (byte)statAllocation.Stats[3]);
        editor.SetInitialDexterity(charaInitId, (byte)statAllocation.Stats[4]);
        editor.SetInitialIntelligence(charaInitId, (byte)statAllocation.Stats[5]);
        editor.SetInitialFaith(charaInitId, (byte)statAllocation.Stats[6]);
        editor.SetInitialArcane(charaInitId, (byte)statAllocation.Stats[7]);
    }

    public void ApplyArmorSet(
        ParamsEditor editor,
        int charaInitId,
        ArmorSetAllocation armorAllocation
    )
    {
        editor.SetInitialEquipHelm(charaInitId, armorAllocation.HelmetID);
        editor.SetInitialEquipTorso(charaInitId, armorAllocation.TorsoID);
        editor.SetInitialEquipArm(charaInitId, armorAllocation.GauntletsID);
        editor.SetInitialEquipLeg(charaInitId, armorAllocation.GreavesID);
    }

    public void ApplyWeaponSet(
        ParamsEditor editor,
        int charaInitId,
        WeaponSetAllocation weaponAllocation
    )
    {
        editor.SetInitialEquipWepRight(charaInitId, 0, weaponAllocation.RightWeaponID);
        editor.SetInitialEquipWepLeft(charaInitId, 0, weaponAllocation.LeftWeaponID);
        editor.SetInitialEquipAmmunition(
            charaInitId,
            0,
            weaponAllocation.AmmunitionID,
            weaponAllocation.AmmunitionCount
        );
    }

    public string GenerateClassDescription(
        ParamsEditor editor,
        ArmorSetAllocation armorAllocation,
        WeaponSetAllocation weaponAllocation,
        ClassStatAllocation statAllocation
    )
    {
        // get actual stats after any buffs from armor
        int[] buffedStats = new int[5];

        // only str, dex, int, faith, and arcane can be weapon requirements
        Array.Copy(statAllocation.Stats[3..], buffedStats, 5);
        for (int j = 0; j < buffedStats.Length; j++)
        {
            int spEffectIdHelm = editor.GetEquipProtectorResidentSpEffectId(
                armorAllocation.HelmetID
            );
            if (spEffectIdHelm != -1)
            {
                buffedStats[j] += editor.GetSpEffectAddStat(spEffectIdHelm, j + 3);
            }
            int spEffectIdTorso = editor.GetEquipProtectorResidentSpEffectId(
                armorAllocation.TorsoID
            );
            if (spEffectIdTorso != -1)
            {
                buffedStats[j] += editor.GetSpEffectAddStat(spEffectIdTorso, j + 3);
            }
            int spEffectIdGauntlets = editor.GetEquipProtectorResidentSpEffectId(
                armorAllocation.GauntletsID
            );
            if (spEffectIdGauntlets != -1)
            {
                buffedStats[j] += editor.GetSpEffectAddStat(spEffectIdGauntlets, j + 3);
            }
            int spEffectIdGreaves = editor.GetEquipProtectorResidentSpEffectId(
                armorAllocation.GreavesID
            );
            if (spEffectIdGreaves != -1)
            {
                buffedStats[j] += editor.GetSpEffectAddStat(spEffectIdGreaves, j + 3);
            }
        }

        // right weapon w/ deficit
        string rightWeaponDescription = GetWeaponDescriptionWithDeficit(
            editor,
            weaponAllocation.RightWeaponID,
            weaponAllocation.RightWeaponName,
            buffedStats
        );

        // left weapon w/ deficit
        string leftWeaponDescription = GetWeaponDescriptionWithDeficit(
            editor,
            weaponAllocation.LeftWeaponID,
            weaponAllocation.LeftWeaponName,
            buffedStats
        );

        // full class description string
        string classDescription = $"{rightWeaponDescription}, {leftWeaponDescription}";

        // add ammunition and count (if any)
        if (weaponAllocation.AmmunitionName != "" && weaponAllocation.AmmunitionCount != 0)
        {
            classDescription +=
                $", {weaponAllocation.AmmunitionName}[{weaponAllocation.AmmunitionCount}]";
        }

        return classDescription;
    }

    private string GetWeaponDescriptionWithDeficit(
        ParamsEditor editor,
        int weaponId,
        string weaponName,
        int[] buffedStats
    )
    {
        // we will count the total deficit
        int statDeficit = 0;

        // check each of the 5 potential requirement stats: str, dex, int, faith, arcane
        for (int j = 0; j < 5; j++)
        {
            // get the current req
            int requirement = editor.GetEquipWeaponProperStat(weaponId, j);
            if (requirement == 0)
                continue;

            // account for two handing bonus for strength (divide requirement by 1.5, rounding up when necessary)
            if (j == 0)
            {
                int numerator = requirement * 2;
                requirement = numerator % 3 > 0 ? numerator / 3 + 1 : numerator / 3;
            }

            if (requirement > buffedStats[j])
            {
                statDeficit += requirement - buffedStats[j];
            }
        }

        // if there's a deficit, add it to the weapon description string and return
        if (statDeficit > 0)
        {
            return $"{weaponName} (-{statDeficit})";
        }
        else
        {
            // else, just return the weapon name
            return weaponName;
        }
    }
}
