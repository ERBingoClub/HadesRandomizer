// SPDX-License-Identifier: GPL-3.0-only
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Services;
using Hades.Config;

namespace Hades.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly AppConfig _config;

    public ObservableCollection<ModeTabViewModelBase> ModeTabs { get; } =
        new()
        {
            new TabViewModelBase { Title = "Base Game", Description = "Base Game" },
            new TabViewModelBaseDlc { Title = "Base Game + DLC", Description = "Base Game + DLC" },
            new TabViewModelDlc { Title = "DLC", Description = "DLC" },
        };

    private ModeTabViewModelBase _selectedTab;
    public ModeTabViewModelBase SelectedTab
    {
        get => _selectedTab;
        set
        {
            if (_selectedTab != value)
            {
                _selectedTab = value;
                _config.LastOpenedTabTitle = value.Title;
                ConfigService.Save(_config);
                OnPropertyChanged(nameof(SelectedTab));
            }
        }
    }

    public MainWindowViewModel()
    {
        _config = ConfigService.Load();

        // default tab

        if (_config.LastOpenedTabTitle != null)
        {
            _selectedTab =
                ModeTabs.Where(t => t.Title == _config.LastOpenedTabTitle).First() ?? ModeTabs[0];
        }
        else
        {
            _selectedTab = ModeTabs[0];
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
