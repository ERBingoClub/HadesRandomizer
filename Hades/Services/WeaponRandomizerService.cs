using EldenRingParamsEditor;
using Hades.Constants;
using UniversalReplacementRandomizer;

namespace Hades.Services;

public static class WeaponRandomizerService
{
    public static void ApplyWeaponItemLotReplacement(
        ParamsEditor editor,
        int targetId,
        int replacementId,
        int replacementCategory = 2,
        byte replacementEquipType = 0
    )
    {
        ApplyWeaponMapReplacement(editor, targetId, replacementId, replacementCategory);
        ApplyWeaponEnemyReplacement(editor, targetId, replacementId, replacementCategory);
        ApplyWeaponShopReplacement(editor, targetId, replacementId, replacementEquipType);
    }

    public static void ApplyWeaponMapReplacement(
        ParamsEditor editor,
        int targetId,
        int replacementId,
        int replacementCategory = 2
    )
    {
        var mapLocations = editor.GetWeaponIdsToItemLotMap();
        if (mapLocations.TryGetValue(targetId, out var locations))
        {
            foreach (var location in locations)
            {
                if (location.ID == 16000690) continue;
                foreach (int itemSlot in location.LotItems)
                {
                    editor.SetItemLotMapLotItemId(location.ID, itemSlot, replacementId);
                    editor.SetItemLotMapCategory(location.ID, itemSlot, replacementCategory);
                }
            }
        }
    }

    public static void ApplyWeaponEnemyReplacement(
        ParamsEditor editor,
        int targetId,
        int replacementId,
        int replacementCategory = 2
    )
    {
        var enemyLocations = editor.GetWeaponIdsToItemLotEnemy();
        if (enemyLocations.TryGetValue(targetId, out var locations))
        {
            foreach (var location in locations)
            {
                foreach (int itemSlot in location.LotItems)
                {
                    editor.SetItemLotEnemyLotItemId(location.ID, itemSlot, replacementId);
                    editor.SetItemLotEnemyCategory(location.ID, itemSlot, replacementCategory);
                }
            }
        }
    }

    public static void ApplyWeaponShopReplacement(
        ParamsEditor editor,
        int targetId,
        int replacementId,
        byte replacementEquipType = 0
    )
    {
        var shopLocations = editor.GetWeaponIdsToShopLineup();
        if (shopLocations.TryGetValue(targetId, out var locations))
        {
            foreach (int shopLineupId in locations)
            {
                editor.SetShopLineupEquipId(shopLineupId, replacementId);
                editor.SetShopLineupEquipType(shopLineupId, replacementEquipType);
            }
        }
    }

    public static void ApplyWeaponWorldReplacement(
        ParamsEditor editor,
        int targetId,
        int replacementId,
        int replacementCategory = 2
    )
    {
        ApplyWeaponMapReplacement(editor, targetId, replacementId, replacementCategory);
        ApplyWeaponEnemyReplacement(editor, targetId, replacementId, replacementCategory);
    }

    public static void RandomizeWeaponGroup(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupKey,
        IList<WeaponEntry> targets,
        IList<WeaponEntry> replacements
    )
    {
        var randoGroup = new OptimizedRandomizationGroup(targets.Count, replacements.Count);
        urr.AddGroup(groupKey, randoGroup);
        int[] replacementIndexes = urr.RandomizeGroup(groupKey);

        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            var target = targets[i];
            var replacement = replacements[replacementIndexes[i]];

            ApplyWeaponItemLotReplacement(editor, target.Id, replacement.Id);
        }
    }

    public static void RandomizeWeaponWorldGroup(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupKey,
        IList<WeaponEntry> targets,
        IList<WeaponEntry> replacements
    )
    {
        var randoGroup = new OptimizedRandomizationGroup(targets.Count, replacements.Count);
        urr.AddGroup(groupKey, randoGroup);
        int[] replacementIndexes = urr.RandomizeGroup(groupKey);

        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            var target = targets[i];
            var replacement = replacements[replacementIndexes[i]];
            ApplyWeaponWorldReplacement(editor, target.Id, replacement.Id);
        }
    }
}
