using EldenRingParamsEditor;
using Hades.Constants;
using UniversalReplacementRandomizer;

namespace Hades.Services;

public static class ShopRandomizerService
{
    public static void ShuffleShopLineups(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupKey,
        IList<int> shopLineupIds
    )
    {
        if (shopLineupIds.Count < 2)
            return;

        var currentEquipIds = shopLineupIds.Select(id => editor.GetShopLineupEquipId(id)).ToList();
        var currentEquipTypes = shopLineupIds
            .Select(id => editor.GetShopLineupEquipType(id))
            .ToList();

        var randoGroup = new OptimizedRandomizationGroup(shopLineupIds.Count, shopLineupIds.Count);
        urr.AddGroup(groupKey, randoGroup);
        int[] perm = urr.RandomizeGroup(groupKey);

        for (int i = 0; i < shopLineupIds.Count; i++)
        {
            int shopId = shopLineupIds[i];
            int srcIdx = perm[i];
            editor.SetShopLineupEquipId(shopId, currentEquipIds[srcIdx]);
            editor.SetShopLineupEquipType(shopId, currentEquipTypes[srcIdx]);
        }
    }

    public static void AssignShopsFromPool<T>(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupKey,
        IList<int> shopLineupIds,
        IList<T> pool,
        Func<T, int> getId,
        Func<T, byte> getEquipType
    )
    {
        if (shopLineupIds.Count == 0 || pool.Count == 0)
            return;

        // OptimizedRandomizationGroup has a bug with M=1,N=1 (n=0) — see crash log line 262.
        // Handle single-shop or single-pool cases directly without going through the group.
        if (shopLineupIds.Count == 1 && pool.Count == 1)
        {
            // Nothing to shuffle — deterministic, but log for visibility
            return;
        }
        if (shopLineupIds.Count == 1)
        {
            // Single shop slot: pick one random entry from pool
            var rng = urr.GetSeedManager().GetRandomByKey(groupKey);
            int idx = rng.Next(pool.Count);
            var replacement = pool[idx];
            editor.SetShopLineupEquipId(shopLineupIds[0], getId(replacement));
            editor.SetShopLineupEquipType(shopLineupIds[0], getEquipType(replacement));
            return;
        }
        if (pool.Count == 1)
        {
            // Single pool entry for many shops: all shops get the same (only option)
            var replacement = pool[0];
            foreach (var shopId in shopLineupIds)
            {
                editor.SetShopLineupEquipId(shopId, getId(replacement));
                editor.SetShopLineupEquipType(shopId, getEquipType(replacement));
            }
            return;
        }

        var randoGroup = new OptimizedRandomizationGroup(shopLineupIds.Count, pool.Count);
        urr.AddGroup(groupKey, randoGroup);
        int[] perm = urr.RandomizeGroup(groupKey);

        for (int i = 0; i < shopLineupIds.Count; i++)
        {
            var replacement = pool[perm[i]];
            editor.SetShopLineupEquipId(shopLineupIds[i], getId(replacement));
            editor.SetShopLineupEquipType(shopLineupIds[i], getEquipType(replacement));
        }
    }

    /// <summary>
    /// Weapon shops: ANY weapon irrespective of category.
    /// All normal weapon shops (Guaranteed+Chance, optionally +Remembrance) are treated as one
    /// single pool — NO internal dupes (shops distinct), but can dupe world pickups (separate URR copy).
    /// </summary>
    public static void RandomizeWeaponShopsByCategory(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupKeyPrefix = "shop_weapon_category_",
        bool includeRemembranceInPool = true
    )
    {
        var fullPool = includeRemembranceInPool
            ? Weapons
                .GuaranteedWeapons.Concat(Weapons.ChanceWeapons)
                .Concat(Weapons.RemembranceWeapons)
                .ToList()
            : Weapons.GuaranteedWeapons.Concat(Weapons.ChanceWeapons).ToList();

        var weaponShopMap = editor.GetWeaponIdsToShopLineup();
        var allWeaponIds = new HashSet<int>(fullPool.Select(w => w.Id));

        var allShopIds = new HashSet<int>();
        foreach (var kv in weaponShopMap)
        {
            if (!allWeaponIds.Contains(kv.Key))
                continue;
            foreach (int shopId in kv.Value)
                allShopIds.Add(shopId);
        }

        if (allShopIds.Count == 0)
            return;

        // Single group ANY — no internal dupes when shops <= pool (true: ~74 shops <- 422 pool)
        AssignShopsFromPool(
            editor,
            urr,
            $"{groupKeyPrefix}ANY",
            allShopIds.ToList(),
            fullPool,
            w => w.Id,
            _ => (byte)0
        );
    }

    public static void RandomizeRemembranceWeaponShops(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupKey = "shop_remembrance_weapons"
    )
    {
        var pool = Weapons.RemembranceWeapons.ToList();
        var remembranceIds = new HashSet<int>(pool.Select(w => w.Id));
        var weaponShopMap = editor.GetWeaponIdsToShopLineup();
        var remembranceShopIds = new List<int>();
        foreach (var kv in weaponShopMap)
        {
            if (!remembranceIds.Contains(kv.Key))
                continue;
            remembranceShopIds.AddRange(kv.Value);
        }

        if (remembranceShopIds.Count >= 1 && pool.Count > 0)
            AssignShopsFromPool(
                editor,
                urr,
                groupKey,
                remembranceShopIds,
                pool,
                w => w.Id,
                _ => (byte)0
            );
    }

    public static void RandomizeSpellShopsByCategory(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupKeyPrefix = "shop_spell_type_"
    )
    {
        var worldPool = Spells.WorldSpells;
        var poolByType = worldPool.GroupBy(s => s.Type).ToDictionary(g => g.Key, g => g.ToList());
        var spellById = worldPool.ToDictionary(s => s.Id);

        var goodsShopMap = editor.GetGoodsIdsToShopLineup();
        var shopIdToSpellId = new Dictionary<int, int>();
        foreach (var kv in goodsShopMap)
        {
            if (!spellById.ContainsKey(kv.Key))
                continue;
            foreach (int shopId in kv.Value)
            {
                if (!shopIdToSpellId.ContainsKey(shopId))
                    shopIdToSpellId[shopId] = kv.Key;
            }
        }

        var typeGroups = new Dictionary<SpellType, List<int>>();
        foreach (var kv in shopIdToSpellId)
        {
            int shopId = kv.Key;
            int spellId = kv.Value;
            if (!spellById.TryGetValue(spellId, out var entry))
                continue;
            if (!typeGroups.TryGetValue(entry.Type, out var list))
            {
                list = new List<int>();
                typeGroups[entry.Type] = list;
            }
            list.Add(shopId);
        }

        foreach (var kv in typeGroups)
        {
            var type = kv.Key;
            var shopIds = kv.Value;
            if (shopIds.Count < 1)
                continue;
            if (!poolByType.TryGetValue(type, out var pool) || pool.Count == 0)
                continue;
            AssignShopsFromPool(
                editor,
                urr,
                $"{groupKeyPrefix}{type}",
                shopIds,
                pool,
                s => s.Id,
                s => s.EquipType
            );
        }
    }

    public static void RandomizeRemembranceSpellShops(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        string groupKeyPrefix = "shop_remembrance_spell_type_"
    )
    {
        var poolByType = Spells
            .RemembranceSpells.GroupBy(s => s.Type)
            .ToDictionary(g => g.Key, g => g.ToList());
        var remSpellsById = Spells.RemembranceSpells.ToDictionary(s => s.Id);

        var goodsShopMap = editor.GetGoodsIdsToShopLineup();
        var shopIdToSpellId = new Dictionary<int, int>();
        foreach (var kv in goodsShopMap)
        {
            if (!remSpellsById.ContainsKey(kv.Key))
                continue;
            foreach (int shopId in kv.Value)
            {
                if (!shopIdToSpellId.ContainsKey(shopId))
                    shopIdToSpellId[shopId] = kv.Key;
            }
        }

        var typeGroups = new Dictionary<SpellType, List<int>>();
        foreach (var kv in shopIdToSpellId)
        {
            int shopId = kv.Key;
            int spellId = kv.Value;
            if (!remSpellsById.TryGetValue(spellId, out var entry))
                continue;
            if (!typeGroups.TryGetValue(entry.Type, out var list))
            {
                list = new List<int>();
                typeGroups[entry.Type] = list;
            }
            list.Add(shopId);
        }

        foreach (var kv in typeGroups)
        {
            var type = kv.Key;
            var shopIds = kv.Value;
            if (shopIds.Count < 1)
                continue;
            if (!poolByType.TryGetValue(type, out var pool) || pool.Count == 0)
                continue;
            AssignShopsFromPool(
                editor,
                urr,
                $"{groupKeyPrefix}{type}",
                shopIds,
                pool,
                s => s.Id,
                s => s.EquipType
            );
        }
    }
}
