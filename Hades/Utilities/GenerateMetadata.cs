// SPDX-License-Identifier: GPL-3.0-only
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Models;
using EldenRingParamsEditor;
using Hades.Config;

namespace Hades.Utilities;

public class MetadataUtils
{
    public static void GenerateWeaponsMappings(ParamsEditor editor)
    {
        List<GameItemModel> weapons = CsvReaderUtils.Read<GameItemModel>(
            $"{Constants.GameData}/AllWeapons.csv"
        );
        List<int> weaponIds = new();
        foreach (GameItemModel weapon in weapons)
        {
            weaponIds.Add(weapon.ID);
        }
        List<CustomWeaponModel> customWeapons = CsvReaderUtils.Read<CustomWeaponModel>(
            $"{Constants.GameData}/AllCustomWeapons.csv"
        );
        List<int> customWeaponIds = new();
        foreach (CustomWeaponModel customWeapon in customWeapons)
        {
            customWeaponIds.Add(customWeapon.ID);
        }
        List<int> allWeaponIds = weaponIds.Concat(customWeaponIds).ToList();
        editor.GenerateMappingWeaponIdsToItemLot(allWeaponIds);
        editor.GenerateMappingWeaponIdsToShopLineup(allWeaponIds);
    }

    public static void GenerateSpellsMappings(ParamsEditor editor)
    {
        List<GameItemModel> spells = CsvReaderUtils.Read<GameItemModel>(
            $"{Constants.GameData}/AllSpells.csv"
        );
        List<int> allSpellIds = new();
        foreach (GameItemModel spell in spells)
        {
            allSpellIds.Add(spell.ID);
        }
        editor.GenerateMappingGoodsIdsToItemLot(allSpellIds);
        editor.GenerateMappingGoodsIdsToShopLineup(allSpellIds);
    }
}
