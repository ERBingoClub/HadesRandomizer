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

public class TabViewModelDlc : ModeTabViewModelBase, INotifyPropertyChanged
{
    private readonly AppConfig _config;
    private readonly RandomizerServiceDlc _randomizerService;
    private readonly EldenRingLauncherService _launcherService;

    private DlcMode _dlcMode = DlcMode.Default;
    public DlcMode DlcMode
    {
        get => _dlcMode;
        set
        {
            if (_dlcMode != value)
            {
                _dlcMode = value;
                OnPropertyChanged();
            }
        }
    }

    private DlcMode? _randomizedDlcMode;
    public DlcMode? RandomizedDlcMode
    {
        get => _randomizedDlcMode;
        set
        {
            if (_randomizedDlcMode != value)
            {
                _randomizedDlcMode = value;
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

    private List<string> _weaponsInTheStarlightShop = new List<string>();
    public List<string> WeaponsInTheStarlightShop
    {
        get => _weaponsInTheStarlightShop;
        set
        {
            if (_weaponsInTheStarlightShop != value)
            {
                _weaponsInTheStarlightShop = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasWeapons));
                OnPropertyChanged(nameof(WeaponsDisplayText));
            }
        }
    }
    public bool HasWeapons =>
        WeaponsInTheStarlightShop != null && WeaponsInTheStarlightShop.Count > 0;
    public string WeaponsDisplayText =>
        WeaponsInTheStarlightShop != null && WeaponsInTheStarlightShop.Count > 0
            ? string.Join(" | ", WeaponsInTheStarlightShop)
            : string.Empty;

    public int? ParsedBaseSeed => int.TryParse(BaseSeedInput, out int parsed) ? parsed : null;

    public ICommand RandomizeCommand { get; }
    public ICommand LaunchCommand { get; }

    public TabViewModelDlc()
    {
        _config = ConfigService.Load();
        BaseSeed = _config.LastUsedSeedDlc;
        BaseSeedInput = _config.LastUsedSeedDlc?.ToString();
        RandomizedSeed = _config.LastRandomizedSeedDlc;
        RandomizedDlcMode = _config.LastRandomizedModeDlc;
        DlcMode = _config.LastRandomizedModeDlc ?? DlcMode.Default;

        _randomizerService = new RandomizerServiceDlc(AppVersion);
        _launcherService = new EldenRingLauncherService();

        RandomizeCommand = new RelayCommand(
            () =>
                _randomizerService.RandomizeDlc(
                    ParsedBaseSeed,
                    DlcMode,
                    newSeed =>
                    {
#if DEBUG
                        Debug.WriteLine($"baseSeed: {newSeed}");
#endif
                        BaseSeed = newSeed;
                        BaseSeedInput = newSeed.ToString();
                        _config.LastUsedSeedDlc = newSeed;
                        ConfigService.Save(_config);
                    },
                    newRandomizedSeed =>
                    {
#if DEBUG
                        Debug.WriteLine($"randomizedSeed: {newRandomizedSeed}");
#endif
                        RandomizedSeed = newRandomizedSeed;
                        _config.LastRandomizedSeedDlc = newRandomizedSeed;
                        ConfigService.Save(_config);
                    },
                    newRandomizedDlcMode =>
                    {
#if DEBUG
                        Debug.WriteLine($"randomizedDlcMode: {newRandomizedDlcMode}");
#endif
                        RandomizedDlcMode = newRandomizedDlcMode;
                        _config.LastRandomizedModeDlc = newRandomizedDlcMode;
                        ConfigService.Save(_config);
                    },
                    weaponsList => // <-- ADD THIS COMMA AND NEW CALLBACK
                    {
#if DEBUG
                        Debug.WriteLine($"Weapons in shop: {string.Join(", ", weaponsList)}");
#endif
                        WeaponsInTheStarlightShop = weaponsList;
                    }
                ),
            () =>
                !(
                    (BaseSeed == RandomizedSeed)
                    && (BaseSeed != null)
                    && (RandomizedDlcMode == DlcMode)
                )
        );

        LaunchCommand = new RelayCommand(
            () => _launcherService.LaunchEldenRing(LaunchMode.DLC),
            () =>
                (BaseSeed == RandomizedSeed) && (BaseSeed != null) && (RandomizedDlcMode == DlcMode)
        );
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
