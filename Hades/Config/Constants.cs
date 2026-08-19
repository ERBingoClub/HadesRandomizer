using System.IO;

namespace Hades.Config;

internal partial class Constants
{
    // Mod Configuration
    public static string ModEngineWorkingDirectory = Path.Combine("Resources", "me3-v0.8.0");
    public static string RegulationBase = Path.Combine("Resources", "Regulation");

    // ClassIDs
    public static readonly Dictionary<string, int> CharaInitClassMap = new Dictionary<string, int>()
    {
        ["Vagabond"] = 3000,
        ["Warrior"] = 3001,
        ["Hero"] = 3002,
        ["Bandit"] = 3003,
        ["Astrologer"] = 3004,
        ["Prophet"] = 3005,
        ["Confessor"] = 3006,
        ["Samurai"] = 3007,
        ["Prisoner"] = 3008,
    };

    // Item Constants
    public static readonly int[] BaseChest = new int[]
    {
        40100, // Scale Armor
        50100, // Kaiden Armor
        60100, // Drake Knight Armor
        61100, // Drake Knight Armor (Altered)
        80100, // Scaled Armor
        81100, // Scaled Armor (Altered)
        90100, // Perfumer Robe
        91100, // Perfumer Robe (Altered)
        100100, // Perfumer's Traveling Garb
        101100, // Perfumer's Traveling Garb (Altered)
        120100, // Alberich's Robe
        121100, // Alberich's Robe (Altered)
        130100, // Spellblade's Traveling Attire
        131100, // Spellblade's Traveling Attire (Altered)
        140100, // Bull-Goat Armor
        150100, // Ronin's Armor
        151100, // Ronin's Armor (Altered)
        160100, // Cloth Garb
        170100, // Blaidd's Armor
        171100, // Blaidd's Armor (Altered)
        180100, // Black Knife Armor
        181100, // Black Knife Armor (Altered)
        190100, // Exile Armor
        200100, // Banished Knight Armor
        201100, // Banished Knight Armor (Altered)
        210100, // Briar Armor
        211100, // Briar Armor (Altered)
        220100, // Page Garb
        221100, // Page Garb (Altered)
        230100, // Night's Cavalry Armor
        231100, // Night's Cavalry Armor (Altered)
        240100, // Blue Silver Mail Armor
        241100, // Blue Silver Mail Armor (Altered)
        250100, // Nomadic Merchant's Finery
        251100, // Nomadic Merchant's Finery (Altered)
        260100, // Malformed Dragon Armor
        270100, // Tree Sentinel Armor
        271100, // Tree Sentinel Armor (Altered)
        280100, // Royal Knight Armor
        281100, // Royal Knight Armor (Altered)
        290100, // Nox Monk Armor
        291100, // Nox Monk Armor (Altered)
        292100, // Nox Swordstress Armor
        293100, // Night Maiden Armor
        294100, // Nox Swordstress Armor (Altered)
        300100, // Fur Raiment
        301100, // Shaman Furs
        310100, // Gravekeeper Cloak
        311100, // Gravekeeper Cloak (Altered)
        320100, // Sanguine Noble Robe
        330100, // Guardian Garb (Full Bloom)
        331100, // Guardian Garb
        340100, // Cleanrot Armor
        341100, // Cleanrot Armor (Altered)
        350100, // Fire Monk Armor
        351100, // Blackflame Monk Armor
        360100, // Fire Prelate Armor
        361100, // Fire Prelate Armor (Altered)
        370100, // Aristocrat Garb
        371100, // Aristocrat Garb (Altered)
        380100, // Aristocrat Coat
        390100, // Old Aristocrat Gown
        420100, // Vulgar Militia Armor
        430100, // Sage Robe
        460100, // Elden Lord Armor
        461100, // Elden Lord Armor (Altered)
        470100, // Radahn's Lion Armor
        471100, // Radahn's Lion Armor (Altered)
        480100, // Lord of Blood's Robe
        481100, // Lord of Blood's Robe (Altered)
        510100, // Queen's Robe
        520100, // Godskin Apostle Robe
        530100, // Godskin Noble Robe
        540100, // Depraved Perfumer Robe
        541100, // Depraved Perfumer Robe (Altered)
        570100, // Crucible Axe Armor
        571100, // Crucible Tree Armor
        572100, // Crucible Axe Armor (Altered)
        573100, // Crucible Tree Armor (Altered)
        580100, // Lusat's Robe
        581100, // Azur's Glintstone Robe
        590100, // All-Knowing Armor
        591100, // All-Knowing Armor (Altered)
        600100, // Twinned Armor
        601100, // Twinned Armor (Altered)
        620100, // Corhyn's Robe
        621100, // Prophet Robe (Altered)
        622100, // Prophet Robe
        630100, // Astrologer Robe
        631100, // Astrologer Robe (Altered)
        640100, // Lionel's Armor
        641100, // Lionel's Armor (Altered)
        650100, // Hoslow's Armor
        652100, // Hoslow's Armor (Altered)
        660100, // Vagabond Knight Armor
        661100, // Vagabond Knight Armor (Altered)
        670100, // Blue Cloth Vest
        680100, // War Surgeon Gown
        681100, // War Surgeon Gown (Altered)
        690100, // Royal Remains Armor
        720100, // Beast Champion Armor
        721100, // Beast Champion Armor (Altered)
        730100, // Champion Pauldron
        740100, // Noble's Traveling Garb
        760100, // Maliketh's Armor
        761100, // Maliketh's Armor (Altered)
        770100, // Malenia's Armor
        771100, // Malenia's Armor (Altered)
        780100, // Veteran's Armor
        781100, // Veteran's Armor (Altered)
        790100, // Bloodhound Knight Armor
        791100, // Bloodhound Knight Armor (Altered)
        800100, // Festive Garb
        801100, // Festive Garb (Altered)
        802100, // Blue Festive Garb
        810100, // Commoner's Garb
        811100, // Commoner's Garb (Altered)
        812000, // Commoner's Simple Garb
        812100, // Commoner's Simple Garb (Altered)
        830100, // Raya Lucarian Robe
        840100, // Marionette Soldier Armor
        860100, // Raging Wolf Armor
        861100, // Raging Wolf Armor (Altered)
        870100, // Land of Reeds Armor
        871100, // Land of Reeds Armor (Altered)
        872100, // White Reed Armor
        880100, // Confessor Armor
        881100, // Confessor Armor (Altered)
        890100, // Prisoner Clothing
        900100, // Traveling Maiden Robe
        901100, // Traveling Maiden Robe (Altered)
        902100, // Finger Maiden Robe
        903100, // Finger Maiden Robe (Altered)
        910100, // Preceptor's Long Gown
        911100, // Preceptor's Long Gown (Altered)
        930100, // Raptor's Black Feathers
        931100, // Bandit Garb
        940100, // Eccentric's Armor
        950100, // Fingerprint Armor
        951100, // Fingerprint Armor (Altered)
        960100, // Consort's Robe
        961100, // Ruler's Robe
        962100, // Upper-Class Robe
        963100, // Marais Robe
        964100, // Official's Attire
        970100, // Omen Armor
        980100, // Carian Knight Armor
        981100, // Carian Knight Armor (Altered)
        990100, // Errant Sorcerer Robe
        991100, // Errant Sorcerer Robe (Altered)
        1000100, // Battlemage Robe
        1010100, // Snow Witch Robe
        1011100, // Snow Witch Robe (Altered)
        1020100, // Traveler's Clothes
        1030100, // Juvenile Scholar Robe
        1040100, // Goldmask's Rags
        1050100, // Fell Omen Cloak
        1060100, // Dirty Chainmail
        1070100, // Zamor Armor
        1100100, // Chain Armor
        1101100, // Eye Surcoat
        1102100, // Tree Surcoat
        1130100, // Mushroom Body
        1400100, // Leather Armor
        1500100, // Knight Armor
        1700100, // Tree-and-Beast Surcoat
        1710100, // Cuckoo Surcoat
        1720100, // Erdtree Surcoat
        1730100, // Redmane Surcoat
        1740100, // Mausoleum Surcoat
        1750100, // Haligtree Crest Surcoat
        1760100, // Gelmir Knight Armor
        1761100, // Gelmir Knight Armor (Altered)
        1770100, // Godrick Knight Armor
        1771100, // Godrick Knight Armor (Altered)
        1780100, // Cuckoo Knight Armor
        1781100, // Cuckoo Knight Armor (Altered)
        1790100, // Leyndell Knight Armor
        1791100, // Leyndell Knight Armor (Altered)
        1800100, // Redmane Knight Armor
        1801100, // Redmane Knight Armor (Altered)
        1810100, // Mausoleum Knight Armor
        1811100, // Mausoleum Knight Armor (Altered)
        1820100, // Haligtree Knight Armor
        1821100, // Haligtree Knight Armor (Altered)
        1830100, // Chain-Draped Tabard
        1840100, // Foot Soldier Tabard
        1850100, // Leather-Draped Tabard
        1860100, // Scarlet Tabard
        1870100, // Bloodsoaked Tabard
        1880100, // Ivory-Draped Tabard
        1890100, // Omenkiller Robe
        1930100, // Deathbed Dress
        1940100, // Fia's Robe
        1941100, // Fia's Robe (Altered)
        1980100, // Highwayman Cloth Armor
        1990100, // High Page Clothes
        1991100, // High Page Clothes (Altered)
        2000100, // Rotten Gravekeeper Cloak
        2001100, // Rotten Gravekeeper Cloak (Altered)
        2030000, // Lazuli Robe
    };
    public static readonly int[] BaseHelm = new int[]
    {
        40000, // Iron Helmet
        50000, // Kaiden Helm
        60000, // Drake Knight Helm
        61000, // Drake Knight Helm (Altered)
        80000, // Scaled Helm
        90000, // Perfumer Hood
        100000, // Traveler's Hat
        120000, // Alberich's Pointed Hat
        121000, // Alberich's Pointed Hat (Altered)
        130000, // Spellblade's Pointed Hat
        140000, // Bull-Goat Helm
        150000, // Iron Kasa
        160000, // Guilty Hood
        170000, // Black Wolf Mask
        180000, // Black Knife Hood
        190000, // Exile Hood
        200000, // Banished Knight Helm
        201000, // Banished Knight Helm (Altered)
        210000, // Briar Helm
        220000, // Page Hood
        230000, // Night's Cavalry Helm
        231000, // Night's Cavalry Helm (Altered)
        240000, // Blue Silver Mail Hood
        250000, // Nomadic Merchant's Chapeau
        260000, // Malformed Dragon Helm
        270000, // Tree Sentinel Helm
        280000, // Royal Knight Helm
        290000, // Nox Monk Hood
        291000, // Nox Monk Hood (Altered)
        292000, // Nox Swordstress Crown
        293000, // Night Maiden Twin Crown
        294000, // Nox Swordstress Crown (Altered)
        300000, // Great Horned Headband
        301000, // Shining Horned Headband
        310000, // Duelist Helm
        320000, // Sanguine Noble Hood
        330000, // Guardian Mask
        340000, // Cleanrot Helm
        341000, // Cleanrot Helm (Altered)
        350000, // Fire Monk Hood
        351000, // Blackflame Monk Hood
        360000, // Fire Prelate Helm
        370000, // Aristocrat Headband
        380000, // Aristocrat Hat
        390000, // Old Aristocrat Cowl
        420000, // Vulgar Militia Helm
        430000, // Sage Hood
        440000, // Pumpkin Helm
        460000, // Elden Lord Crown
        470000, // Radahn's Redmane Helm
        510000, // Queen's Crescent Crown
        520000, // Godskin Apostle Hood
        530000, // Godskin Noble Hood
        540000, // Depraved Perfumer Headscarf
        570000, // Crucible Axe Helm
        571000, // Crucible Tree Helm
        580000, // Lusat's Glintstone Crown
        581000, // Azur's Glintstone Crown
        590000, // All-Knowing Helm
        600000, // Twinned Helm
        620000, // Prophet Blindfold
        630000, // Astrologer Hood
        640000, // Lionel's Helm
        650000, // Hoslow's Helm
        651000, // Diallos's Mask
        660000, // Vagabond Knight Helm
        670000, // Blue Cloth Cowl
        680000, // White Mask
        690000, // Royal Remains Helm
        720000, // Beast Champion Helm
        730000, // Champion Headband
        740000, // Crimson Hood
        741000, // Navy Hood
        760000, // Maliketh's Helm
        770000, // Malenia's Winged Helm
        780000, // Veteran's Helm
        790000, // Bloodhound Knight Helm
        800000, // Festive Hood
        801000, // Festive Hood (Altered)
        802000, // Blue Festive Hood
        810000, // Commoner's Headband
        811000, // Commoner's Headband (Altered)
        820000, // Envoy Crown
        830000, // Twinsage Glintstone Crown
        831000, // Olivinus Glintstone Crown
        832000, // Lazuli Glintstone Crown
        833000, // Karolos Glintstone Crown
        834000, // Witch's Glintstone Crown
        840000, // Marionette Soldier Helm
        850000, // Marionette Soldier Birdhelm
        860000, // Raging Wolf Helm
        870000, // Land of Reeds Helm
        872000, // Okina Mask
        880000, // Confessor Hood
        881000, // Confessor Hood (Altered)
        890000, // Prisoner Iron Mask
        891000, // Blackguard's Iron Mask
        900000, // Traveling Maiden Hood
        902000, // Finger Maiden Fillet
        910000, // Preceptor's Big Hat
        911000, // Mask of Confidence
        930000, // Skeletal Mask
        940000, // Eccentric's Hood
        941000, // Eccentric's Hood (Altered)
        950000, // Fingerprint Helm
        960000, // Consort's Mask
        961000, // Ruler's Mask
        963000, // Marais Mask
        964000, // Bloodsoaked Mask
        970000, // Omen Helm
        980000, // Carian Knight Helm
        990000, // Hierodas Glintstone Crown
        1000000, // Haima Glintstone Crown
        1010000, // Snow Witch Hat
        1030000, // Juvenile Scholar Cap
        1040000, // Radiant Gold Mask
        1060000, // Albinauric Mask
        1070000, // Zamor Mask
        1080000, // Imp Head (Cat)
        1081000, // Imp Head (Fanged)
        1082000, // Imp Head (Long-Tongued)
        1083000, // Imp Head (Corpse)
        1084000, // Imp Head (Wolf)
        1085000, // Imp Head (Elder)
        1090000, // Silver Tear Mask
        1100000, // Chain Coif
        1101000, // Greathelm
        1110000, // Octopus Head
        1120000, // Jar
        1130000, // Mushroom Head
        1300000, // Nox Mirrorhelm
        1301000, // Iji's Mirrorhelm
        1400000, // Black Hood
        1401000, // Bandit Mask
        1500000, // Knight Helm
        1600000, // Greathood
        1700000, // Godrick Soldier Helm
        1710000, // Raya Lucarian Helm
        1720000, // Leyndell Soldier Helm
        1730000, // Radahn Soldier Helm
        1750000, // Haligtree Helm
        1760000, // Gelmir Knight Helm
        1770000, // Godrick Knight Helm
        1780000, // Cuckoo Knight Helm
        1790000, // Leyndell Knight Helm
        1800000, // Redmane Knight Helm
        1820000, // Haligtree Knight Helm
        1830000, // Foot Soldier Cap
        1840000, // Foot Soldier Helmet
        1850000, // Gilded Foot Soldier Cap
        1860000, // Foot Soldier Helm
        1880000, // Sacred Crown Helm
        1890000, // Omensmirk Mask
        1900000, // Ash-of-War Scarab
        1901000, // Incantation Scarab
        1902000, // Glintstone Scarab
        1910000, // Crimson Tear Scarab
        1920000, // Cerulean Tear Scarab
        1940000, // Fia's Hood
        1980000, // Highwayman Hood
        1990000, // High Page Hood
        2000000, // Rotten Duelist Helm
        2010000, // Mushroom Crown
        2020000, // Black Dumpling
    };
    public static readonly int[] BaseLegs = new int[]
    {
        120300, // Alberich's Trousers
        590300, // All-Knowing Greaves
        370300, // Aristocrat Boots
        630300, // Astrologer Trousers
        930300, // Bandit Boots
        200300, // Banished Knight Greaves
        1000300, // Battlemage Legwraps
        720300, // Beast Champion Greaves
        180300, // Black Knife Greaves
        351300, // Blackflame Monk Greaves
        170300, // Blaidd's Greaves
        790300, // Bloodhound Knight Greaves
        240300, // Blue Silver Mail Skirt
        700300, // Brave's Legwraps
        210300, // Briar Greaves
        140300, // Bull-Goat Greaves
        980300, // Carian Knight Greaves
        1100300, // Chain Leggings
        730300, // Champion Gaiters
        340300, // Cleanrot Greaves
        160300, // Cloth Trousers
        810300, // Commoner's Shoes
        880300, // Confessor Boots
        960300, // Consort's Trousers
        570300, // Crucible Greaves
        1780300, // Cuckoo Knight Greaves
        540300, // Depraved Perfumer Trousers
        60300, // Drake Knight Greaves
        310300, // Duelist Greaves
        940300, // Eccentric's Breeches
        460300, // Elden Lord Greaves
        990300, // Errant Sorcerer Boots
        190300, // Exile Greaves
        902300, // Finger Maiden Shoes
        950300, // Fingerprint Greaves
        350300, // Fire Monk Greaves
        360300, // Fire Prelate Greaves
        1830300, // Foot Soldier Greaves
        300300, // Fur Leggings
        1760300, // Gelmir Knight Greaves
        1770300, // Godrick Knight Greaves
        1700300, // Godrick Soldier Greaves
        520300, // Godskin Apostle Trousers
        530300, // Godskin Noble Trousers
        1040300, // Gold Waistwrap
        330300, // Guardian Greaves
        1750300, // Haligtree Greaves
        1820300, // Haligtree Knight Greaves
        650300, // Hoslow's Greaves
        50300, // Kaiden Trousers
        1500300, // Knight Greaves
        870300, // Land of Reeds Greaves
        1400300, // Leather Boots
        40300, // Leather Trousers
        1790300, // Leyndell Knight Greaves
        1720300, // Leyndell Soldier Greaves
        640300, // Lionel's Greaves
        770300, // Malenia's Greaves
        260300, // Malformed Dragon Greaves
        760300, // Maliketh's Greaves
        1740300, // Mausoleum Greaves
        1810300, // Mausoleum Knight Greaves
        1130300, // Mushroom Legs
        230300, // Night's Cavalry Greaves
        740300, // Noble's Trousers
        250300, // Nomadic Merchant's Trousers
        290300, // Nox Greaves
        390300, // Old Aristocrat Shoes
        580300, // Old Sorcerer's Legwraps
        970300, // Omen Greaves
        1890300, // Omenkiller Boots
        220300, // Page Trousers
        90300, // Perfumer Sarong
        910300, // Preceptor's Trousers
        890300, // Prisoner Trousers
        620300, // Prophet Trousers
        510300, // Queen's Leggings
        1730300, // Radahn Soldier Greaves
        470300, // Radahn's Greaves
        610300, // Ragged Loincloth
        860300, // Raging Wolf Greaves
        1710300, // Raya Lucarian Greaves
        1800300, // Redmane Knight Greaves
        150300, // Ronin's Greaves
        2000300, // Rotten Duelist Greaves
        280300, // Royal Knight Greaves
        690300, // Royal Remains Greaves
        430300, // Sage Trousers
        320300, // Sanguine Noble Waistcloth
        80300, // Scaled Greaves
        301300, // Shaman Leggings
        1010300, // Snow Witch Skirt
        830300, // Sorcerer Leggings
        130300, // Spellblade's Trousers
        1020300, // Traveler's Boots
        100300, // Traveler's Slops
        900300, // Traveling Maiden Boots
        270300, // Tree Sentinel Greaves
        600300, // Twinned Greaves
        660300, // Vagabond Knight Greaves
        780300, // Veteran's Greaves
        420300, // Vulgar Militia Greaves
        680300, // War Surgeon Trousers
        670300, // Warrior Greaves
        872300, // White Reed Greaves
        1070300, // Zamor Legwraps
    };
    public static readonly int[] BaseArms = new int[]
    {
        40200, // Iron Gauntlets
        50200, // Kaiden Gauntlets
        60200, // Drake Knight Gauntlets
        80200, // Scaled Gauntlets
        90200, // Perfumer Gloves
        100200, // Traveler's Gloves
        120200, // Alberich's Bracers
        130200, // Spellblade's Gloves
        140200, // Bull-Goat Gauntlets
        150200, // Ronin's Gauntlets
        170200, // Blaidd's Gauntlets
        180200, // Black Knife Gauntlets
        190200, // Exile Gauntlets
        200200, // Banished Knight Gauntlets
        210200, // Briar Gauntlets
        230200, // Night's Cavalry Gauntlets
        240200, // Blue Silver Bracelets
        260200, // Malformed Dragon Gauntlets
        270200, // Tree Sentinel Gauntlets
        280200, // Royal Knight Gauntlets
        290200, // Nox Bracelets
        330200, // Guardian Bracers
        340200, // Cleanrot Gauntlets
        350200, // Fire Monk Gauntlets
        351200, // Blackflame Monk Gauntlets
        360200, // Fire Prelate Gauntlets
        420200, // Vulgar Militia Gauntlets
        460200, // Elden Lord Bracers
        470200, // Radahn's Gauntlets
        510200, // Queen's Bracelets
        520200, // Godskin Apostle Bracelets
        530200, // Godskin Noble Bracelets
        540200, // Depraved Perfumer Gloves
        570200, // Crucible Gauntlets
        580200, // Lusat's Manchettes
        581200, // Azur's Manchettes
        590200, // All-Knowing Gauntlets
        600200, // Twinned Gauntlets
        610200, // Ragged Gloves
        630200, // Astrologer Gloves
        640200, // Lionel's Gauntlets
        650200, // Hoslow's Gauntlets
        660200, // Vagabond Knight Gauntlets
        670200, // Warrior Gauntlets
        680200, // War Surgeon Gloves
        690200, // Royal Remains Gauntlets
        700200, // Brave's Bracer
        720200, // Beast Champion Gauntlets
        730200, // Champion Bracers
        740200, // Noble's Gloves
        760200, // Maliketh's Gauntlets
        770200, // Malenia's Gauntlet
        780200, // Veteran's Gauntlets
        790200, // Bloodhound Knight Gauntlets
        830200, // Sorcerer Manchettes
        860200, // Raging Wolf Gauntlets
        870200, // Land of Reeds Gauntlets
        872200, // White Reed Gauntlets
        880200, // Confessor Gloves
        900200, // Traveling Maiden Gloves
        910200, // Preceptor's Gloves
        930200, // Bandit Manchettes
        940200, // Eccentric's Manchettes
        950200, // Fingerprint Gauntlets
        963200, // Bloodsoaked Manchettes
        970200, // Omen Gauntlets
        980200, // Carian Knight Gauntlets
        990200, // Errant Sorcerer Manchettes
        1000200, // Battlemage Manchettes
        1020200, // Traveler's Manchettes
        1040200, // Gold Bracelets
        1070200, // Zamor Bracelets
        1100200, // Chain Gauntlets
        1130200, // Mushroom Arms
        1400200, // Leather Gloves
        1500200, // Knight Gauntlets
        1700200, // Godrick Soldier Gauntlets
        1710200, // Raya Lucarian Gauntlets
        1720200, // Leyndell Soldier Gauntlets
        1730200, // Radahn Soldier Gauntlets
        1740200, // Mausoleum Gauntlets
        1750200, // Haligtree Gauntlets
        1760200, // Gelmir Knight Gauntlets
        1770200, // Godrick Knight Gauntlets
        1780200, // Cuckoo Knight Gauntlets
        1790200, // Leyndell Knight Gauntlets
        1800200, // Redmane Knight Gauntlets
        1810200, // Mausoleum Knight Gauntlets
        1820200, // Haligtree Knight Gauntlets
        1830200, // Foot Soldier Gauntlets
        1890200, // Omenkiller Long Gloves
        1980200, // Highwayman Gauntlets
    };
}
