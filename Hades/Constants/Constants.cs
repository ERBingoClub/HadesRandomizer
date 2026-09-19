using System.IO;

namespace Hades.Constants;

internal partial class GlobalConstants
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
        ["Wretch"] = 3009,
    };
}
