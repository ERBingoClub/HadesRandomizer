using Hades.Constants;

namespace Hades.Services;

public struct ArmorResults
{
    public int Arms;
    public int Legs;
    public int Chest;
    public int Helm;
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

public static class ArmorRandomizerService
{
    public static ClassArmorResults GetRandomArmoredClasses(string seed, ArmorLocation locn)
    {
        return new ClassArmorResults
        {
            Vagabond = GetRandomArmor(seed + "_vagabond", locn),
            Warrior = GetRandomArmor(seed + "_warrior", locn),
            Hero = GetRandomArmor(seed + "_hero", locn),
            Astrologer = GetRandomArmor(seed + "_astrologer", locn),
            Prisoner = GetRandomArmor(seed + "_prisoner", locn),
            Prophet = GetRandomArmor(seed + "_prophet", locn),
            Confessor = GetRandomArmor(seed + "_confessor", locn),
            Samurai = GetRandomArmor(seed + "_samurai", locn),
            Bandit = GetRandomArmor(seed + "_bandit", locn),
        };
    }

    public static ArmorResults GetRandomArmor(string seed, ArmorLocation locn)
    {
        var arm = Utils.RandoUtils.GetRandomNumber(
            seed + "_arms",
            Armors.Get(Gauntlets.All, locn).Count()
        );
        var legs = Utils.RandoUtils.GetRandomNumber(
            seed + "_legs",
            Armors.Get(Greaves.All, locn).Count()
        );
        var chest = Utils.RandoUtils.GetRandomNumber(
            seed + "_chest",
            Armors.Get(ChestArmor.All, locn).Count()
        );
        var helm = Utils.RandoUtils.GetRandomNumber(
            seed + "_helm",
            Armors.Get(Helms.All, locn).Count()
        );

        return new ArmorResults
        {
            Arms = arm,
            Legs = legs,
            Chest = chest,
            Helm = helm,
        };
    }
}
