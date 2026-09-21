// SPDX-License-Identifier: GPL-3.0-only
using Andre.Formats;

namespace EldenRingParamsEditor;

public partial class ParamsEditor
{
    public const int ColIndexEquipId = 0;
    public const int ColIndexSellPrice = 1;
    public const int ColIndexMaterialId = 2;
    public const int ColIndexEventFlagForStock = 3;
    public const int ColIndexEventFlagForRelease = 4;
    public const int ColIndexSellQuantity = 5;
    public const int ColIndexEquipType = 7;
    public const int ColIndexCostType = 8;
    public const int ColIndexNumSold = 10;
    public const int ColIndexValueAdd = 11;
    public const int ColIndexValueMagnification = 12;
    public const int ColIndexIconId = 13;
    public const int ColIndexTextId = 14;
    public const int ColIndexMenuTextId = 15;
    public const int ColIndexMenuIconId = 16;

    public void CreateNewShopLineupRow(int shopLineupId, string? name = "")
    {
        // clone the first row. this is necessary because we can only add a row to the param if it has it as a parent
        Param.Row newRow = new(ShopLineup.Rows.ElementAt(0));
        newRow.ID = shopLineupId;
        newRow.Name = name;
        _idToRowIndexShopLineup!.Add(shopLineupId, ShopLineup.Rows.Count);
        ShopLineup.AddRow(newRow);
        // Reset values to default (this row just has these three non-default values)
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEquipId, 0);
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEquipType, (byte)0);
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexSellPrice, 0);
    }

    public int GetShopLineupEquipId(int shopLineupId)
    {
        return (int) GetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEquipId);
    }

    public byte GetShopLineupEquipType(int shopLineupId)
    {
        return (byte) GetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEquipType);
    }

    public void SetShopLineupEquipId(int shopLineupId, int equipId)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEquipId, equipId);
    }

    public void SetShopLineupSellPrice(int shopLineupId, int sellPrice)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexSellPrice, sellPrice);
    }

    public void SetShopLineupMaterialId(int shopLineupId, int materialId)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexMaterialId, materialId);
    }

    public void SetShopLineupEventFlagForStock(int shopLineupId, uint eventFlag)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEventFlagForStock, eventFlag);
    }

    public void SetShopLineupEventFlagForRelease(int shopLineupId, uint eventFlag)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEventFlagForRelease, eventFlag);
    }

    public void SetShopLineupSellQuantity(int shopLineupId, short sellQuantity)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexSellQuantity, sellQuantity);
    }

    public void SetShopLineupEquipType(int shopLineupId, byte equipType)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEquipType, equipType);
    }

    public void SetShopLineupCostType(int shopLineupId, byte costType)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexCostType, costType);
    }

    public void SetShopLineupNumSold(int shopLineupId, ushort numSold)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexNumSold, numSold);
    }

    public void SetShopLineupValueAdd(int shopLineupId, int valueAdd)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexValueAdd, valueAdd);
    }

    public void SetShopLineupValueMagnification(int shopLineupId, float valueMagnification)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexValueMagnification, valueMagnification);
    }

    public void SetShopLineupIconId(int shopLineupId, int iconId)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexIconId, iconId);
    }

    public void SetShopLineupTextId(int shopLineupId, int textId)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexTextId, textId);
    }

    public void SetShopLineupMenuTextId(int shopLineupId, int textId)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexMenuTextId, textId);
    }

    public void SetShopLineupMenuIconId(int shopLineupId, int iconId)
    {
        SetValueAtCell(ShopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexMenuIconId, iconId);
    }
}
