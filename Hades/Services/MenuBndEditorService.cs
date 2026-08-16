using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoulsFormats;

namespace Hades.Services;

public class MenuBndEditorService
{
    BND4 menuBnd;
    FMG lineHelp;
    public static readonly int[] LineHelpClassDescriptionIDs =
    {
        297130,
        297131,
        297132,
        297133,
        297134,
        297135,
        297138,
        297136,
        297137,
        297139,
    };

    private MenuBndEditorService(string menuBndFilePathIn)
    {
        byte[] menuBndBytes = File.ReadAllBytes(menuBndFilePathIn);
        menuBnd = BND4.Read(menuBndBytes);
        FMG? menuLineHelp = null;
        foreach (BinderFile file in menuBnd.Files)
        {
            if (Path.GetFileName(file.Name) == "GR_LineHelp.fmg")
            {
                menuLineHelp = FMG.Read(file.Bytes);
            }
        }
        if (menuLineHelp == null)
        {
            throw new Exception(
                "Failed to read FMG file necessary for rewriting starting class descriptions."
            );
        }
        lineHelp = menuLineHelp;
    }

    public void SetClassDescription(int i, string classDescription)
    {
        int lineHelpFmgIndex = LineHelpClassDescriptionIDs[i];
        lineHelp[lineHelpFmgIndex] = classDescription;
    }

    public static MenuBndEditorService ReadFromMenuBndFilePath(string menuBndFilePathIn)
    {
        return new(menuBndFilePathIn);
    }

    public void WriteToMenuBndFilePath(string menuBndFilePathOut)
    {
        if (menuBnd != null)
        {
            foreach (BinderFile file in menuBnd.Files)
            {
                if (Path.GetFileName(file.Name) == "GR_LineHelp.fmg")
                {
                    file.Bytes = lineHelp.Write();
                }
            }
            byte[] menuBndBytes = menuBnd.Write();

            Directory.CreateDirectory(Path.GetDirectoryName(menuBndFilePathOut)!);
            File.WriteAllBytes(menuBndFilePathOut, menuBndBytes);
        }
    }
}
