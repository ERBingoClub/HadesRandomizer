// SPDX-License-Identifier: GPL-3.0-only
using System.Diagnostics;
using System.IO;
using EldenRingParamsEditor;
using Hades.Config;
using Hades.Models;
using Hades.Utilities;
using UniversalReplacementRandomizer;

namespace Hades.Services;

public enum DlcMode
{
    Default,
    Moonwalk,
    Omenveil,
    Anamnesis,
    Eldensquares,
}

public class RandomizerServiceDlc
{
    private string SeedManagerPrefix;
    private const int StarlightShopMenuTextId = 508000;

    ModeService modeService = new();
    private RandomizerServiceStartingClass randomizerServiceStartingClass = new();
    RandomizerServiceStartingClass.ClassStatAllocation startingStats;
    private int[] anamnesisStarlightWeapons;

    // Weapons that are in the Starlight Shard Shop
    List<string> weaponsInTheStarlightShop = new List<string>();

    // Using this property for the UI
    public List<string> WeaponsInTheStarlightShop => weaponsInTheStarlightShop;

    public RandomizerServiceDlc(string appVersion)
    {
        SeedManagerPrefix = "dlc" + appVersion;
        startingStats = new(Stats: new int[] { 50, 10, 10, 10, 10, 10, 10, 10 });
        anamnesisStarlightWeapons = new int[] { 0, 0, 0, 0 };
    }

    public void RandomizeDlc(
        int? baseSeed,
        DlcMode mode,
        Action<int?>? updateBaseSeedCallback,
        Action<int?>? updateRandomizedSeedCallback,
        Action<DlcMode?>? updateRandomizedModeDlcCallback,
        Action<List<string>>? updateWeaponsListCallback
    )
    {
        using DebugTimer _ = new DebugTimer("RandomizeDlc");
        //SimulationUtils.SimulateDlcToFile(10_000);

        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInDlc);

        //MetadataUtils.GenerateWeaponsMappings(editor);
        //MetadataUtils.GenerateSpellsMappings(editor);

        string seedManagerPrefix;
        string randomizationGroupsDirPath;

        switch (mode)
        {
            case DlcMode.Moonwalk:
            {
                seedManagerPrefix = SeedManagerPrefix + "_moonwalk";
                randomizationGroupsDirPath = $"{Constants.RandomizationGroupsDlc}/moonwalk";
                break;
            }
            case DlcMode.Omenveil:
            {
                seedManagerPrefix = SeedManagerPrefix + "_omenveil";
                randomizationGroupsDirPath = $"{Constants.RandomizationGroupsDlc}/omenveil";
                break;
            }
            case DlcMode.Anamnesis:
            {
                seedManagerPrefix = SeedManagerPrefix + "_anamnesis";
                randomizationGroupsDirPath = $"{Constants.RandomizationGroupsDlc}/anamnesis";
                break;
            }
            case DlcMode.Eldensquares:
            {
                seedManagerPrefix = SeedManagerPrefix + "_eldensquares";
                randomizationGroupsDirPath = $"{Constants.RandomizationGroupsDlc}/eldensquares";
                break;
            }
            default:
            {
                seedManagerPrefix = SeedManagerPrefix;
                randomizationGroupsDirPath = $"{Constants.RandomizationGroupsDlc}/default";
                break;
            }
        }

        var urr = new OptimizedReplacementRandomizer(seedManagerPrefix, baseSeed);
        if (baseSeed == null)
        {
            updateBaseSeedCallback?.Invoke(urr.GetBaseSeed());
        }

        InitStartingClassesDlc(editor, mode);

        InitDlcShop(editor, urr, mode);

        if (mode == DlcMode.Anamnesis)
        {
            InitAnamnesisRemembrances(editor, urr);
        }

        Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotMap =
            editor.GetWeaponIdsToItemLotMap();
        Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotEnemy =
            editor.GetWeaponIdsToItemLotEnemy();
        Dictionary<int, List<int>> weaponIdsToShopLineup = editor.GetWeaponIdsToShopLineup();

        ReplacementUtils.Randomize<GameItemModel>(
            editor,
            urr,
            randomizationGroupsDirPath,
            weaponIdsToItemLotMap,
            weaponIdsToItemLotEnemy,
            weaponIdsToShopLineup
        );

        // Equip Millicent's Armor
        EquipMillicentsArmor(editor, mode);

        // Disable Upgrading the default club
        DisableUpgradingClub(editor);

        ModeCustomization(mode);

        editor.WriteToRegulationPath(Constants.RegulationOutDlc);

        updateRandomizedSeedCallback?.Invoke(urr.GetBaseSeed());
        updateRandomizedModeDlcCallback?.Invoke(mode);
        updateWeaponsListCallback?.Invoke(weaponsInTheStarlightShop);
    }

    private void InitStartingClassesDlc(ParamsEditor editor, DlcMode mode = DlcMode.Default)
    {
        using DebugTimer _ = new DebugTimer("InitStartingClassesDlc");

        int NumberOfStartingRunes = 100_000;

        int ClubItemId = 11010000;
        int GlintstoneStaffItemId;
        int FingerSealItemId = Constants.FingerSealItemId + 25;

        switch (mode)
        {
            case DlcMode.Moonwalk:
            {
                // Custom Carian Sorcery Sword (has no ash of war, does 0 damage with regular attacks)
                GlintstoneStaffItemId = 70000000 + 25;
                break;
            }
            case DlcMode.Omenveil:
            {
                // default
                GlintstoneStaffItemId = Constants.GlintstoneStaffItemId + 25;
                // Custom Crucible Seal (no stats requirement, otherwise indistinguishable from erdtree seal)
                FingerSealItemId = 70010000 + 10;
                break;
            }
            case DlcMode.Anamnesis:
            {
                // default
                GlintstoneStaffItemId = 33090000 + 10; //Carian Regal Scepter
                startingStats = new(Stats: new int[] { 40, 10, 10, 10, 10, 10, 10, 10 });
                break;
            }
            case DlcMode.Eldensquares:
            {
                // default
                GlintstoneStaffItemId = Constants.GlintstoneStaffItemId + 25;
                startingStats = new(Stats: new int[] { 40, 10, 10, 10, 10, 10, 10, 10 });
                break;
            }
            default:
            {
                GlintstoneStaffItemId = Constants.GlintstoneStaffItemId + 25;
                break;
            }
        }

        for (int i = 0; i < ParamsEditor.TotalStartingClasses; i++)
        {
            int charaInitId = ParamsEditor.VagabondCharaInitId + i;

            // clear all starting gear, spells, etc.
            randomizerServiceStartingClass.ClearLoadout(editor, charaInitId);

            // set starting stats
            randomizerServiceStartingClass.ApplyStatAllocation(editor, charaInitId, startingStats);
            editor.SetInitialRuneLevel(charaInitId, 1);

            // give initial weapons (club +0, staff +25, seal +25)
            editor.SetInitialEquipWepRight(charaInitId, 0, ClubItemId);
            editor.SetInitialEquipWepLeft(charaInitId, 0, GlintstoneStaffItemId);
            editor.SetInitialEquipWepLeft(charaInitId, 1, FingerSealItemId);

            // initial runes and flasks
            editor.SetInitialRunes(charaInitId, NumberOfStartingRunes);
            editor.SetInitialMaxHpFlasks(charaInitId, 12);
            editor.SetInitialMaxFpFlasks(charaInitId, 2);

            if (mode == DlcMode.Moonwalk)
            {
                // Give initial sorceries/incantations
                editor.SetInitialEquipSpell(charaInitId, 0, 4431); // adula's moonblade
            }
            else if (mode == DlcMode.Omenveil)
            {
                // Give initial tools
                editor.SetInitialEquipItem(charaInitId, 0, 3011); // regal omen bairn
                editor.SetInitialEquipItemAmount(charaInitId, 0, 1);

                editor.SetInitialEquipItem(charaInitId, 1, 2150); // mohg's shackle
                editor.SetInitialEquipItemAmount(charaInitId, 1, 1);

                editor.SetInitialEquipItem(charaInitId, 2, 260000); // dung eater puppet
                editor.SetInitialEquipItemAmount(charaInitId, 2, 1);

                // give incants
                editor.SetInitialEquipSpell(charaInitId, 0, 7500); // tail
                editor.SetInitialEquipSpell(charaInitId, 1, 7510); // horns
                editor.SetInitialEquipSpell(charaInitId, 2, 7520); // breath
            }
            else if (mode == DlcMode.Anamnesis)
            {
                editor.SetInitialMaxHpFlasks(charaInitId, 6);
                editor.SetInitialMaxFpFlasks(charaInitId, 1);
            }
            else if (mode == DlcMode.Eldensquares)
            {
                editor.SetInitialMaxHpFlasks(charaInitId, 6);
                editor.SetInitialMaxFpFlasks(charaInitId, 1);
            }
        }
    }

    private void InitDlcShop(
        ParamsEditor editor,
        OptimizedReplacementRandomizer urr,
        DlcMode mode = DlcMode.Default
    )
    {
        using DebugTimer _ = new DebugTimer("InitDlcShop");

        string shopItemsFilePath = $"{Constants.Misc}/dlc/shop_items.csv";
        string shopArmorSetsFilePath;
        string shopWeaponsFilePath;
        Random random = new Random();

        int baseSeed = urr.GetBaseSeed();
        SeedManager seedManager = new SeedManager(SeedManagerPrefix, baseSeed); // Moved earlier so tier selection uses the shared seed manager

        switch (mode)
        {
            case DlcMode.Moonwalk:
            {
                shopArmorSetsFilePath = $"{Constants.Misc}/dlc/moonwalk/shop_armor_sets.csv";
                shopWeaponsFilePath = $"{Constants.Misc}/dlc/moonwalk/shop_weapons.csv";
                break;
            }
            case DlcMode.Omenveil:
            {
                shopItemsFilePath = $"{Constants.Misc}/dlc/omenveil/shop_items.csv";
                shopArmorSetsFilePath = $"{Constants.Misc}/dlc/omenveil/shop_armor_sets.csv";
                shopWeaponsFilePath = $"{Constants.Misc}/dlc/omenveil/shop_weapons.csv";
                break;
            }
            case DlcMode.Anamnesis:
            {
                shopItemsFilePath = $"{Constants.Misc}/dlc/anamnesis/shop_items.csv";
                shopArmorSetsFilePath = $"{Constants.Misc}/dlc/anamnesis/shop_armor_sets.csv";
                shopWeaponsFilePath = $"{Constants.Misc}/dlc/anamnesis/shop_weapons.csv";
                break;
            }
            case DlcMode.Eldensquares:
            {
                Random tierRng = seedManager.GetRandomByKey("StartingTier");
                int somberOrSmithingWeapon = tierRng.Next(0, 2);

                bool isSmithing = tierRng.Next(0, 2) == 0;

                shopWeaponsFilePath = isSmithing
                    ? $"{Constants.Misc}/dlc/eldensquares/shop_weapons_smithing.csv"
                    : $"{Constants.Misc}/dlc/eldensquares/shop_weapons_somber.csv";

                /*
                //int tier = tierRng.Next(1, 4);
                
                // This will be Smithing
                if (somberOrSmithingWeapon == 0)
                {
                    shopWeaponsFilePath = $"{Constants.Misc}/dlc/eldensquares/shop_weapons_smithing_tier_{tier}.csv";
                }
                //This will be Somber
                else
                {
                    shopWeaponsFilePath = $"{Constants.Misc}/dlc/eldensquares/shop_weapons_somber_tier_{tier}.csv";
                }
                */

                shopItemsFilePath = $"{Constants.Misc}/dlc/eldensquares/shop_items.csv";
                shopArmorSetsFilePath = $"{Constants.Misc}/dlc/eldensquares/shop_armor_sets.csv";
                break;
            }
            default:
            {
                shopArmorSetsFilePath = $"{Constants.Misc}/dlc/default/shop_armor_sets.csv";
                shopWeaponsFilePath = $"{Constants.Misc}/dlc/default/shop_weapons.csv";
                break;
            }
        }

        List<ShopItemModel> shopItems = CsvReaderUtils.Read<ShopItemModel>(shopItemsFilePath);

        // Setup the Runes shop.
        int currentShopLineupId = 9100000;
        uint currentEventFlagID = 1056447000;
        uint eventFlagStepSize = 10;
        for (int i = 0; i < shopItems.Count; i++)
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - {shopItems[i].Type}] {shopItems[i].Name}";
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

        // Setup the randomized armor set in the runes shop.
        List<ArmorSetModel> armorGroup = CsvReaderUtils.Read<ArmorSetModel>(shopArmorSetsFilePath);
        Random rng = seedManager.GetRandomByKey("armor_sets.csv");

        byte armorEquipType = 1;
        short armorSellQuantity = 1;
        int helmSellPrice = 0;
        int torsoSellPrice = 0;
        int gauntletsSellPrice = 0;
        int greavesSellPrice = 0;

        int armorSetCount = mode == DlcMode.Eldensquares ? 2 : 1;

        for (int i = 0; i < armorSetCount; i++)
        {
            ArmorSetModel armor = armorGroup[rng.Next(armorGroup.Count)];
            if (armor.HelmID != null)
            {
                int shopLineupId = currentShopLineupId++;
                string name = $"[Merchant Millicent - Armor] {armor.Name} Helm";
                int equipID = (int)armor.HelmID;
                uint eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
                editor.CreateNewShopLineupRow(shopLineupId, name);
                editor.SetShopLineupEquipId(shopLineupId, equipID);
                editor.SetShopLineupEquipType(shopLineupId, armorEquipType);
                editor.SetShopLineupSellPrice(shopLineupId, helmSellPrice);
                editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
                editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
            }
            if (armor.TorsoID != null)
            {
                int shopLineupId = currentShopLineupId++;
                string name = $"[Merchant Millicent - Armor] {armor.Name} Torso";
                int equipID = (int)armor.TorsoID;
                uint eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
                editor.CreateNewShopLineupRow(shopLineupId, name);
                editor.SetShopLineupEquipId(shopLineupId, equipID);
                editor.SetShopLineupEquipType(shopLineupId, armorEquipType);
                editor.SetShopLineupSellPrice(shopLineupId, torsoSellPrice);
                editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
                editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
            }
            if (armor.GauntletsID != null)
            {
                int shopLineupId = currentShopLineupId++;
                string name = $"[Merchant Millicent - Armor] {armor.Name} Gauntlets";
                int equipID = (int)armor.GauntletsID;
                uint eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
                editor.CreateNewShopLineupRow(shopLineupId, name);
                editor.SetShopLineupEquipId(shopLineupId, equipID);
                editor.SetShopLineupEquipType(shopLineupId, armorEquipType);
                editor.SetShopLineupSellPrice(shopLineupId, gauntletsSellPrice);
                editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
                editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
            }
            if (armor.GreavesID != null)
            {
                int shopLineupId = currentShopLineupId++;
                string name = $"[Merchant Millicent - Armor] {armor.Name} Greaves";
                int equipID = (int)armor.GreavesID;
                uint eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
                editor.CreateNewShopLineupRow(shopLineupId, name);
                editor.SetShopLineupEquipId(shopLineupId, equipID);
                editor.SetShopLineupEquipType(shopLineupId, armorEquipType);
                editor.SetShopLineupSellPrice(shopLineupId, greavesSellPrice);
                editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
                editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
            }
        }

        // Setup the Starlight Shards shop.
        byte starlightShardCostType = 2;
        short starlightWeaponSellQuantity = 1;
        ushort starlightWeaponNumSold;

        int currentCustomWeaponId = 9600069;
        currentShopLineupId = 9200000;
        currentEventFlagID = 1056457000;

        //int numberOfShopWeapons = mode == DlcMode.Anamnesis ? 4 : 3;

        int starlightWeaponCost = mode == DlcMode.Eldensquares ? 3 : 5;

        // Change for the different DLC modes for Bingo. Determines on how many weapons are in the shop.
        int numberOfShopWeapons = mode switch
        {
            DlcMode.Anamnesis => 4,
            DlcMode.Eldensquares => 4,
            _ => 3,
        };

        int GraftedDragonItemId = 21060009;
        int SerpentFlailItemId = 13500009;
        int PolebladeBudItemId = 18510009;
        int FlowerstoneGavelId = 11500009;

        // Setup the randomized weapons in the Starlight Shards shop.
        // The Starlight Shards shop may share weapons from the common pool (there can be duplicates if the csv has duplicates)
        // If mode is Eldensquares, it generates a window from the weapon pool and then picks weapons from window instead of whole csv.

        List<GameItemModel> starlightWeapons;

        if (mode == DlcMode.Eldensquares)
        {
            List<GameItemModel> fullWeaponPool = CsvReaderUtils.Read<GameItemModel>(
                shopWeaponsFilePath
            );

            Random windowRng = seedManager.GetRandomByKey("WeaponWindow");

            // This determines the window of weapons picked.
            int windowSize = 7;
            int maxStartIndex = fullWeaponPool.Count - windowSize;
            int startIndex = windowRng.Next(0, maxStartIndex + 1);

            starlightWeapons = fullWeaponPool.Skip(startIndex).Take(windowSize).ToList();
        }
        else
        {
            starlightWeapons = CsvReaderUtils.Read<GameItemModel>(shopWeaponsFilePath);
        }

        OptimizedRandomizationGroup merchantMillicentWeapons = new(
            numberOfShopWeapons,
            starlightWeapons.Count
        );
        urr.AddGroup("merchantMillicentWeapons", merchantMillicentWeapons);
        int[] replacementIndexes = urr.RandomizeGroup("merchantMillicentWeapons");
        weaponsInTheStarlightShop = new List<string>();

        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            int shopLineupId = currentShopLineupId++;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;

            GameItemModel weapon = starlightWeapons[replacementIndexes[i]];
            int replacementEquipID = weapon.ID;
            int equipID = weapon.ID;

            if (mode == DlcMode.Anamnesis)
            {
                anamnesisStarlightWeapons[i] = equipID;
            }

            // Set reinforce level differently depending on if the weapon is custom or not
            if (weapon.EquipType == 5)
            {
#if DEBUG
                Debug.WriteLine("Custom weapon detected in shop");
#endif
                equipID = currentCustomWeaponId;

                int baseEquipID = editor.GetEquipCustomWeaponBaseWeaponId(replacementEquipID);
                int gemID = editor.GetEquipCustomWeaponGemId(replacementEquipID);
                int materialId = editor.GetEquipWeaponMaterialSetId(baseEquipID);
                byte reinforceLevel = materialId == 2200 ? (byte)9 : (byte)24;

                // Create a new CustomWeapon with the appropriate reinforceLevel
                editor.CreateNewEquipCustomWeaponRow(currentCustomWeaponId, weapon.Name);
                editor.SetEquipCustomWeaponBaseWeaponId(currentCustomWeaponId, baseEquipID);
                editor.SetEquipCustomWeaponGemId(currentCustomWeaponId, gemID);
                editor.SetEquipCustomWeaponReinforceLevel(currentCustomWeaponId, reinforceLevel);

                currentCustomWeaponId += 2; // maintain odd IDs
            }
            else
            {
                // For standard weapons, the reinforceLevel is just added to the weaponID
                int materialId = editor.GetEquipWeaponMaterialSetId(equipID);
                equipID = materialId == 2200 ? equipID + 9 : equipID + 24;
            }

            //Dual-Wielding Weapons
            if (
                equipID == GraftedDragonItemId
                || equipID == SerpentFlailItemId
                || equipID == PolebladeBudItemId
                || equipID == FlowerstoneGavelId
            )
            {
                starlightWeaponNumSold = (ushort)2;
                //editor.SetEquipWeaponMaxAmmunition(21060000, 0);
            }
            else
            {
                starlightWeaponNumSold = (ushort)1;
            }

            string name = $"[Merchant Millicent - Starlight Shop - Weapon] {weapon.Name}";
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, weapon.EquipType);
            editor.SetShopLineupCostType(shopLineupId, starlightShardCostType);
            editor.SetShopLineupSellPrice(shopLineupId, starlightWeaponCost);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupNumSold(shopLineupId, starlightWeaponNumSold);
            editor.SetShopLineupSellQuantity(shopLineupId, starlightWeaponSellQuantity);
            editor.SetShopLineupMenuTextId(shopLineupId, StarlightShopMenuTextId);

            weaponsInTheStarlightShop.Add(weapon.Name);
        }

        List<ShopItemModel> physickTears = new();
        List<ShopItemModel> talismans = new();
        for (int i = 0; i < shopItems.Count; i++)
        {
            if (shopItems[i].Type == "Physick Tear")
            {
                physickTears.Add(shopItems[i]);
            }
            else if (shopItems[i].Type == "Talisman")
            {
                talismans.Add(shopItems[i]);
            }
        }

        currentShopLineupId = 9201000;
        foreach (ShopItemModel item in physickTears)
        {
            string itemType = item.Type;
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Starlight Shop - {item.Type}] {item.Name}";
            int equipID = item.ID;
            byte equipType = item.EquipType;
            short sellQuantity = item.SellQuantity;
            uint eventFlagForQuantity;
            if (item.EventFlagID == null)
            {
                eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
            }
            else
            {
                eventFlagForQuantity = (uint)item.EventFlagID!;
            }
            int sellPrice = 1;
            if (item.Cost > 40000)
            {
                sellPrice = 3;
            }
            else if (item.Cost > 20000)
            {
                sellPrice = 2;
            }
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipType);
            editor.SetShopLineupCostType(shopLineupId, starlightShardCostType);
            editor.SetShopLineupSellPrice(shopLineupId, sellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, sellQuantity);
            editor.SetShopLineupMenuTextId(shopLineupId, StarlightShopMenuTextId);
        }

        currentShopLineupId = 9202000;
        foreach (ShopItemModel item in talismans)
        {
            string itemType = item.Type;
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Starlight Shop - {item.Type}] {item.Name}";
            int equipID = item.ID;
            byte equipType = item.EquipType;
            short sellQuantity = item.SellQuantity;
            uint eventFlagForQuantity;
            if (item.EventFlagID == null)
            {
                eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
            }
            else
            {
                eventFlagForQuantity = (uint)item.EventFlagID!;
            }
            int sellPrice = 1;
            if (item.Cost > 40000)
            {
                sellPrice = 3;
            }
            else if (item.Cost > 20000)
            {
                sellPrice = 2;
            }
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipType);
            editor.SetShopLineupCostType(shopLineupId, starlightShardCostType);
            editor.SetShopLineupSellPrice(shopLineupId, sellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, sellQuantity);
            editor.SetShopLineupMenuTextId(shopLineupId, StarlightShopMenuTextId);
        }
    }

    private void InitAnamnesisRemembrances(ParamsEditor editor, OptimizedReplacementRandomizer urr)
    {
        int[] shopLineupIDTargets = new int[]
        {
            101898, // Enraged Divine Beast
            101899, // AoW: Divine Beast Frost Stomp
            101930, // Rellana's Twin Blades
            101931, // Rellana's Twin Moons
            101932, // Sword Lance
            101933, // Blades of Stone
            101934, // Putrescence Cleaver
            101935, // Vortex of Putrescence
            101936, // Poleblade of the Bud
            101937, // Rotten Butterflies
            101938, // Greatsword of Damnation
            101939, // Midra's Flame of Frenzy
            101940, // Shadow Sunflower Blossom
            101941, // Land of Shadow
            101942, // Spear of the Impaler
            101943, // Messmer's Orb
            101944, // Staff of the Great Beyond
            101945, // Gazing Finger
            101946, // Greatsword of Radahn (Lord)
            101947, // Greatsword of Radahn (Light)
            101948, // Light of Miquella
        };
        List<GameItemModel> remembranceWeaponReplacements = CsvReaderUtils.Read<GameItemModel>(
            $"{Constants.Misc}/dlc/anamnesis/remembrances/replacements.csv"
        );

#if DEBUG
        Debug.WriteLine($"remembrance weapons length: {remembranceWeaponReplacements.Count()}");
#endif
        remembranceWeaponReplacements.RemoveAll(gameItemModel =>
            anamnesisStarlightWeapons.Contains(gameItemModel.ID)
        );
#if DEBUG
        Debug.WriteLine($"remembrance weapons length: {remembranceWeaponReplacements.Count()}");
#endif

        OptimizedRandomizationGroup remembrancesGroup = new(
            shopLineupIDTargets.Count(),
            remembranceWeaponReplacements.Count()
        );
        urr.AddGroup("anamnesisRemembrancesGroup", remembrancesGroup);
        int[] replacementIndexes = urr.RandomizeGroup("anamnesisRemembrancesGroup");

        for (int i = 0; i < shopLineupIDTargets.Count(); i++)
        {
            editor.SetShopLineupEquipId(
                shopLineupIDTargets[i],
                remembranceWeaponReplacements[replacementIndexes[i]].ID
            );
            editor.SetShopLineupEquipType(
                shopLineupIDTargets[i],
                remembranceWeaponReplacements[replacementIndexes[i]].EquipType
            );
        }
    }

    public void DisableUpgradingClub(ParamsEditor editor)
    {
        int ClubItemId = 11010000;

        editor.SetEquipWeaponIsCustom(ClubItemId, 0);
        editor.SetEquipWeaponMaterialSetId(ClubItemId, 0);
        editor.SetEquipWeaponReinforceTypeId(ClubItemId, 3000);
        editor.SetEquipWeaponReinforceShopCategory(ClubItemId, 0);
    }

    public void EquipMillicentsArmor(ParamsEditor editor, DlcMode mode = DlcMode.Default)
    {
        int merchantMillicentCharaInitId = 23489;
        int helmId;
        int torsoId;
        int armId;
        int legId;

        switch (mode)
        {
            case DlcMode.Moonwalk:
            {
                // Snow Witch Set
                helmId = 1010000;
                torsoId = 1010100;
                armId = -1;
                legId = 1010300;
                break;
            }
            case DlcMode.Omenveil:
            {
                helmId = -1;
                torsoId = 1050100;
                armId = -1;
                legId = -1;
                break;
            }
            case DlcMode.Anamnesis:
            {
                helmId = 770000;
                torsoId = 771100;
                armId = 770200;
                legId = 770300;
                break;
            }
            case DlcMode.Eldensquares:
            {
                helmId = 730000;
                torsoId = 730100;
                armId = 730200;
                legId = 730300;
                break;
            }
            default:
            {
                // Millicent's Set (including custom missing arm)
                helmId = -1;
                torsoId = 1971100;
                armId = 1971200;
                legId = 1950300;
                break;
            }
        }

        editor.SetInitialEquipHelm(merchantMillicentCharaInitId, helmId);
        editor.SetInitialEquipTorso(merchantMillicentCharaInitId, torsoId);
        editor.SetInitialEquipArm(merchantMillicentCharaInitId, armId);
        editor.SetInitialEquipLeg(merchantMillicentCharaInitId, legId);
    }

    private void ModeCustomization(DlcMode mode)
    {
        //Anamnesis-only Title Screen
        string menuPath = Path.Combine(Constants.MenuBndOutDlc, "menu");
        string menuAnamnesisPath = Path.Combine(Constants.ModeFolders, "menu_anamnesis");
        modeService.UpdateFolder(
            targetPath: menuPath,
            sourcePath: mode == DlcMode.Anamnesis ? menuAnamnesisPath : null
        );

        // Events (default vs Anamnesis/EldenSquares)
        string eventPath = Path.Combine(Constants.MenuBndOutDlc, "event");
        string eventDefaultPath = Path.Combine(Constants.ModeFolders, "event_dlc");
        string eventAnamnesisPath = Path.Combine(Constants.ModeFolders, "event_anamnesis");
        string eventEldensquaresPath = Path.Combine(Constants.ModeFolders, "event_eldensquares");

        modeService.UpdateFolder(
            targetPath: eventPath,
            sourcePath: mode switch
            {
                DlcMode.Anamnesis => eventAnamnesisPath,
                DlcMode.Eldensquares => eventEldensquaresPath,
                _ => eventDefaultPath,
            }
        );

        // Talk Scripts (default vs Elden Squares)
        string scriptPath = Path.Combine(Constants.MenuBndOutDlc, "script");
        string scriptDefaultPath = Path.Combine(Constants.ModeFolders, "script_dlc");
        string scriptEldensquaresPath = Path.Combine(Constants.ModeFolders, "script_eldensquares");

        modeService.UpdateFolder(
            targetPath: scriptPath,
            sourcePath: mode == DlcMode.Eldensquares ? scriptEldensquaresPath : scriptDefaultPath
        );

        // Regulation for Weapon Reqs (default vs Elden Squares)
    }
}
