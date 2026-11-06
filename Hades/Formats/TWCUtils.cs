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
    public static readonly List<int> FillerTalismans =
    [
        2160, // Lord of Bloods Exultation
        2170, // Kindred of Rots Exultation
        5000, // Crimson Seed
        5020, // Blessed Dew
        1110, // Golden Scarab
        2020, // Fire scorpion Charm
        2010, // Lightning Scorpion Charm
        2000, // Magic Scorpion Charm
        2030, // Sacred Scorpion Charm
        1221, // Marika's Soreseal
        1051, // Radagon's Soreseal
    ];
    public static readonly List<int> GoodTalismans =
    [
        4090, // Ritual Shield
        2050, // Ritual Sword
        2081, // Rotten Winged Sword
        1231, // Shard of Alexander
        2130, // Axe Talisman
        2110, // BlueDancerCharm
        2180, // Claw Talisman
        1150, // Green Turtle
        4003, // Dragoncrest Greatshield Talisman
        1250, // Millicents Prosthesis
        2090, // Dagger Talisman
    ];
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
