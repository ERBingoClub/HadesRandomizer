namespace Hades.Formats;

public static class TWCConstants
{
    public static readonly Dictionary<string, int> ShopLineupMap = new Dictionary<string, int>()
    {
        ["talisman_1"] = 101882,
        ["talisman_2"] = 101883,
        ["talisman_3"] = 101884,
        ["talisman_4"] = 101897,
        ["physick_1"] = 101874,
        ["physick_2"] = 101875,
        ["physick_3"] = 101876,
        ["physick_4"] = 101877,
    };
    public static readonly List<int> TalismanPool = new()
    {
        1002, // Crimson Amber Medallion +2
        5020, // Blessed Dew Talisman
        1032, // Great-Jar's Arsenal
        1012, // Cerulean Amber Medallion +2
        5000, // Crimson Seed Talisman
        1042, // Erdtree's Favor +2
        1022, // Viridian Amber Medallion +2
        5010, // Cerulean Seed Talisman
        4002, // Dragoncrest Shield +2
        1171, // Immunizing Horn Charm +1
        2090, // Dagger Talisman
        4052, // Pearldrake Talisman +2
        1161, // Stalwart Horn Charm +1
        2120, // Twinblade Talisman
        3060, // Old Lord's Talisman
        1181, // Clarifying Horn Charm +1
        2060, // Spear Talisman
        6020, // Carian Filigreed Crest
        1201, // Mottled Necklace +1
        2180, // Claw Talisman
        3090, // Godfrey Icon
        1191, // Prince of Death's Cyst
        2150, // Arrow's Sting Talisman
        2110, // Blue Dancer Charm
        2000, // Magic Scorpion Charm
        2020, // Fire Scorpion Charm
        2081, // Rotten Winged Sword Insignia
        2010, // Lightning Scorpion Charm
        2030, // Sacred Scorpion Charm
        5050, // Assassin's Crimson Dagger
        1110, // Gold Scarab
        6000, // Crepus's Vial
        5060, // Assassin's Cerulean Dagger
        6110, // Ancestral Spirit's Horn
        5030, // Taker's Cameo
        6040, // Longtail Cat Talisman
    };

    public static readonly List<int> PhysickTearPool = new()
    {
        11021, // Strength-knot Crystal Tear
        11010, // Greenburst Crystal Tear
        11029, // Magic-Shrouding Cracked Tear
        11022, // Dexterity-knot Crystal Tear
        11011, // Opaline Hardtear
        11028, // Flame-Shrouding Cracked Tear
        11023, // Intelligence-knot Crystal Tear
        11026, // Stonebarb Cracked Tear
        11030, // Lightning-Shrouding Cracked Tear
        11024, // Faith-knot Crystal Tear
        11007, // Crimson Bubbletear
        11031, // Holy-Shrouding Cracked Tear
        11014, // Spiked Cracked Tear
        11008, // Opaline Bubbletear
        11012, // Winged Crystal Tear
        11013, // Thorny Cracked Tear
        11019, // Twiggy Cracked Tear
        11015, // Windy Crystal Tear
    };
}
