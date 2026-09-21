// SPDX-License-Identifier: GPL-3.0-only

namespace EldenRingParamsEditor;

public partial class ParamsEditor
{
    // 88 = 10
    // 317 = 40
    // 465 = 60
    // 678 = 90
    // 1018 = 140
    // 1299 = 180
    // 1738 = 240
    // 2048 = 280
    // 2215 = 300
    // 2313 = 313
    public const int ColIndexAddVigor = 314;
    public const int ColIndexAddMind = 315;
    public const int ColIndexAddEndurance = 316;
    public const int ColIndexAddStrength = 318;
    public const int ColIndexAddDexterity = 319;
    public const int ColIndexAddIntelligence = 320;
    public const int ColIndexAddFaith = 321;
    public const int ColIndexAddArcane = 322;
    public static readonly int[] ColIndexStats = { ColIndexAddVigor,
                                                   ColIndexAddMind,
                                                   ColIndexAddEndurance,
                                                   ColIndexAddStrength,
                                                   ColIndexAddDexterity,
                                                   ColIndexAddIntelligence,
                                                   ColIndexAddFaith,
                                                   ColIndexAddArcane };

    public sbyte GetSpEffectAddStat(int spEffectId, int stat)
    {
        return (sbyte) GetValueAtCell(SpEffect, _idToRowIndexSpEffect, spEffectId, ColIndexStats[stat]);
    }
    
    public sbyte GetSpEffectAddVigor(int spEffectId)
    {
        return (sbyte) GetValueAtCell(SpEffect, _idToRowIndexSpEffect, spEffectId, ColIndexAddVigor);
    }

    public sbyte GetSpEffectAddMind(int spEffectId)
    {
        return (sbyte) GetValueAtCell(SpEffect, _idToRowIndexSpEffect, spEffectId, ColIndexAddMind);
    }

    public sbyte GetSpEffectAddEndurance(int spEffectId)
    {
        return (sbyte) GetValueAtCell(SpEffect, _idToRowIndexSpEffect, spEffectId, ColIndexAddEndurance);
    }

    public sbyte GetSpEffectAddStrength(int spEffectId)
    {
        return (sbyte) GetValueAtCell(SpEffect, _idToRowIndexSpEffect, spEffectId, ColIndexAddStrength);
    }

    public sbyte GetSpEffectAddDexterity(int spEffectId)
    {
        return (sbyte) GetValueAtCell(SpEffect, _idToRowIndexSpEffect, spEffectId, ColIndexAddDexterity);
    }

    public sbyte GetSpEffectAddIntelligence(int spEffectId)
    {
        return (sbyte) GetValueAtCell(SpEffect, _idToRowIndexSpEffect, spEffectId, ColIndexAddIntelligence);
    }

    public sbyte GetSpEffectAddFaith(int spEffectId)
    {
        return (sbyte) GetValueAtCell(SpEffect, _idToRowIndexSpEffect, spEffectId, ColIndexAddFaith);
    }

    public sbyte GetSpEffectAddArcane(int spEffectId)
    {
        return (sbyte) GetValueAtCell(SpEffect, _idToRowIndexSpEffect, spEffectId, ColIndexAddArcane);
    }
}
