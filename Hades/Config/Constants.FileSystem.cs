// SPDX-License-Identifier: GPL-3.0-only
using System.IO;

namespace Hades.Config;

internal partial class Constants
{
    // Mod Configuration
    public static string ModEngineWorkingDirectory = Path.Combine("Resources", "me3-v0.8.0");
    public static string RegulationBase = Path.Combine("Resources", "Regulation");

    public static string MenuBndDirectory = Path.Combine("Resources", "Bnd");
    public static string MenuBndVanilla = Path.Combine(
        MenuBndDirectory,
        "vanilla",
        "menu_dlc02.msgbnd.dcx"
    );
    public static string MenuBndInBase = MenuBndVanilla;
    public static string MenuBndInBaseDlc = Path.Combine(
        MenuBndDirectory,
        "basedlc",
        "menu_dlc02.msgbnd.dcx"
    );

    public static string MenuBndOutBase = Path.Combine(
        ModEngineWorkingDirectory,
        "base",
        "msg",
        "engus",
        "menu_dlc02.msgbnd.dcx"
    );
    public static string MenuBndOutBaseDlc = Path.Combine(
        ModEngineWorkingDirectory,
        "basedlc",
        "msg",
        "engus",
        "menu_dlc02.msgbnd.dcx"
    );
    public static string MenuBndOutBaseDlcVCC = Path.Combine(ModEngineWorkingDirectory, "basedlc");
    public static string MenuBndOutDlc = Path.Combine(ModEngineWorkingDirectory, "dlc");

    public static string VanillaRegulation = Path.Combine(
        RegulationBase,
        "vanilla",
        "regulation.bin"
    );
    public static string RegulationInBase = Path.Combine(RegulationBase, "base", "regulation.bin");
    public static string RegulationInBaseDlc = Path.Combine(
        RegulationBase,
        "basedlc",
        "regulation.bin"
    );
    public static string RegulationInDlc = Path.Combine(RegulationBase, "dlc", "regulation.bin");

    public static string RegulationOutBase = Path.Combine(
        ModEngineWorkingDirectory,
        "base",
        "regulation.bin"
    );
    public static string RegulationOutBaseDlc = Path.Combine(
        ModEngineWorkingDirectory,
        "basedlc",
        "regulation.bin"
    );
    public static string RegulationOutDlc = Path.Combine(
        ModEngineWorkingDirectory,
        "dlc",
        "regulation.bin"
    );

    public static string MapFolderDlc = Path.Combine(
        ModEngineWorkingDirectory,
        "dlc",
        "map",
        "MapStudio"
    );

    // Launch Configuration
    public static string LaunchEldenRingBase = "launch-eldenring-base.bat";
    public static string LaunchEldenRingBaseDlc = "launch-eldenring-basedlc.bat";
    public static string LaunchEldenRingDlc = "launch-eldenring-dlc.bat";

    // Metadata
    public static string RandomizationGroups = Path.Combine("Resources", "RandomizationGroups");
    public static string RandomizationGroupsBase = Path.Combine(RandomizationGroups, "base");
    public static string RandomizationGroupsBaseDlc = Path.Combine(RandomizationGroups, "basedlc");
    public static string RandomizationGroupsDlc = Path.Combine(RandomizationGroups, "dlc");

    public static string GameData = Path.Combine("Resources", "GameData");

    public static string Misc = Path.Combine("Resources", "Misc");

    public static string ModeFolders = Path.Combine("Resources", "ModeFolders");
}
