// SPDX-License-Identifier: GPL-3.0-only
namespace EldenRingParamsEditor;

public partial class ParamsEditor
{
    public const int ColEventId = 3;
    private const uint graceflagOn = 6001;

    public void SetGraceEventFlagId(int graceId, uint? eventFlagId = graceflagOn)
    {
        SetValueAtCell(BonfireWarp, _idToRowIndexBonfireWarp, graceId, ColEventId, graceflagOn);
    }
}
