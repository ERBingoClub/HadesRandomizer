namespace Hades.Services;

public record struct StartingStats
{
    public int Vigor { get; init; }
    public int Mind { get; init; }
    public int Endurance { get; init; }
    public int Strength { get; init; }
    public int Dexterity { get; init; }
    public int Intelligence { get; init; }
    public int Faith { get; init; }
    public int Arcane { get; init; }
    public short? RuneLevel { get; init; }
}

public delegate StartingStats ClassStatRoller(string className, string seed);