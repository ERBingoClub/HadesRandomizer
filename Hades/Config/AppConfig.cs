using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hades.Services;

namespace Hades.Config;

public class AppConfig
{
    // Global
    public string? LastOpenedTabTitle { get; set; }

    // DLC
    public int? LastUsedSeedDlc { get; set; }
    public DlcMode? LastRandomizedModeDlc { get; set; }
    public int? LastRandomizedSeedDlc { get; set; }

    // Base DLC
    public int? LastUsedSeedBaseDlc { get; set; }
    public int? LastRandomizedSeedBaseDlc { get; set; }

    public BaseDlcMode? LastRandomizedModeBaseDlc { get; set; } // Save the Gamemode chosen

    // Base
    public int? LastUsedSeedBase { get; set; }
    public int? LastRandomizedSeedBase { get; set; }
}
