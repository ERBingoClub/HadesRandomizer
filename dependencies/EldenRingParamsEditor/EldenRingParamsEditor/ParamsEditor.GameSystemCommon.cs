// SPDX-License-Identifier: GPL-3.0-only

namespace EldenRingParamsEditor;

public partial class ParamsEditor
{
    public const int DefaultScadutreeBlessingLevel = 20000100;
    public const int BaseScadutreeBlessingLevel = 331;
    public const int BaseReveredSpiritAshLevel = 332;

    public object GetBaseScadutreeBlessingLevel()
    {
        return GetValueAtCell(GameSystemCommon, null, 0, BaseScadutreeBlessingLevel);
    }

    public void SetBaseScadutreeBlessingLevel(int baseScadutreeBlessingLevel)
    {
        int value = DefaultScadutreeBlessingLevel + baseScadutreeBlessingLevel;
        SetValueAtCell(GameSystemCommon, null, 0, BaseScadutreeBlessingLevel, value);
    }
}
