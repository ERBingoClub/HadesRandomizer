using SoulsFormats;
using System.IO;

namespace Hades.Services;

public class MenuBndEditorService
{
    BND4 menuBnd;
    FMG lineHelp;
    public static readonly int[] LineHelpClassDescriptionIDs = { 297130, 297131, 297132, 297133, 297134, 297135, 297138, 297136, 297137, 297139, 297140, 297141 };

    private MenuBndEditorService(string menuBndFilePathIn) {
        byte[] menuBndBytes = File.ReadAllBytes(menuBndFilePathIn);
        menuBnd = BND4.Read(menuBndBytes);
        FMG? menuLineHelp = null;
        foreach (BinderFile file in menuBnd.Files)
        {
            if (Path.GetFileName(file.Name) == "GR_LineHelp.fmg")
                menuLineHelp = FMG.Read(file.Bytes);
        }
        if (menuLineHelp == null)
            throw new Exception("Failed to read GR_LineHelp.fmg from menu_bnd");
        lineHelp = menuLineHelp;
    }

    public void SetClassDescription(int classIndex, string classDescription)
    {
        int fmgId = LineHelpClassDescriptionIDs[classIndex];
        lineHelp[fmgId] = classDescription;
    }

    public static MenuBndEditorService ReadFromMenuBndFilePath(string path) => new(path);

    public void WriteToMenuBndFilePath(string pathOut)
    {
        foreach (var file in menuBnd.Files)
            if (Path.GetFileName(file.Name) == "GR_LineHelp.fmg")
                file.Bytes = lineHelp.Write();

        var bytes = menuBnd.Write();
        Directory.CreateDirectory(Path.GetDirectoryName(pathOut)!);
        File.WriteAllBytes(pathOut, bytes);
    }
}
