// SPDX-License-Identifier: GPL-3.0-only
using DotNext.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRingParamsEditor;

public partial class ParamsEditor
{
    private Dictionary<int, List<ItemLotEntry>>? _weaponIdsToItemLotMap;
    private Dictionary<int, List<ItemLotEntry>>? _weaponIdsToItemLotEnemy;
    private Dictionary<int, List<int>>? _weaponIdsToShopLineup;
    private Dictionary<int, List<ItemLotEntry>>? _goodsIdsToItemLotMap;
    private Dictionary<int, List<ItemLotEntry>>? _goodsIdsToItemLotEnemy;
    private Dictionary<int, List<int>>? _goodsIdsToShopLineup;

    public Dictionary<int, List<ItemLotEntry>> GetGoodsIdsToItemLotMap()
    {
        if (_goodsIdsToItemLotMap == null)
        {
            _goodsIdsToItemLotMap = ResourceManager.GetGoodsIdsToItemLot(ItemLotType.Map);
        }
        return _goodsIdsToItemLotMap;
    }

    public Dictionary<int, List<ItemLotEntry>> GetGoodsIdsToItemLotEnemy()
    {
        if (_goodsIdsToItemLotEnemy == null)
        {
            _goodsIdsToItemLotEnemy = ResourceManager.GetGoodsIdsToItemLot(ItemLotType.Enemy);
        }
        return _goodsIdsToItemLotEnemy;
    }

    public Dictionary<int, List<int>> GetGoodsIdsToShopLineup()
    {
        if (_goodsIdsToShopLineup == null)
        {
            _goodsIdsToShopLineup = ResourceManager.GetGoodsIdsToShopLineup();
        }
        return _goodsIdsToShopLineup;
    }

    public Dictionary<int, List<ItemLotEntry>> GetWeaponIdsToItemLotMap()
    {
        if (_weaponIdsToItemLotMap == null)
        {
            _weaponIdsToItemLotMap = ResourceManager.GetWeaponIdsToItemLot(ItemLotType.Map);
        }
        return _weaponIdsToItemLotMap;
    }

    public Dictionary<int, List<ItemLotEntry>> GetWeaponIdsToItemLotEnemy()
    {
        if (_weaponIdsToItemLotEnemy == null)
        {
            _weaponIdsToItemLotEnemy = ResourceManager.GetWeaponIdsToItemLot(ItemLotType.Enemy);
        }
        return _weaponIdsToItemLotEnemy;
    }

    public Dictionary<int, List<int>> GetWeaponIdsToShopLineup()
    {
        if (_weaponIdsToShopLineup == null)
        {
            _weaponIdsToShopLineup = ResourceManager.GetWeaponIdsToShopLineup();
        }
        return _weaponIdsToShopLineup;
    }

    public void GenerateMappingWeaponIdsToShopLineup(List<int> weaponIds)
    {
        // Only work with known weaponIds
        List<int> equipWeaponIds = _idToRowIndexEquipWeapon.Keys.ToList();
        List<int> equipCustomWeaponIds = _idToRowIndexEquipCustomWeapon.Keys.ToList();
        foreach (int weaponId in weaponIds)
        {
            if (!equipWeaponIds.Contains(weaponId) && !equipCustomWeaponIds.Contains(weaponId))
            {
                throw new Exception($"Unknown weaponId: {weaponId}");
            }
        }

        Dictionary<int, List<int>> weaponIdsToShopLineupMap = new();

        // Iterate through all known ShopLineup Ids
        List<int> shopLineupIds = _idToRowIndexShopLineup.Keys.ToList();
        foreach (int shopLineupId in shopLineupIds)
        {
            // Get the itemId.
            int itemId = GetShopLineupEquipId(shopLineupId);
            if (itemId == 0)
            {
                continue; // If it's 0, then just skip it.
            }
            byte itemEquipType = GetShopLineupEquipType(shopLineupId);
            if (itemEquipType != 0 && itemEquipType != 5) // weapon or customWeapon
            {
                continue; // If it's not a weapon, then skip it.
            }

            // Now check if this is one of our target Ids.
            if (weaponIds.Contains(itemId))
            {
                // Add this itemId to the locations
                List<int> weaponIdLocations = weaponIdsToShopLineupMap.GetOrAdd(itemId, id =>
                {
                    return new List<int>() { };
                });
                weaponIdLocations.Add(shopLineupId);
                weaponIdsToShopLineupMap[itemId] = weaponIdLocations;
            }
        }

        // Save the results
        ResourceManager.SaveWeaponIdsToShopLineup(weaponIdsToShopLineupMap);
    }

    public void GenerateMappingWeaponIdsToItemLot(List<int> weaponIds)
    {
        // Only work with known weaponIds
        List<int> equipWeaponIds = _idToRowIndexEquipWeapon.Keys.ToList();
        List<int> equipCustomWeaponIds = _idToRowIndexEquipCustomWeapon.Keys.ToList();
        foreach (int weaponId in weaponIds)
        {
            if (!equipWeaponIds.Contains(weaponId) && !equipCustomWeaponIds.Contains(weaponId))
            {
                throw new Exception($"Unknown weaponId: {weaponId}");
            }
        }

        // Start with ItemLot_map
        Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotMap = new();

        // Iterate through all known ItemLotMap Ids
        List<int> itemLotMapIds = _idToRowIndexItemLotMap.Keys.ToList();
        foreach (int itemLotId in itemLotMapIds)
        {
            // We need to check all 8 ItemLotMap.lotItemIds
            for (int i = 0; i < 8; i++)
            {
                // Get the itemId.
                int itemId = GetItemLotMapLotItemId(itemLotId, i);
                if (itemId == 0)
                {
                    continue; // If it's 0, then just skip it. (Most will be 0).
                }
                int itemCategory = GetItemLotMapCategory(itemLotId, i);
                if (itemCategory != 2 && itemCategory != 6) // weapon or customWeapon
                {
                    continue; // If it's not a weapon, then skip it.
                }

                // Now check if this is one of our target Ids.
                if (weaponIds.Contains(itemId))
                {
                    // Add this itemId to the locations (first layer key)
                    List<ItemLotEntry> weaponIdLocations = weaponIdsToItemLotMap.GetOrAdd(itemId, id =>
                    {
                        return new List<ItemLotEntry>() { new ItemLotEntry() { ID = itemLotId, LotItems = new() } };
                    });

                    // Add this itemLotId to the locations (second layer index)
                    var thisLocation = weaponIdLocations.FirstOrDefault(l => l.ID == itemLotId);
                    if (thisLocation == null)
                    {
                        thisLocation = new ItemLotEntry() { ID = itemLotId, LotItems = new() };
                        weaponIdLocations.Add(thisLocation);
                    }

                    // Add this ItemLotMap.lotItemId to the list of known locations
                    thisLocation.LotItems.Add(i);
                }
            }
        }

        // Save the results
        ResourceManager.SaveWeaponIdsToItemLot(ItemLotType.Map, weaponIdsToItemLotMap);

        // Also process ItemLot_enemy
        Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotEnemy = new();

        // Iterate through all known ItemLotEnemy Ids
        List<int> itemLotEnemyIds = _idToRowIndexItemLotEnemy.Keys.ToList();
        foreach (int itemLotId in itemLotEnemyIds)
        {
            // We need to check all 8 ItemLotEnemy.lotItemIds
            for (int i = 0; i < 8; i++)
            {
                // Get the itemId.
                int itemId = GetItemLotEnemyLotItemId(itemLotId, i);
                if (itemId == 0)
                {
                    continue; // If it's empty, then skip it.
                }
                int itemCategory = GetItemLotEnemyCategory(itemLotId, i);
                if (itemCategory != 2 && itemCategory != 6) // weapon or customWeapon
                {
                    continue; // If it's not a weapon, then skip it.
                }

                // Now check if this is one of our target Ids.
                if (weaponIds.Contains(itemId))
                {
                    // Add this lotItemId to the list for this itemLotId.
                    List<ItemLotEntry> weaponIdLocations = weaponIdsToItemLotEnemy.GetOrAdd(itemId, id =>
                    {
                        List<int> lotItems = new();
                        ItemLotEntry itemLotEntry = new ItemLotEntry() { ID = itemLotId, LotItems = lotItems };
                        return new List<ItemLotEntry>() { itemLotEntry };
                    });

                    // Add this itemLotId to the locations (second layer index)
                    var thisLocation = weaponIdLocations.FirstOrDefault(l => l.ID == itemLotId);
                    if (thisLocation == null)
                    {
                        thisLocation = new ItemLotEntry() { ID = itemLotId, LotItems = new() };
                        weaponIdLocations.Add(thisLocation);
                    }

                    // Add this ItemLotMap.lotItemId to the list of known locations
                    thisLocation.LotItems.Add(i);
                }
            }
        }

        // Save the results
        ResourceManager.SaveWeaponIdsToItemLot(ItemLotType.Enemy, weaponIdsToItemLotEnemy);
    }

    public void GenerateMappingGoodsIdsToShopLineup(List<int> goodsIds)
    {
        // Only work with known goodsIds
        List<int> equipGoodsIds = _idToRowIndexEquipGoods.Keys.ToList();
        foreach (int goodsId in goodsIds)
        {
            if (!equipGoodsIds.Contains(goodsId))
            {
                throw new Exception($"Unknown goodsId: {goodsId}");
            }
        }

        Dictionary<int, List<int>> goodsIdsToShopLineupMap = new();

        // Iterate through all known ShopLineup Ids
        List<int> shopLineupIds = _idToRowIndexShopLineup.Keys.ToList();
        foreach (int shopLineupId in shopLineupIds)
        {
            // Get the itemId.
            int itemId = GetShopLineupEquipId(shopLineupId);
            if (itemId == 0)
            {
                continue; // If it's 0, then just skip it.
            }
            byte itemEquipType = GetShopLineupEquipType(shopLineupId);

            if (itemEquipType != 3) // goods
            {
                continue; // If it's not a goods item, then skip it.
            }

            // Now check if this is one of our target Ids.
            if (goodsIds.Contains(itemId))
            {
                // Add this itemId to the locations
                List<int> goodsIdLocations = goodsIdsToShopLineupMap.GetOrAdd(itemId, id =>
                {
                    return new List<int>() { };
                });
                goodsIdLocations.Add(shopLineupId);
                goodsIdsToShopLineupMap[itemId] = goodsIdLocations;
            }
        }

        // Save the results
        ResourceManager.SaveGoodsIdsToShopLineup(goodsIdsToShopLineupMap);
    }

    public void GenerateMappingGoodsIdsToItemLot(List<int> goodsIds)
    {
        // Only work with known goodsIds
        List<int> equipGoodsIds = _idToRowIndexEquipGoods.Keys.ToList();
        foreach (int goodsId in goodsIds)
        {
            if (!equipGoodsIds.Contains(goodsId))
            {
                throw new Exception($"Unknown goodsId: {goodsId}");
            }
        }

        // Start with ItemLot_map
        Dictionary<int, List<ItemLotEntry>> goodsIdsToItemLotMap = new();

        // Iterate through all known ItemLotMap Ids
        List<int> itemLotMapIds = _idToRowIndexItemLotMap.Keys.ToList();
        foreach (int itemLotId in itemLotMapIds)
        {
            // We need to check all 8 ItemLotMap.lotItemIds
            for (int i = 0; i < 8; i++)
            {
                // Get the itemId.
                int itemId = GetItemLotMapLotItemId(itemLotId, i);
                if (itemId == 0)
                {
                    continue; // If it's 0, then just skip it. (Most will be 0).
                }
                int itemCategory = GetItemLotMapCategory(itemLotId, i);
                if (itemCategory != 1) // goods
                {
                    continue; // If it's not a goods item, then skip it.
                }

                // Now check if this is one of our target Ids.
                if (goodsIds.Contains(itemId))
                {
                    // Add this itemId to the locations (first layer key)
                    List<ItemLotEntry> goodsIdLocations = goodsIdsToItemLotMap.GetOrAdd(itemId, id =>
                    {
                        return new List<ItemLotEntry>() { new ItemLotEntry() { ID = itemLotId, LotItems = new() } };
                    });

                    // Add this itemLotId to the locations (second layer index)
                    var thisLocation = goodsIdLocations.FirstOrDefault(l => l.ID == itemLotId);
                    if (thisLocation == null)
                    {
                        thisLocation = new ItemLotEntry() { ID = itemLotId, LotItems = new() };
                        goodsIdLocations.Add(thisLocation);
                    }

                    // Add this ItemLotMap.lotItemId to the list of known locations
                    thisLocation.LotItems.Add(i);
                }
            }
        }

        // Save the results
        ResourceManager.SaveGoodsIdsToItemLot(ItemLotType.Map, goodsIdsToItemLotMap);

        // Also process ItemLot_enemy
        Dictionary<int, List<ItemLotEntry>> goodsIdsToItemLotEnemy = new();

        // Iterate through all known ItemLotEnemy Ids
        List<int> itemLotEnemyIds = _idToRowIndexItemLotEnemy.Keys.ToList();
        foreach (int itemLotId in itemLotEnemyIds)
        {
            // We need to check all 8 ItemLotEnemy.lotItemIds
            for (int i = 0; i < 8; i++)
            {
                // Get the itemId.
                int itemId = GetItemLotEnemyLotItemId(itemLotId, i);
                if (itemId == 0)
                {
                    continue; // If it's empty, then skip it.
                }
                int itemCategory = GetItemLotEnemyCategory(itemLotId, i);
                if (itemCategory != 1) // goods
                {
                    continue; // If it's not a goods item, then skip it.
                }

                // Now check if this is one of our target Ids.
                if (goodsIds.Contains(itemId))
                {
                    // Add this lotItemId to the list for this itemLotId.
                    List<ItemLotEntry> goodsIdLocations = goodsIdsToItemLotEnemy.GetOrAdd(itemId, id =>
                    {
                        List<int> lotItems = new();
                        ItemLotEntry itemLotEntry = new ItemLotEntry() { ID = itemLotId, LotItems = lotItems };
                        return new List<ItemLotEntry>() { itemLotEntry };
                    });

                    // Add this itemLotId to the locations (second layer index)
                    var thisLocation = goodsIdLocations.FirstOrDefault(l => l.ID == itemLotId);
                    if (thisLocation == null)
                    {
                        thisLocation = new ItemLotEntry() { ID = itemLotId, LotItems = new() };
                        goodsIdLocations.Add(thisLocation);
                    }

                    // Add this ItemLotMap.lotItemId to the list of known locations
                    thisLocation.LotItems.Add(i);
                }
            }
        }

        // Save the results
        ResourceManager.SaveGoodsIdsToItemLot(ItemLotType.Enemy, goodsIdsToItemLotEnemy);
    }
}
