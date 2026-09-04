namespace Hades.Constants;

public enum WeaponLocation
{
    Base,
    Dlc,
}

public enum WeaponUpgrade
{
    Somber,
    Smithing,
}

public enum WeaponCategory
{
    Axe,
    Whip,
    ColossalSword,
    ColossalWeapon,
    CurvedGreatsword,
    CurvedSword, // Includes BHBs
    Bow,
    LightBow,
    GreatBow,
    Crossbow,
    Ballista,
    Dagger, // Including Throwing Blade
    GreatHammer,
    GreatAxe,
    GreatShield,
    Greatsword, // Light Greatsword
    Halberd,
    Hammers,
    MediumShield,
    SmallShield,
    StraightSword,
    ThrustingSword,
    Reaper,
    Spear,
    Fist, // Includes hand-to-hand
    Twinblade,
    Katana, // Includes Great Katana
    PerfumeBottle,
    Claw, // Includes Beast Claws
    Torch,
    GreatSpear,
    Flail,
    HeavyThrustingSword,
    Staff,
    Seal,
}

public readonly record struct WeaponEntry(
    int Id,
    string Name,
    WeaponCategory Category,
    WeaponLocation Location,
    WeaponUpgrade Upgrade
);

public static class Weapons
{
    public static WeaponEntry[] GetAllSmithingWeapons()
    {
        WeaponEntry[] garunteedSmithing = GuaranteedWeapons
            .Where(e => e.Upgrade == WeaponUpgrade.Smithing)
            .ToArray();
        return garunteedSmithing
            .Concat(ChanceWeapons.Where(e => e.Upgrade == WeaponUpgrade.Smithing))
            .ToArray();
    }

    public static readonly WeaponEntry[] RemembranceWeapons =
    {
        new(
            4550000,
            "Greatsword of Radahn (Light)",
            WeaponCategory.ColossalSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            4530000,
            "Greatsword of Radahn (Lord)",
            WeaponCategory.ColossalSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            4020000,
            "Maliketh's Black Blade",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            4050000,
            "Starscourge Greatsword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            23050000,
            "Axe of Godfrey",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            23520000,
            "Gazing Finger",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            23510000,
            "Shadow Sunflower Blossom",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            8100000,
            "Morgott's Cursed Sword",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            21060000,
            "Grafted Dragon",
            WeaponCategory.Fist,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            13030000,
            "Bastard's Stars",
            WeaponCategory.Flail,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            17010000,
            "Mohgwyn's Sacred Spear",
            WeaponCategory.GreatSpear,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            17500000,
            "Spear of the Impaler",
            WeaponCategory.GreatSpear,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            15040000,
            "Axe of Godrick",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            8500000,
            "Putrescence Cleaver",
            WeaponCategory.GreatAxe,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            15110000,
            "Winged Greathorn",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            42000000,
            "Lion Greatbow",
            WeaponCategory.GreatBow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3140000,
            "Blasphemous Blade",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3510000,
            "Greatsword of Damnation",
            WeaponCategory.Greatsword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            3100000,
            "Sacred Relic Sword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            18510000,
            "Poleblade of the Bud",
            WeaponCategory.Halberd,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            11150000,
            "Marika's Hammer",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            6040000,
            "Dragon King's Cragblade",
            WeaponCategory.HeavyThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3500000,
            "Sword Lance",
            WeaponCategory.HeavyThrustingSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            9020000,
            "Hand of Malenia",
            WeaponCategory.Katana,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            67520000,
            "Rellana's Twin Blades",
            WeaponCategory.Greatsword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            20060000,
            "Giant's Red Braid",
            WeaponCategory.Whip,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
    };
    public static readonly WeaponEntry[] GuaranteedWeapons =
    {
        // Daggers
        new(
            1500000,
            "Main-gauche",
            WeaponCategory.Dagger,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            63500000,
            "Smithscript Dagger",
            WeaponCategory.Dagger,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            1020000,
            "Parrying Dagger",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            1030000,
            "Misericorde",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            1150000,
            "Erdsteel Dagger",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            1100000,
            "Wakizashi",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            1130000,
            "Ivory Sickle",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            1050000,
            "Crystal Knife",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            1080000,
            "Scorpion's Stinger",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(1110000, "Cinquedea", WeaponCategory.Dagger, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(
            1070000,
            "Glintstone Kris",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(1040000, "Reduvia", WeaponCategory.Dagger, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(
            1160000,
            "Blade of Calling",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            1010000,
            "Black Knife",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Straight Swords
        new(
            2510000,
            "Velvet Sword of St. Trina",
            WeaponCategory.StraightSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            2540000,
            "Stone-Sheathed Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            2550000,
            "Sword of Light",
            WeaponCategory.StraightSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            2560000,
            "Sword of Darkness",
            WeaponCategory.StraightSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            2010000,
            "Short Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            2000000,
            "Longsword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            2020000,
            "Broadsword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            2210000,
            "Cane Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            2180000,
            "Carian Knight's Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            2150000,
            "Crystal Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            2260000,
            "Rotten Crystal Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            2200000,
            "Miquellan Knight's Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            2060000,
            "Ornamental Straight Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            2070000,
            "Golden Epitaph",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            2190000,
            "Sword of St. Trina",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            2220000,
            "Regalia of Eochaid",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            2110000,
            "Coded Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            2140000,
            "Sword of Night and Flame",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Greatswords & Light Greatswords
        new(
            67500000,
            "Milady",
            WeaponCategory.Greatsword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            67510000,
            "Leda's Sword",
            WeaponCategory.Greatsword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            3550000,
            "Greatsword of Solitude",
            WeaponCategory.Greatsword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            3000000,
            "Bastard Sword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            3180000,
            "Claymore",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            3030000,
            "Lordsworn's Greatsword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            3050000,
            "Flamberge",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            3190000,
            "Gargoyle's Greatsword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            3210000,
            "Gargoyle's Blackblade",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            2090000,
            "Inseparable Sword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3160000,
            "Sword of Milos",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3150000,
            "Marais Executioner's Sword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3060000,
            "Ordovis's Greatsword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3070000,
            "Alabaster Lord's Sword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3200000,
            "Death's Poker",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3130000,
            "Helphen's Steeple",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3170000,
            "Golden Order Greatsword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            3090000,
            "Dark Moon Greatsword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Colossal Swords
        new(
            4500000,
            "Ancient Meteoric Ore Greatsword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            4540000,
            "Moonrithyll's Knight Sword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            4040000,
            "Zweihander",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            4000000,
            "Greatsword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            4030000,
            "Troll's Golden Sword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            4060000,
            "Royal Greatsword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            4100000,
            "Grafted Blade Greatsword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            4080000,
            "Ruins Greatsword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            4070000,
            "Godslayer's Greatsword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Thrusting Swords
        new(
            2530000,
            "Carian Sorcery Sword",
            WeaponCategory.ThrustingSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            5020000,
            "Rapier",
            WeaponCategory.ThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            5000000,
            "Estoc",
            WeaponCategory.ThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            5030000,
            "Rogier's Rapier",
            WeaponCategory.ThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            5040000,
            "Antspur Rapier",
            WeaponCategory.ThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            5050000,
            "Frozen Needle",
            WeaponCategory.ThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Heavy Thrusting Swords
        new(
            6500000,
            "Queelign's Greatsword",
            WeaponCategory.HeavyThrustingSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            6020000,
            "Great Epee",
            WeaponCategory.HeavyThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            6010000,
            "Godskin Stitcher",
            WeaponCategory.HeavyThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            6000000,
            "Bloody Helice",
            WeaponCategory.HeavyThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Curved Swords & Backhand Blades
        new(
            64500000,
            "Backhand Blade",
            WeaponCategory.CurvedSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            64510000,
            "Smithscript Cirque",
            WeaponCategory.CurvedSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            7500000,
            "Spirit Sword",
            WeaponCategory.CurvedSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(7510000, "Falx", WeaponCategory.CurvedSword, WeaponLocation.Dlc, WeaponUpgrade.Somber),
        new(
            7520000,
            "Dancing Blade of Ranah",
            WeaponCategory.CurvedSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            7140000,
            "Scimitar",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            7030000,
            "Shamshir",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            7020000,
            "Shotel",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            7080000,
            "Scavenger's Curved Sword",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            7120000,
            "Mantis Blade",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            7060000,
            "Flowing Curved Sword",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            7110000,
            "Serpent-God's Curved Sword",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            2080000,
            "Nox Flowing Sword",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            7070000,
            "Wing of Astel",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            7100000,
            "Eclipse Shotel",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Curved Greatswords
        new(
            8520000,
            "Horned Warrior's Greatsword",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            8510000,
            "Freyja's Greatsword",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            8030000,
            "Bloodhound's Fang",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            8010000,
            "Onyx Lord's Greatsword",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            8050000,
            "Zamor Curved Sword",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            8040000,
            "Magma Wyrm's Scalesword",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Katanas & Great Katanas
        new(
            66500000,
            "Great Katana",
            WeaponCategory.Katana,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            66510000,
            "Dragon-Hunter's Great Katana",
            WeaponCategory.Katana,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            66520000,
            "Rakshasa's Great Katana",
            WeaponCategory.Katana,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            2520000,
            "Star-Lined Sword",
            WeaponCategory.Katana,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            9500000,
            "Sword of Night",
            WeaponCategory.Katana,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            9000000,
            "Uchigatana",
            WeaponCategory.Katana,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            9010000,
            "Nagakiba",
            WeaponCategory.Katana,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            9080000,
            "Serpentbone Blade",
            WeaponCategory.Katana,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            9030000,
            "Meteoric Ore Blade",
            WeaponCategory.Katana,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(9060000, "Moonveil", WeaponCategory.Katana, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(
            9040000,
            "Rivers of Blood",
            WeaponCategory.Katana,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            9070000,
            "Dragonscale Blade",
            WeaponCategory.Katana,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Twinblades
        new(
            10510000,
            "Black Steel Twinblade",
            WeaponCategory.Twinblade,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            10500000,
            "Euporia",
            WeaponCategory.Twinblade,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            10000000,
            "Twinblade",
            WeaponCategory.Twinblade,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            10030000,
            "Twinned Knight Swords",
            WeaponCategory.Twinblade,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            10010000,
            "Godskin Peeler",
            WeaponCategory.Twinblade,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            10080000,
            "Gargoyle's Twinblade",
            WeaponCategory.Twinblade,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            10090000,
            "Gargoyle's Black Blades",
            WeaponCategory.Twinblade,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            10050000,
            "Eleonora's Poleblade",
            WeaponCategory.Twinblade,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Axes
        new(
            14500000,
            "Smithscript Axe",
            WeaponCategory.Axe,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            14510000,
            "Death Knight's Twin Axes",
            WeaponCategory.Axe,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(14020000, "Hand Axe", WeaponCategory.Axe, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            14000000,
            "Battle Axe",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            14100000,
            "Highland Axe",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            14110000,
            "Sacrificial Axe",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            14080000,
            "Icerind Hatchet",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            14050000,
            "Ripple Blade",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            14140000,
            "Stormhawk Axe",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(14120000, "Rosus' Axe", WeaponCategory.Axe, WeaponLocation.Base, WeaponUpgrade.Somber),
        // Great Axes
        new(
            15500000,
            "Death Knight's Longhaft Axe",
            WeaponCategory.GreatAxe,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            15510000,
            "Bonny Butchering Knife",
            WeaponCategory.GreatAxe,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            15000000,
            "Greataxe",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            15020000,
            "Great Omenkiller Cleaver",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            15060000,
            "Rusted Anchor",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            15120000,
            "Butchering Knife",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            15130000,
            "Gargoyle's Great Axe",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            15140000,
            "Gargoyle's Black Axe",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Hammers
        new(
            11500000,
            "Flowerstone Gavel",
            WeaponCategory.Hammers,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(11000000, "Mace", WeaponCategory.Hammers, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            11050000,
            "Morning Star",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            11080000,
            "Hammer",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            11060000,
            "Varre's Bouquet",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            11120000,
            "Nox Flowing Hammer",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            11130000,
            "Ringed Finger",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            11110000,
            "Scepter of the All-Knowing",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Great Hammers
        new(
            12520000,
            "Black Steel Greathammer",
            WeaponCategory.GreatHammer,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            12500000,
            "Smithscript Greathammer",
            WeaponCategory.GreatHammer,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            12000000,
            "Large Club",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            12060000,
            "Great Mace",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            12190000,
            "Brick Hammer",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            12210000,
            "Rotten Battle Hammer",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            12130000,
            "Celebrant's Skull",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            12180000,
            "Great Stars",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            12170000,
            "Cranial Vessel Candlestand",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            12150000,
            "Beastclaw Greathammer",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            12200000,
            "Devourer's Scepter",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Flails
        new(
            13500000,
            "Serpent Flail",
            WeaponCategory.Flail,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(13010000, "Flail", WeaponCategory.Flail, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            13000000,
            "Nightrider Flail",
            WeaponCategory.Flail,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            13040000,
            "Chainlink Flail",
            WeaponCategory.Flail,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            13020000,
            "Family Heads",
            WeaponCategory.Flail,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Colossal Weapons
        new(
            12530000,
            "Bloodfiend's Arm",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            12510000,
            "Anvil Hammer",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            23500000,
            "Devonia's Hammer",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            23150000,
            "Rotten Greataxe",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            23110000,
            "Giant-Crusher",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            23000000,
            "Prelate's Inferno Crozier",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            23020000,
            "Great Club",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            23130000,
            "Troll's Hammer",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            23060000,
            "Dragon Greatclaw",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            23010000,
            "Watchdog's Staff",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            23070000,
            "Staff of the Avatar",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            23100000,
            "Ghiza's Wheel",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            23080000,
            "Fallingstar Beast Jaw",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Spears
        new(
            16500000,
            "Smithscript Spear",
            WeaponCategory.Spear,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            16520000,
            "Swift Spear",
            WeaponCategory.Spear,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            16000000,
            "Short Spear",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(16070000, "Pike", WeaponCategory.Spear, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            16110000,
            "Cross-Naginata",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            16130000,
            "Inquisitor's Girandole",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            16020000,
            "Crystal Spear",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            16120000,
            "Death Ritual Spear",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            16090000,
            "Bolt of Gransax",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Great Spears
        new(
            17510000,
            "Messmer Soldier's Spear",
            WeaponCategory.GreatSpear,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            16550000,
            "Bloodfiend's Sacred Spear",
            WeaponCategory.GreatSpear,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            17520000,
            "Barbed Staff-Spear",
            WeaponCategory.GreatSpear,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            17060000,
            "Lance",
            WeaponCategory.GreatSpear,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            17070000,
            "Treespear",
            WeaponCategory.GreatSpear,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            17030000,
            "Serpent-Hunter",
            WeaponCategory.GreatSpear,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            17020000,
            "Siluria's Tree",
            WeaponCategory.GreatSpear,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            17050000,
            "Vyke's War Spear",
            WeaponCategory.GreatSpear,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Halberds
        new(
            18500000,
            "Spirit Glaive",
            WeaponCategory.Halberd,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            18000000,
            "Halberd",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            18020000,
            "Lucerne",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            18050000,
            "Nightrider Glaive",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            18150000,
            "Gargoyle's Halberd",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            18160000,
            "Gargoyle's Black Halberd",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            18080000,
            "Golden Halberd",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            18140000,
            "Dragon Halberd",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            18100000,
            "Loretta's War Sickle",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Reapers
        new(
            19500000,
            "Obsidian Lamina",
            WeaponCategory.Reaper,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(19000000, "Scythe", WeaponCategory.Reaper, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            19060000,
            "Winged Scythe",
            WeaponCategory.Reaper,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Whips
        new(20500000, "Tooth Whip", WeaponCategory.Whip, WeaponLocation.Dlc, WeaponUpgrade.Somber),
        new(20000000, "Whip", WeaponCategory.Whip, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(20070000, "Urumi", WeaponCategory.Whip, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            20050000,
            "Hoslow's Petal Whip",
            WeaponCategory.Whip,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            20030000,
            "Magma Whip Candlestick",
            WeaponCategory.Whip,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Fist & Hand-to-Hand
        new(21510000, "Pata", WeaponCategory.Fist, WeaponLocation.Dlc, WeaponUpgrade.Smithing),
        new(
            21540000,
            "Golem Fist",
            WeaponCategory.Fist,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            60500000,
            "Dryleaf Arts",
            WeaponCategory.Fist,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            60510000,
            "Dane's Footwork",
            WeaponCategory.Fist,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            21500000,
            "Thiollier's Hidden Needle",
            WeaponCategory.Fist,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            21530000,
            "Madding Hand",
            WeaponCategory.Fist,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            21520000,
            "Poisoned Hand",
            WeaponCategory.Fist,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(21000000, "Caestus", WeaponCategory.Fist, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            21010000,
            "Spiked Caestus",
            WeaponCategory.Fist,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(21100000, "Katar", WeaponCategory.Fist, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            21070000,
            "Iron Ball",
            WeaponCategory.Fist,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            21080000,
            "Star Fist",
            WeaponCategory.Fist,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            21110000,
            "Clinging Bone",
            WeaponCategory.Fist,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            21120000,
            "Veteran's Prosthesis",
            WeaponCategory.Fist,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            21130000,
            "Cipher Pata",
            WeaponCategory.Fist,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Claws & Beast Claws
        new(
            68500000,
            "Beast Claw",
            WeaponCategory.Claw,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            22500000,
            "Claws of Night",
            WeaponCategory.Claw,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            68510000,
            "Red Bear's Claw",
            WeaponCategory.Claw,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            22000000,
            "Hookclaws",
            WeaponCategory.Claw,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            22020000,
            "Bloodhound Claws",
            WeaponCategory.Claw,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            22010000,
            "Venomous Fang",
            WeaponCategory.Claw,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            22030000,
            "Raptor Talons",
            WeaponCategory.Claw,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Bows, Greatbows, Crossbows, Ballistas
        new(
            40500000,
            "Bone Bow",
            WeaponCategory.LightBow,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            40050000,
            "Composite Bow",
            WeaponCategory.LightBow,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            40030000,
            "Harp Bow",
            WeaponCategory.LightBow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            41510000,
            "Ansbach's Longbow",
            WeaponCategory.Bow,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(41070000, "Black Bow", WeaponCategory.Bow, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(41020000, "Horn Bow", WeaponCategory.Bow, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(41060000, "Pulley Bow", WeaponCategory.Bow, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(41040000, "Serpent Bow", WeaponCategory.Bow, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(41030000, "Erdtree Bow", WeaponCategory.Bow, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(
            42500000,
            "Igon's Greatbow",
            WeaponCategory.GreatBow,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            42030000,
            "Erdtree Greatbow",
            WeaponCategory.GreatBow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            43500000,
            "Repeating Crossbow",
            WeaponCategory.Crossbow,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            43510000,
            "Spread Crossbow",
            WeaponCategory.Crossbow,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            43020000,
            "Light Crossbow",
            WeaponCategory.Crossbow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            43080000,
            "Arbalest",
            WeaponCategory.Crossbow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            43110000,
            "Crepus's Black-Key Crossbow",
            WeaponCategory.Crossbow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            43050000,
            "Pulley Crossbow",
            WeaponCategory.Crossbow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            43060000,
            "Full Moon Crossbow",
            WeaponCategory.Crossbow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            44500000,
            "Rabbath's Cannon",
            WeaponCategory.Ballista,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            44000000,
            "Hand Ballista",
            WeaponCategory.Ballista,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            44010000,
            "Jar Cannon",
            WeaponCategory.Ballista,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Torches
        new(
            24500000,
            "Nanaya's Torch",
            WeaponCategory.Torch,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            24510000,
            "Lamenting Visage",
            WeaponCategory.Torch,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(24000000, "Torch", WeaponCategory.Torch, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(
            24060000,
            "Beast-Repellent Torch",
            WeaponCategory.Torch,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            24020000,
            "Steel-Wire Torch",
            WeaponCategory.Torch,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            24070000,
            "Sentry's Torch",
            WeaponCategory.Torch,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            24050000,
            "Ghostflame Torch",
            WeaponCategory.Torch,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            24040000,
            "St. Trina's Torch",
            WeaponCategory.Torch,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Perfume Bottles
        new(
            61500000,
            "Firespark Perfume Bottle",
            WeaponCategory.PerfumeBottle,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            61510000,
            "Chilling Perfume Bottle",
            WeaponCategory.PerfumeBottle,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            61520000,
            "Frenzyflame Perfume Bottle",
            WeaponCategory.PerfumeBottle,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            61530000,
            "Lightning Perfume Bottle",
            WeaponCategory.PerfumeBottle,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            61540000,
            "Deadly Poison Perfume Bottle",
            WeaponCategory.PerfumeBottle,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        // Small Shields
        new(
            30510000,
            "Smithscript Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            21550000,
            "Shield of Night",
            WeaponCategory.SmallShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            30090000,
            "Riveted Wooden Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30100000,
            "Blue-White Wooden Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30070000,
            "Red Thorn Roundshield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30040000,
            "Pillory Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30000000,
            "Buckler",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30120000,
            "Iron Roundshield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30130000,
            "Gilded Iron Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30140000,
            "Ice Crest Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30110000,
            "Rift Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31170000,
            "Shield of the Guilty",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30190000,
            "Spiralhorn Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30150000,
            "Smoldering Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            30200000,
            "Coil Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Medium Shields & Thrusting Shields
        new(
            62500000,
            "Dueling Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            62510000,
            "Carian Thrusting Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            62520000,
            "Ritual Thrusting Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            31530000,
            "Golden Lion Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            31520000,
            "Serpent Crest Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            31510000,
            "Wolf Crest Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            31540000,
            "Silver Grooved Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            31270000,
            "Hawk Crest Wooden Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31240000,
            "Horse Crest Wooden Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31250000,
            "Candletree Wooden Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31260000,
            "Flame Crest Wooden Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31020000,
            "Marred Wooden Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31070000,
            "Round Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31230000,
            "Large Leather Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31340000,
            "Black Leather Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31010000,
            "Marred Leather Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31330000,
            "Heater Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31300000,
            "Blue Crest Heater Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31290000,
            "Red Crest Heater Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31280000,
            "Beast Crest Heater Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31320000,
            "Inverted Hawk Heater Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31310000,
            "Eclipse Crest Heater Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31000000,
            "Kite Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31100000,
            "Blue-Gold Kite Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31080000,
            "Scorpion Kite Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31090000,
            "Twinbird Kite Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31190000,
            "Carian Knight's Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            31060000,
            "Silver Mirrorshield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            31140000,
            "Great Turtle Shell",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Greatshields
        new(
            32520000,
            "Verdigris Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            32500000,
            "Black Steel Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            32290000,
            "Wooden Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32050000,
            "Briar Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32170000,
            "Spiked Palisade Shield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32140000,
            "Icon Shield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32090000,
            "Golden Beast Crest Shield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32190000,
            "Manor Towershield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32200000,
            "Crossed-Tree Towershield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32000000,
            "Dragon Towershield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32020000,
            "Distinguished Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32030000,
            "Crucible Hornshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32040000,
            "Dragonclaw Shield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32130000,
            "Fingerprint Stone Shield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32220000,
            "Ant's Skull Plate",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            32080000,
            "Erdtree Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            32120000,
            "Jellyfish Shield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            32160000,
            "Visage Shield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            32150000,
            "One-Eyed Shield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
    };
    public static readonly WeaponEntry[] ChanceWeapons =
    {
        // Daggers
        new(
            1510000,
            "Fire Knight's Shortsword",
            WeaponCategory.Dagger,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(1000000, "Dagger", WeaponCategory.Dagger, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            1090000,
            "Great Knife",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            1140000,
            "Bloodstained Dagger",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            1060000,
            "Celebrant's Sickle",
            WeaponCategory.Dagger,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Straight Swords
        new(
            2050000,
            "Weathered Straight Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            2040000,
            "Lordsworn's Straight Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            2230000,
            "Noble's Slender Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            2240000,
            "Warhawk's Talon",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            2250000,
            "Lazuli Glintstone Sword",
            WeaponCategory.StraightSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Greatswords
        new(
            3520000,
            "Lizard Greatsword",
            WeaponCategory.Greatsword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            3020000,
            "Iron Greatsword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            3040000,
            "Knight's Greatsword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            3080000,
            "Banished Knight's Greatsword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            3010000,
            "Forked Greatsword",
            WeaponCategory.Greatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Colossal Swords
        new(
            4520000,
            "Fire Knight's Greatsword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            4010000,
            "Watchdog's Greatsword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            4110000,
            "Troll Knight's Sword",
            WeaponCategory.ColossalSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Thrusting Swords
        new(
            5060000,
            "Noble's Estoc",
            WeaponCategory.ThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            5010000,
            "Cleanrot Knight's Sword",
            WeaponCategory.ThrustingSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Curved Swords & Backhand Blades
        new(
            64520000,
            "Curseblade Cirque",
            WeaponCategory.CurvedSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            7530000,
            "Horned Warrior's Sword",
            WeaponCategory.CurvedSword,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            7000000,
            "Falchion",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            7150000,
            "Grossmesser",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            7040000,
            "Bandit's Curved Sword",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            7010000,
            "Beastman's Curved Sword",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            7050000,
            "Magma Blade",
            WeaponCategory.CurvedSword,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Curved Greatswords
        new(
            8020000,
            "Dismounter",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            8060000,
            "Omen Cleaver",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            8070000,
            "Monk's Flameblade",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            8080000,
            "Beastman's Cleaver",
            WeaponCategory.CurvedGreatsword,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Axes
        new(
            14520000,
            "Messmer Soldier's Axe",
            WeaponCategory.Axe,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            14540000,
            "Forked-Tongue Hatchet",
            WeaponCategory.Axe,
            WeaponLocation.Dlc,
            WeaponUpgrade.Somber
        ),
        new(
            14010000,
            "Forked Hatchet",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            15010000,
            "Warped Axe",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            14030000,
            "Jawbone Axe",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            14040000,
            "Iron Cleaver",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            14060000,
            "Celebrant's Cleaver",
            WeaponCategory.Axe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Great Axes
        new(
            15030000,
            "Crescent Moon Axe",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            15050000,
            "Longhaft Axe",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            15080000,
            "Executioner's Greataxe",
            WeaponCategory.GreatAxe,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Hammers
        new(11010000, "Club", WeaponCategory.Hammers, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            11030000,
            "Curved Club",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            11070000,
            "Spiked Club",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            11140000,
            "Stone Club",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            11040000,
            "Warpick",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            11090000,
            "Monk's Flamemace",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            11100000,
            "Envoy's Horn",
            WeaponCategory.Hammers,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Great Hammers
        new(
            12020000,
            "Battle Hammer",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            12080000,
            "Curved Great Club",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            12140000,
            "Pickaxe",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            12010000,
            "Greathorn Hammer",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            12160000,
            "Envoy's Long Horn",
            WeaponCategory.GreatHammer,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Colossal Weapons
        new(
            23040000,
            "Duelist Greataxe",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            23120000,
            "Golem's Halberd",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            23140000,
            "Rotten Staff",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            23030000,
            "Envoy's Greathorn",
            WeaponCategory.ColossalWeapon,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Spears
        new(
            16540000,
            "Bloodfiend's Fork",
            WeaponCategory.Spear,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            16150000,
            "Iron Spear",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(16010000, "Spear", WeaponCategory.Spear, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(
            16050000,
            "Partisan",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            16140000,
            "Spiked Spear",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            16030000,
            "Clayman's Harpoon",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            16060000,
            "Celebrant's Rib-Rake",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(16080000, "Torchpole", WeaponCategory.Spear, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(
            16160000,
            "Rotten Crystal Spear",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            16040000,
            "Cleanrot Spear",
            WeaponCategory.Spear,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Halberds
        new(
            18030000,
            "Banished Knight's Halberd",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            18090000,
            "Glaive",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            18130000,
            "Vulgar Militia Shotel",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            18070000,
            "Vulgar Militia Saw",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            18110000,
            "Guardian's Swordspear",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            18010000,
            "Pest's Glaive",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            18060000,
            "Ripple Crescent Halberd",
            WeaponCategory.Halberd,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Reapers
        new(
            19010000,
            "Grave Scythe",
            WeaponCategory.Reaper,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            19020000,
            "Halo Scythe",
            WeaponCategory.Reaper,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Whips
        new(
            20020000,
            "Thorned Whip",
            WeaponCategory.Whip,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Bows, Greatbows & Crossbows
        new(
            40000000,
            "Shortbow",
            WeaponCategory.LightBow,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            40010000,
            "Misbegotten Shortbow",
            WeaponCategory.LightBow,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            40020000,
            "Red Branch Shortbow",
            WeaponCategory.LightBow,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(41000000, "Longbow", WeaponCategory.Bow, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(
            41010000,
            "Albinauric Bow",
            WeaponCategory.Bow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            42010000,
            "Golem Greatbow",
            WeaponCategory.GreatBow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            42040000,
            "Greatbow",
            WeaponCategory.GreatBow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            43000000,
            "Soldier's Crossbow",
            WeaponCategory.Crossbow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        new(
            43030000,
            "Heavy Crossbow",
            WeaponCategory.Crossbow,
            WeaponLocation.Base,
            WeaponUpgrade.Somber
        ),
        // Small Shields
        new(
            30030000,
            "Rickety Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30080000,
            "Scripture Wooden Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30020000,
            "Man-Serpent's Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30010000,
            "Perfumer's Shield",
            WeaponCategory.SmallShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Medium Shields
        new(
            31500000,
            "Messmer Soldier Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Dlc,
            WeaponUpgrade.Smithing
        ),
        new(
            31050000,
            "Sun Realm Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31130000,
            "Brass Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31030000,
            "Banished Knight's Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            31040000,
            "Albinauric Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            30060000,
            "Beastman's Jar-Shield",
            WeaponCategory.MediumShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        // Greatshields
        new(
            32300000,
            "Lordsworn's Shield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32210000,
            "Inverted Hawk Towershield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32270000,
            "Gilded Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32250000,
            "Cuckoo Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32230000,
            "Redmane Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32260000,
            "Golden Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32280000,
            "Haligtree Crest Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
        new(
            32240000,
            "Eclipse Crest Greatshield",
            WeaponCategory.GreatShield,
            WeaponLocation.Base,
            WeaponUpgrade.Smithing
        ),
    };

    public static readonly WeaponEntry[] Staves =
    {
        new(33000000, "Glintstone Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33040000, "Crystal Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33050000, "Gelmir Glintstone Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33060000, "Demi-Human Queen's Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33090000, "Carian Regal Scepter", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(33120000, "Digger's Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33130000, "Astrologer's Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33170000, "Carian Glintblade Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33180000, "Prince of Death's Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33190000, "Albinauric Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33200000, "Academy Glintstone Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33210000, "Carian Glintstone Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33230000, "Azur's Glintstone Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(33240000, "Lusat's Glintstone Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(33250000, "Meteorite Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Somber),
        new(33260000, "Staff of the Guilty", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33270000, "Rotten Crystal Staff", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33280000, "Staff of Loss", WeaponCategory.Staff, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(33510000, "Staff of the Great Beyond", WeaponCategory.Staff, WeaponLocation.Dlc, WeaponUpgrade.Somber),
        new(33520000, "Maternal Staff", WeaponCategory.Staff, WeaponLocation.Dlc, WeaponUpgrade.Somber),
    };

    public static readonly WeaponEntry[] Seals =
    {
        new(34000000, "Finger Seal", WeaponCategory.Seal, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(34010000, "Godslayer's Seal", WeaponCategory.Seal, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(34020000, "Giant's Seal", WeaponCategory.Seal, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(34030000, "Gravel Stone Seal", WeaponCategory.Seal, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(34040000, "Clawmark Seal", WeaponCategory.Seal, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(34060000, "Golden Order Seal", WeaponCategory.Seal, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(34070000, "Erdtree Seal", WeaponCategory.Seal, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(34080000, "Dragon Communion Seal", WeaponCategory.Seal, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(34090000, "Frenzied Flame Seal", WeaponCategory.Seal, WeaponLocation.Base, WeaponUpgrade.Smithing),
        new(34500000, "Dryleaf Seal", WeaponCategory.Seal, WeaponLocation.Dlc, WeaponUpgrade.Smithing),
        new(34510000, "Fire Knight's Seal", WeaponCategory.Seal, WeaponLocation.Dlc, WeaponUpgrade.Smithing),
        new(34520000, "Spiraltree Seal", WeaponCategory.Seal, WeaponLocation.Dlc, WeaponUpgrade.Smithing),
    };

    public static WeaponEntry[] AllWeapons => RemembranceWeapons
        .Concat(GuaranteedWeapons)
        .Concat(ChanceWeapons)
        .Concat(Staves)
        .Concat(Seals)
        .ToArray();

    public static IEnumerable<WeaponEntry> GetSmithingByCategory(WeaponCategory category) =>
        GetAllSmithingWeapons().Where(w => w.Category == category);

    public static IEnumerable<WeaponEntry> GetByCategory(WeaponCategory category) =>
        AllWeapons.Where(w => w.Category == category);
}
