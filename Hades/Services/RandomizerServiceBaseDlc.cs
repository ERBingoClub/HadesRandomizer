// SPDX-License-Identifier: GPL-3.0-only
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using DotNext;
using EldenRingParamsEditor;
using Hades.Config;
using Hades.Models;
using Hades.Utilities;
using UniversalReplacementRandomizer;

namespace Hades.Services;

//Set New Enum For Veilbreak Randomized Starting Graces `VCC`
public enum BaseDlcMode
{
    Default,
    VCC,
}

public class RandomizerServiceBaseDlc
{
    private string SeedManagerPrefix;
    RandomizerServiceStartingClass randomizerServiceStartingClass = new();
    ModeService modeService = new();

    public RandomizerServiceBaseDlc(string appVersion)
    {
        SeedManagerPrefix = "basedlc" + appVersion;
    }

    //
    public void RandomizeBaseDlc(
        int? baseSeed,
        BaseDlcMode mode,
        Action<int?>? updateBaseSeedCallback,
        Action<int?>? updateRandomizedSeedCallback,
        Action<BaseDlcMode?>? updatedRandomizedModeBaseDlcCallback,
        Action<List<string>> updateGracesListCallback
    )
    {
        using DebugTimer _ = new DebugTimer("RandomizeBaseDlc");

        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInBaseDlc);
        var menuBndEditor = MenuBndEditorService.ReadFromMenuBndFilePath(
            Constants.MenuBndInBaseDlc
        );

        string seedManagerPrefix;

        switch (mode)
        {
            case BaseDlcMode.VCC:
            {
                seedManagerPrefix = SeedManagerPrefix + "_vcc";
                break;
            }
            default:
            {
                seedManagerPrefix = SeedManagerPrefix;
                break;
            }
        }

        var urr = new OptimizedReplacementRandomizer(seedManagerPrefix, baseSeed);
        if (baseSeed == null)
        {
            updateBaseSeedCallback?.Invoke(urr.GetBaseSeed());
        }

        //When the Mode is Set to VCC Randomize the Graces within the Pool
        if (mode == BaseDlcMode.VCC)
        {
            RandomizeGrace(editor, urr, updateGracesListCallback);
        }

        // Generate stats and starting equipment
        RandomizeStartingClassesBaseDlc(editor, menuBndEditor, urr);

        // Randomize weapons, spells, and incantations
        RandomizeAllGroupsBaseDlc(editor, urr);

        // Remove roundtable fist check, change Seluvis's Potion to Magic Scorpion Charm, Sentry Torch at Altus merchant
        OverrideDropsBaseDlc(editor);

        // Prevent serpent hunter from being upgraded
        DisableSerpentHunter(editor);

        // Initialize the Talisman Shop
        InitBaseDlcShop(editor);

        ModeCustomization(mode);

        editor.WriteToRegulationPath(Constants.RegulationOutBaseDlc);
        menuBndEditor.WriteToMenuBndFilePath(Constants.MenuBndOutBaseDlc);

        updateRandomizedSeedCallback?.Invoke(urr.GetBaseSeed());
        updatedRandomizedModeBaseDlcCallback?.Invoke(mode);
    }

    private void RandomizeStartingClassesBaseDlc(
        ParamsEditor editor,
        MenuBndEditorService menuBndEditor,
        OptimizedReplacementRandomizer urr
    )
    {
        using DebugTimer _ = new DebugTimer("RandomizeStartingClassesBaseDlc");

        var classStatAllocations = randomizerServiceStartingClass.GenerateAllClassStats(urr);
        var armorSetAllocations = randomizerServiceStartingClass.GenerateArmorSets(
            urr,
            $"{Constants.Misc}/basedlc/starting_classes"
        );
        var weaponSetAllocations = randomizerServiceStartingClass.GenerateWeaponSets(
            urr,
            $"{Constants.Misc}/basedlc/starting_classes"
        );

        for (int i = 0; i < ParamsEditor.TotalStartingClasses; i++)
        {
            int charaInitId = ParamsEditor.VagabondCharaInitId + i;

            // remove all starting gear, spells, etc.
            randomizerServiceStartingClass.ClearLoadout(editor, charaInitId);

            // allocate randomly generated stats
            var statAllocation = classStatAllocations[i];
            randomizerServiceStartingClass.ApplyStatAllocation(editor, charaInitId, statAllocation);
            editor.SetInitialRuneLevel(charaInitId, 9);

            // allocate randomly generated armor
            var armorAllocation = armorSetAllocations[i];
            randomizerServiceStartingClass.ApplyArmorSet(editor, charaInitId, armorAllocation);

            // allocate randomly generated weapons
            var weaponAllocation = weaponSetAllocations[i];
            randomizerServiceStartingClass.ApplyWeaponSet(editor, charaInitId, weaponAllocation);

            // get class description with all weapons/stat deficits (if any)
            string classDescription = randomizerServiceStartingClass.GenerateClassDescription(
                editor,
                armorAllocation,
                weaponAllocation,
                statAllocation
            );

            // guaranteed sorcery / staff
            if (i == 4) // astrologer
            {
                List<GameItemModel> sorceries = CsvReaderUtils.Read<GameItemModel>(
                    $"{Constants.Misc}/basedlc/starting_classes/sorceries.csv"
                );
                Random rng = urr.GetSeedManager().GetRandomByKey("starting_sorceries");
                GameItemModel sorcery = sorceries[rng.Next(sorceries.Count)];
                editor.SetInitialEquipSpell(charaInitId, 0, sorcery.ID);
                editor.SetInitialEquipWepLeft(charaInitId, 1, Constants.GlintstoneStaffItemId);
                classDescription += $", Glintstone Staff, {sorcery.Name}";
            }

            // guaranteed incantation / seal
            if (i == 5) // prophet
            {
                List<GameItemModel> incantations = CsvReaderUtils.Read<GameItemModel>(
                    $"{Constants.Misc}/basedlc/starting_classes/incantations.csv"
                );
                Random rng = urr.GetSeedManager().GetRandomByKey("starting_incantations");
                GameItemModel incantation = incantations[rng.Next(incantations.Count)];
                editor.SetInitialEquipSpell(charaInitId, 0, incantation.ID);
                editor.SetInitialEquipWepLeft(charaInitId, 1, Constants.FingerSealItemId);
                classDescription += $", Finger Seal, {incantation.Name}";
            }

            // give 10k starting runes
            editor.SetInitialRunes(charaInitId, 10_000);

            menuBndEditor.SetClassDescription(i, classDescription);
        }
    }

    public void RandomizeAllGroupsBaseDlc(ParamsEditor editor, OptimizedReplacementRandomizer urr)
    {
        var weaponIdsToItemLotMap = editor.GetWeaponIdsToItemLotMap();
        var weaponIdsToItemLotEnemy = editor.GetWeaponIdsToItemLotEnemy();
        var weaponIdsToShopLineup = editor.GetWeaponIdsToShopLineup();

        var goodsIdsToItemLotMap = editor.GetGoodsIdsToItemLotMap();
        var goodsIdsToItemLotEnemy = editor.GetGoodsIdsToItemLotEnemy();
        var goodsIdsToShopLineup = editor.GetGoodsIdsToShopLineup();

        // incantations, dragon communion incantations, sorceries
        ReplacementUtils.Randomize<GameItemModel>(
            editor,
            urr,
            $"{Constants.RandomizationGroupsBaseDlc}/spells",
            goodsIdsToItemLotMap,
            goodsIdsToItemLotEnemy,
            goodsIdsToShopLineup
        );

        // chance weapons (randomized within classes)
        ReplacementUtils.RandomizeItemLotEnemy<WeaponModel>(
            editor,
            urr,
            $"{Constants.RandomizationGroupsBaseDlc}/chance_weapons",
            weaponIdsToItemLotEnemy
        );

        // guaranteed and map weapons (randomized within classes)
        ReplacementUtils.Randomize<GameItemModel>(
            editor,
            urr,
            $"{Constants.RandomizationGroupsBaseDlc}/map_guaranteed_weapons",
            weaponIdsToItemLotMap,
            weaponIdsToItemLotEnemy,
            weaponIdsToShopLineup
        );

        // remembrance weapons
        ReplacementUtils.RandomizeAndReplaceShopLineupFile<WeaponModel>(
            editor,
            urr,
            $"{Constants.RandomizationGroupsBaseDlc}/remembrances/weapons.csv",
            weaponIdsToShopLineup
        );

        // remembrance sorceries
        ReplacementUtils.RandomizeAndReplaceShopLineupFile<WeaponModel>(
            editor,
            urr,
            $"{Constants.RandomizationGroupsBaseDlc}/remembrances/sorceries.csv",
            goodsIdsToShopLineup
        );

        // remembrance incantations
        ReplacementUtils.RandomizeAndReplaceShopLineupFile<WeaponModel>(
            editor,
            urr,
            $"{Constants.RandomizationGroupsBaseDlc}/remembrances/incantations.csv",
            goodsIdsToShopLineup
        );

        // shop weapons
        ReplacementUtils.RandomizeAndReplaceShopLineupDir<WeaponModel>(
            editor,
            urr,
            $"{Constants.RandomizationGroupsBaseDlc}/shop_weapons",
            weaponIdsToShopLineup
        );

        // override perfume bottles
        ReplacementUtils.Randomize<GameItemModel>(
            editor,
            urr,
            $"{Constants.RandomizationGroupsBaseDlc}/perfume_bottles",
            weaponIdsToItemLotMap,
            weaponIdsToItemLotEnemy,
            weaponIdsToShopLineup
        );
    }

    public void OverrideDropsBaseDlc(ParamsEditor editor)
    {
        // Remove fist check in roundtable
        int cipherPataId = 11100000;
        editor.SetItemLotMapLotItemId(cipherPataId, 0, 0);
        editor.SetItemLotMapCategory(cipherPataId, 0, 0);
        editor.SetItemLotMapItemNum(cipherPataId, 0, 0);

        // Change Seluvis's Potion to Magic Scorpion Charm
        //int seluvisPotionId = 101400;
        //int magicScorpionCharmId = 2000;
        //byte talismanCategory = 4;
        //editor.SetItemLotMapLotItemId(seluvisPotionId, 0, magicScorpionCharmId);
        //editor.SetItemLotMapCategory(seluvisPotionId, 0, talismanCategory);

        // Replace an item in Seluvis's shop with Magic Scorpion Charm
        int pidiaOldFangId = 100329;
        int magicScorpionCharmId = 2000;
        byte talismanEquipType = 2;
        uint magicScorpionAcquisitionFlag = 400141;
        short sellQuantity = 1;
        int sellPrice = 5000;
        editor.SetShopLineupEquipId(pidiaOldFangId, magicScorpionCharmId);
        editor.SetShopLineupEquipType(pidiaOldFangId, talismanEquipType);
        editor.SetShopLineupEventFlagForStock(pidiaOldFangId, magicScorpionAcquisitionFlag);
        editor.SetShopLineupSellQuantity(pidiaOldFangId, sellQuantity);
        editor.SetShopLineupSellPrice(pidiaOldFangId, sellPrice);

        // Remove Somber Ancient Dragon Smithing Stone from Mohgwyn
        //int mohgwynSomberStone = 12050900;
        //editor.SetItemLotMapLotItemId(mohgwynSomberStone, 0, 0);
        //editor.SetItemLotMapCategory(mohgwynSomberStone, 0, 0);
    }

    private void InitBaseDlcShop(ParamsEditor editor)
    {
        using DebugTimer _ = new DebugTimer("InitBaseDlcShop");

        List<ShopItemModel> shopItems = CsvReaderUtils.Read<ShopItemModel>(
            $"{Constants.Misc}/basedlc/shop_talismans.csv"
        );

        // Setup the Runes shop.
        int currentShopLineupId = 9300000;
        uint currentEventFlagID = 1056448000;
        uint eventFlagStepSize = 10;
        for (int i = 0; i < shopItems.Count; i++)
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Bernie Bingo - {shopItems[i].Type}] {shopItems[i].Name}";
            int equipID = shopItems[i].ID;
            byte equipType = shopItems[i].EquipType;
            int sellPrice = shopItems[i].Cost;
            short sellQuantity = shopItems[i].SellQuantity;
            uint eventFlagForQuantity;
            if (shopItems[i].EventFlagID == null)
            {
                eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
            }
            else
            {
                eventFlagForQuantity = (uint)shopItems[i].EventFlagID!;
            }
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipType);
            editor.SetShopLineupSellPrice(shopLineupId, sellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, sellQuantity);
        }
    }

    public void DisableSerpentHunter(ParamsEditor editor)
    {
        int serpentHunterId = 17030000;

        editor.SetEquipWeaponIsCustom(serpentHunterId, 0);
        editor.SetEquipWeaponMaterialSetId(serpentHunterId, 0);
        editor.SetEquipWeaponReinforceTypeId(serpentHunterId, 3000);
        editor.SetEquipWeaponReinforceShopCategory(serpentHunterId, 0);
    }

    private void ModeCustomization(BaseDlcMode mode)
    {
        // Events (default vs VCC)
        string eventPath = Path.Combine(Constants.MenuBndOutBaseDlcVCC, "event");
        string eventDefaultPath = Path.Combine(Constants.ModeFolders, "event_basedlc");
        string eventVCCPath = Path.Combine(Constants.ModeFolders, "event_vcc");

        modeService.UpdateFolder(
            targetPath: eventPath,
            sourcePath: mode == BaseDlcMode.VCC ? eventVCCPath : eventDefaultPath
        );
    }

    public void RandomizeGrace(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        Action<List<string>> setRandomizedGraces
    )
    {
        List<string> selectedGraceNames = new();

        // Limgrave: pick 1 from Limgrave1 and 1 from Limgrave2
        //61423600, // Church of Elleh
        //61423601, // First Step
        {
            Random rng = urr.GetSeedManager().GetRandomByKey("grace_Limgrave");

            List<GracePoolModel> aPool = GracePools["Limgrave1"];
            List<GracePoolModel> bPool = GracePools["Limgrave2"];

            GracePoolModel first = aPool[rng.Next(aPool.Count)];

            GracePoolModel second;
            int guard = 0;

            do
            {
                second = bPool[rng.Next(bPool.Count)];
                guard++;
            } while (second.ID == first.ID && guard < 100);

            editor.SetGraceEventFlagId(first.ID);
            editor.SetGraceEventFlagId(second.ID);

            selectedGraceNames.Add(first.GraceName);
            selectedGraceNames.Add(second.GraceName);
        }

        // Liurnia: Pick 2 out of North+South or East+West
        {
            Random rng = urr.GetSeedManager().GetRandomByKey("grace_Liurnia");

            bool useNorthSouth = rng.Next(2) == 0;

            List<GracePoolModel> aPool = useNorthSouth
                ? GracePools["Liurnia_North"]
                : GracePools["Liurnia_East"];

            List<GracePoolModel> bPool = useNorthSouth
                ? GracePools["Liurnia_South"]
                : GracePools["Liurnia_West"];

            GracePoolModel first = aPool[rng.Next(aPool.Count)];

            GracePoolModel second;
            int guard = 0;

            do
            {
                second = bPool[rng.Next(bPool.Count)];
                guard++;
            } while (second.ID == first.ID && guard < 100);

            editor.SetGraceEventFlagId(first.ID);
            editor.SetGraceEventFlagId(second.ID);

            selectedGraceNames.Add(first.GraceName);
            selectedGraceNames.Add(second.GraceName);
        }

        // All other pools: pick 1 each
        foreach (var (poolName, pool) in GracePools)
        {
            if (poolName == "Limgrave1")
                continue;
            if (poolName == "Limgrave2")
                continue;

            if (poolName.StartsWith("Liurnia_"))
                continue;

            Random rng = urr.GetSeedManager().GetRandomByKey($"grace_{poolName}");

            GracePoolModel selectedGrace = pool[rng.Next(pool.Count)];

            editor.SetGraceEventFlagId(selectedGrace.ID);

            selectedGraceNames.Add(selectedGrace.GraceName);
        }

        setRandomizedGraces(selectedGraceNames);
    }

    private static readonly Dictionary<string, List<GracePoolModel>> GracePools = CsvReaderUtils
        .Read<GracePoolModel>(Path.Combine(Constants.Misc, "basedlc", "grace_pools.csv"))
        .GroupBy(x => x.GraceRegion)
        .ToDictionary(g => g.Key, g => g.ToList());
}
