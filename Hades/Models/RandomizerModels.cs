// SPDX-License-Identifier: GPL-3.0-only
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hades.Utilities;

namespace Hades.Models;

public interface INamedItem
{
    int ID { get; }
    string Name { get; }
}

public interface IGameItem : INamedItem
{
    byte EquipType { get; }
    int Category { get; }
}

public record GameItemModel(int ID, string Name, byte EquipType, int Category) : IGameItem;

public record CustomWeaponModel(
    int ID,
    string Name,
    byte EquipType,
    int Category,
    int BaseWeaponID,
    int GemID,
    byte ReinforceLevel
) : IGameItem;

public record ShopItemModel(
    int ID,
    string Name,
    int Cost,
    string Type,
    string ParamType,
    byte EquipType,
    uint? EventFlagID,
    short SellQuantity
) : INamedItem;

public record ArmorSetModel(
    string Name,
    int? HelmID,
    int? TorsoID,
    int? GauntletsID,
    int? GreavesID
);

public record StatAllocationModel(
    string? ClassName,
    int Vigor,
    int Mind,
    int Endurance,
    int Strength,
    int Dexterity,
    int Intelligence,
    int Faith,
    int Arcane
);

public record WeaponModel(
    string WeaponClass,
    int ID,
    string Name,
    byte EquipType,
    int Category,
    int WepType
) : IGameItem;

public record GracePoolModel(int ID, string GraceName, string GraceRegion);

