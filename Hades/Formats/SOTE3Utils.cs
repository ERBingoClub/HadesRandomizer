namespace Hades.Formats;

public struct TalismanResults
{
    public int fillerTalisman_1;
    public int fillerTalisman_2;
    public int goodTalisman_1;
    public int goodTalisman_2;
}

public struct ClassArmorResults
{
    public ArmorResults Vagabond;
    public ArmorResults Warrior;
    public ArmorResults Hero;
    public ArmorResults Bandit;
    public ArmorResults Astrologer;
    public ArmorResults Confessor;
    public ArmorResults Samurai;
    public ArmorResults Prisoner;
    public ArmorResults Prophet;
}

public struct ArmorResults
{
    public int Arms;
    public int Legs;
    public int Chest;
    public int Helm;
}

public static class SOTE3Constants
{
    public static readonly Dictionary<string, int> shopLineupMap = new Dictionary<string, int>()
    {
        ["fillerTalisman_1"] = 1700161,
        ["fillerTalisman_2"] = 1700160,
        ["goodTalisman_1"] = 1700159,
        ["goodTalisman_2"] = 1700158,
    };
    public static readonly int[] FillerTalismans =
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
    public static readonly int[] GoodTalismans =
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
}
