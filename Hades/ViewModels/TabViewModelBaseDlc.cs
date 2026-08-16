// SPDX-License-Identifier: GPL-3.0-only
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Athena.Config;
using Athena.Services;
using Hades.Commands;

namespace Hades.ViewModels;

public class TabViewModelBaseDlc : ModeTabViewModelBase, INotifyPropertyChanged
{
    private readonly AppConfig _config;
    private readonly RandomizerServiceBaseDlc _randomizerService;
    private readonly EldenRingLauncherService _launcherService;

    private BaseDlcMode _baseDlcMode = BaseDlcMode.Default;
    public BaseDlcMode BaseDlcMode
    {
        get => _baseDlcMode;
        set
        {
            if (_baseDlcMode != value)
            {
                _baseDlcMode = value;
                OnPropertyChanged();
            }
        }
    }

    private BaseDlcMode? _randomizeBaseDlcMode;
    public BaseDlcMode? RandomizedBaseDlcMode
    {
        get => _randomizeBaseDlcMode;
        set
        {
            if (_randomizeBaseDlcMode != value)
            {
                _randomizeBaseDlcMode = value;
                OnPropertyChanged();
            }
        }
    }

    private int? _baseSeed;
    public int? BaseSeed
    {
        get => _baseSeed;
        set
        {
            if (_baseSeed != value)
            {
                _baseSeed = value;
                OnPropertyChanged();
            }
        }
    }

    private int? _randomizedSeed;
    public int? RandomizedSeed
    {
        get => _randomizedSeed;
        set
        {
            if (_randomizedSeed != value)
            {
                _randomizedSeed = value;
                OnPropertyChanged();
            }
        }
    }

    private string? _baseSeedInput;
    public string? BaseSeedInput
    {
        get => _baseSeedInput;
        set
        {
            if (_baseSeedInput != value)
            {
                _baseSeedInput = value;
                BaseSeed = int.TryParse(BaseSeedInput, out int parsed) ? parsed : null;
                OnPropertyChanged();
            }
        }
    }

    public int? ParsedBaseSeed => int.TryParse(BaseSeedInput, out int parsed) ? parsed : null;

    private List<string> _randomizedGraces = new();

    public List<string> RandomizedGraces
    {
        get => _randomizedGraces;
        set
        {
            if (_randomizedGraces != value)
            {
                _randomizedGraces = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(HasRandomizedGraces));
                OnPropertyChanged(nameof(RandomizedGracesDisplayText));
            }
        }
    }

    public bool HasRandomizedGraces => RandomizedGraces != null && RandomizedGraces.Count > 0;

    public string RandomizedGracesDisplayText =>
        RandomizedGraces != null && RandomizedGraces.Count > 0
            ? string.Join(" | ", RandomizedGraces)
            : string.Empty;

    public ICommand RandomizeCommand { get; }
    public ICommand LaunchCommand { get; }

    public TabViewModelBaseDlc()
    {
        _config = ConfigService.Load();
        BaseSeed = _config.LastUsedSeedBaseDlc;
        BaseSeedInput = _config.LastUsedSeedBaseDlc?.ToString();
        RandomizedSeed = _config.LastRandomizedSeedBaseDlc;

        RandomizedBaseDlcMode = _config.LastRandomizedModeBaseDlc;
        BaseDlcMode = _config.LastRandomizedModeBaseDlc ?? BaseDlcMode.Default;

        _randomizerService = new RandomizerServiceBaseDlc(AppVersion);
        _launcherService = new EldenRingLauncherService();

        RandomizeCommand = new RelayCommand(
            () =>
                _randomizerService.RandomizeBaseDlc(
                    ParsedBaseSeed,
                    BaseDlcMode,
                    newSeed =>
                    {
                        Debug.WriteLine($"baseSeed: {newSeed}");
                        BaseSeed = newSeed;
                        BaseSeedInput = newSeed.ToString();
                        _config.LastUsedSeedBaseDlc = newSeed;
                        ConfigService.Save(_config);
                    },
                    newRandomizedSeed =>
                    {
                        Debug.WriteLine($"randomizedSeed: {newRandomizedSeed}");
                        RandomizedSeed = newRandomizedSeed;
                        _config.LastRandomizedSeedBaseDlc = newRandomizedSeed;
                        ConfigService.Save(_config);
                    },
                    newRandomizedBaseDlcMode =>
                    {
                        RandomizedBaseDlcMode = newRandomizedBaseDlcMode;
                        _config.LastRandomizedModeBaseDlc = newRandomizedBaseDlcMode;
                        ConfigService.Save(_config);
                    },
                    graceList =>
                    {
#if DEBUG
                        Debug.WriteLine($"Randomized graces: {string.Join(", ", graceList)}");
#endif

                        RandomizedGraces = graceList;
                    }
                ),
            () =>
                !(
                    (BaseSeed == RandomizedSeed)
                    && (BaseSeed != null)
                    && (RandomizedBaseDlcMode == BaseDlcMode)
                )
        );

        LaunchCommand = new RelayCommand(
            () => _launcherService.LaunchEldenRing(LaunchMode.BaseDlc),
            () =>
                (BaseSeed == RandomizedSeed)
                && (BaseSeed != null)
                && (RandomizedBaseDlcMode == BaseDlcMode)
        );
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
