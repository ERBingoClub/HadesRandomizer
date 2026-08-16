// SPDX-License-Identifier: GPL-3.0-only
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hades.ViewModels;

public abstract class ModeTabViewModelBase
{
    public string AppVersion { get; } = "v0.22";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
}
