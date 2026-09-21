// SPDX-License-Identifier: GPL-3.0-only

namespace EldenRingParamsEditor;

public partial class ParamsEditor
{
    public const int ColIndexResidentSpEffectId = 13;

    public int GetEquipProtectorResidentSpEffectId(int equipProtectorId)
    {
        return (int) GetValueAtCell(EquipProtector, _idToRowIndexEquipProtector, equipProtectorId, ColIndexResidentSpEffectId);
    }
}
