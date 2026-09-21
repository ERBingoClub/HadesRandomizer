// SPDX-License-Identifier: GPL-3.0-only

namespace EldenRingParamsEditor;

public partial class ParamsEditor
{
    public int GetItemLotMapLotItemId(int itemLotId, int itemIndex)
    {
        if (itemIndex < 0 || itemIndex > 7)
        {
            throw new Exception($"Index {itemIndex} out of bounds.");
        }
        return (int) GetValueAtCell(ItemLotMap, _idToRowIndexItemLotMap, itemLotId, ColIndexLotItemId + itemIndex);
    }

    public int GetItemLotMapCategory(int itemLotId, int itemIndex)
    {
        if (itemIndex < 0 || itemIndex > 7)
        {
            throw new Exception($"Index {itemIndex} out of bounds.");
        }
        return (int) GetValueAtCell(ItemLotMap, _idToRowIndexItemLotMap, itemLotId, ColIndexCategory + itemIndex);
    }

    public byte GetItemLotMapItemNum(int itemLotId, int itemIndex)
    {
        if (itemIndex < 0 || itemIndex > 7)
        {
            throw new Exception($"Index {itemIndex} out of bounds.");
        }
        return (byte)GetValueAtCell(ItemLotMap, _idToRowIndexItemLotMap, itemLotId, ColIndexItemNum + itemIndex);
    }

    public void SetItemLotMapLotItemId(int itemLotId, int itemIndex, int itemId)
    {
        if (itemIndex < 0 || itemIndex > 7)
        {
            throw new Exception($"Index {itemIndex} out of bounds.");
        }
        SetValueAtCell(ItemLotMap, _idToRowIndexItemLotMap, itemLotId, ColIndexLotItemId + itemIndex, itemId);
    }

    public void SetItemLotMapCategory(int itemLotId, int itemIndex, int category)
    {
        if (itemIndex < 0 || itemIndex > 7)
        {
            throw new Exception($"Index {itemIndex} out of bounds.");
        }
        SetValueAtCell(ItemLotMap, _idToRowIndexItemLotMap, itemLotId, ColIndexCategory + itemIndex, category);
    }

    public void SetItemLotMapItemNum(int itemLotId, int itemIndex, byte itemNum)
    {
        if (itemIndex < 0 || itemIndex > 7)
        {
            throw new Exception($"Index {itemIndex} out of bounds.");
        }
        SetValueAtCell(ItemLotMap, _idToRowIndexItemLotMap, itemLotId, ColIndexItemNum + itemIndex, itemNum);
    }
}
