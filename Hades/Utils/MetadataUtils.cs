using EldenRingParamsEditor;
using Hades.Constants;

namespace Hades.Utils;

public static class MetadataUtils
{
    public static void GenerateWeaponsMappings(ParamsEditor editor)
    {
        var allWeaponIds = Weapons.RemembranceWeapons
            .Select(w => w.Id)
            .Concat(Weapons.GuaranteedWeapons.Select(w => w.Id))
            .Concat(Weapons.ChanceWeapons.Select(w => w.Id))
            .Distinct()
            .ToList();

        editor.GenerateMappingWeaponIdsToItemLot(allWeaponIds);
        editor.GenerateMappingWeaponIdsToShopLineup(allWeaponIds);
    }

    public static void GenerateSpellsMappings(ParamsEditor editor)
    {
        var allSpellIds = Spells.AllSpells
            .Select(s => s.Id)
            .Distinct()
            .ToList();

        editor.GenerateMappingGoodsIdsToItemLot(allSpellIds);
        editor.GenerateMappingGoodsIdsToShopLineup(allSpellIds);
    }

    public static void GenerateAllMappings(ParamsEditor editor)
    {
        GenerateWeaponsMappings(editor);
        GenerateSpellsMappings(editor);
    }
}
