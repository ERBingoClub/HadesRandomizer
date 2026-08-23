using System.IO;
using System.Security.Cryptography;
using System.Text;
using EldenRingParamsEditor;
using Hades.Config;
using Hades.Services;

namespace Hades.Formats;

class TwoWorldsCollide : IRandomizerFormat
{
    public string Id => "twc";
    public string DisplayName => "Two Worlds Collide";
    public string Me3File => "twc.me3";
    private EldenRingLauncherService _launcherService = new EldenRingLauncherService();

    public void Exec(string baseSeed, Action<string>? statusCallback = null) { }

    public void Launch()
    {
        _launcherService.LaunchEldenRingFromMe3File(Me3File);
    }
}
