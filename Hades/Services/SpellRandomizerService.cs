using EldenRingParamsEditor;
using Hades.Constants;
using UniversalReplacementRandomizer;

namespace Hades.Services;

public static class SpellRandomizerService
{
    public static void ApplySpellItemLotReplacement(
        ParamsEditor editor,
        int targetId,
        int replacementId,
        int replacementCategory = 1,
        byte replacementEquipType = 3
    )
    {
        ApplySpellMapReplacement(editor, targetId, replacementId, replacementCategory);
        ApplySpellEnemyReplacement(editor, targetId, replacementId, replacementCategory);
        ApplySpellShopReplacement(editor, targetId, replacementId, replacementEquipType);
    }

    public static void ApplySpellMapReplacement(
        ParamsEditor editor,
        int targetId,
        int replacementId,
        int replacementCategory = 1
    )
    {
        var mapLocations = editor.GetGoodsIdsToItemLotMap();
        if (mapLocations.TryGetValue(targetId, out var locations))
        {
            foreach (var location in locations)
            {
                foreach (int itemSlot in location.LotItems)
                {
                    editor.SetItemLotMapLotItemId(location.ID, itemSlot, replacementId);
                    editor.SetItemLotMapCategory(location.ID, itemSlot, replacementCategory);
                }
            }
        }
    }

    public static void ApplySpellEnemyReplacement(
        ParamsEditor editor,
        int targetId,
        int replacementId,
        int replacementCategory = 1
    )
    {
        var enemyLocations = editor.GetGoodsIdsToItemLotEnemy();
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

    public static void ApplySpellShopReplacement(
        ParamsEditor editor,
        int targetId,
        int replacementId,
        byte replacementEquipType = 3
    )
    {
        var shopLocations = editor.GetGoodsIdsToShopLineup();
        if (shopLocations.TryGetValue(targetId, out var locations))
        {
            foreach (int shopLineupId in locations)
            {
                editor.SetShopLineupEquipId(shopLineupId, replacementId);
                editor.SetShopLineupEquipType(shopLineupId, replacementEquipType);
            }
        }
    }

    public static void ApplySpellWorldReplacement(
        ParamsEditor editor,
        int targetId,
        int replacementId,
        int replacementCategory = 1
    )
    {
        ApplySpellMapReplacement(editor, targetId, replacementId, replacementCategory);
        ApplySpellEnemyReplacement(editor, targetId, replacementId, replacementCategory);
    }

    public static void RandomizeSpellGroup(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupKey,
        IList<SpellEntry> targets,
        IList<SpellEntry> replacements
    )
    {
        var randoGroup = new OptimizedRandomizationGroup(targets.Count, replacements.Count);
        urr.AddGroup(groupKey, randoGroup);
        int[] replacementIndexes = urr.RandomizeGroup(groupKey);

        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            var target = targets[i];
            var replacement = replacements[replacementIndexes[i]];

            ApplySpellItemLotReplacement(
                editor,
                target.Id,
                replacement.Id,
                replacement.Category,
                replacement.EquipType
            );
        }
    }

    public static void RandomizeSpellWorldGroup(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupKey,
        IList<SpellEntry> targets,
        IList<SpellEntry> replacements
    )
    {
        var randoGroup = new OptimizedRandomizationGroup(targets.Count, replacements.Count);
        urr.AddGroup(groupKey, randoGroup);
        int[] replacementIndexes = urr.RandomizeGroup(groupKey);

        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            var target = targets[i];
            var replacement = replacements[replacementIndexes[i]];
            ApplySpellWorldReplacement(editor, target.Id, replacement.Id, replacement.Category);
        }
    }
}
