// SPDX-License-Identifier: GPL-3.0-only
using SoulsFormats;
using Andre.Formats;
using System.Diagnostics;
using System.IO.Enumeration;

namespace EldenRingParamsEditor;

public partial class ParamsEditor
{
    private BND4 _regulationBnd;

    private Param? _itemLotMap;
    private Dictionary<int, int>? _idToRowIndexItemLotMap;
    public Param ItemLotMap
    {
        get {
            if (_itemLotMap == null)
            {
                _idToRowIndexItemLotMap = new();
                _itemLotMap = initParamFromBnd(ItemLotParam_map, ItemLotParamDef, _idToRowIndexItemLotMap);
            }
            return _itemLotMap;
        }
    }

    private Param? _itemLotEnemy;
    private Dictionary<int, int>? _idToRowIndexItemLotEnemy;
    public Param ItemLotEnemy
    {
        get
        {
            if (_itemLotEnemy == null)
            {
                _idToRowIndexItemLotEnemy = new();
                _itemLotEnemy = initParamFromBnd(ItemLotParam_enemy, ItemLotParamDef, _idToRowIndexItemLotEnemy);
            }
            return _itemLotEnemy;
        }
    }

    private Param? _shopLineup;
    private Dictionary<int, int>? _idToRowIndexShopLineup;
    public Param ShopLineup
    {
        get
        {
            if (_shopLineup == null)
            {
                _idToRowIndexShopLineup = new();
                _shopLineup = initParamFromBnd(ShopLineupParam, ShopLineupParamDef, _idToRowIndexShopLineup);
            }
            return _shopLineup;
        }
    }

    private Param? _charaInit;
    private Dictionary<int, int>? _idToRowIndexCharaInit;
    public Param CharaInit
    {
        get
        {
            if (_charaInit == null)
            {
                _idToRowIndexCharaInit = new();
                _charaInit = initParamFromBnd(CharaInitParam, CharaInitParamDef, _idToRowIndexCharaInit);
            }
            return _charaInit;
        }
    }

    private Param? _equipGoods;
    public Dictionary<int, int>? _idToRowIndexEquipGoods;
    public Param EquipGoods
    {
        get
        {
            if (_equipGoods == null)
            {
                _idToRowIndexEquipGoods = new();
                _equipGoods = initParamFromBnd(EquipParamGoods, EquipParamGoodsParamDef, _idToRowIndexEquipGoods);
            }
            return _equipGoods;
        }
    }

    private Param? _equipWeapon;
    public Dictionary<int, int>? _idToRowIndexEquipWeapon;
    public Param EquipWeapon
    {
        get
        {
            if (_equipWeapon == null)
            {
                _idToRowIndexEquipWeapon = new();
                _equipWeapon = initParamFromBnd(EquipParamWeapon, EquipParamWeaponParamDef, _idToRowIndexEquipWeapon);
            }
            return _equipWeapon;
        }
    }

    private Param? _equipCustomWeapon;
    public Dictionary<int, int>? _idToRowIndexEquipCustomWeapon;
    public Param EquipCustomWeapon
    {
        get
        {
            if (_equipCustomWeapon == null)
            {
                _idToRowIndexEquipCustomWeapon = new();
                _equipCustomWeapon = initParamFromBnd(EquipParamCustomWeapon, EquipParamCustomWeaponParamDef, _idToRowIndexEquipCustomWeapon);
            }
            return _equipCustomWeapon;
        }
    }

    private Param? _equipProtector;
    public Dictionary<int, int>? _idToRowIndexEquipProtector;
    public Param EquipProtector
    {
        get
        {
            if (_equipProtector == null)
            {
                _idToRowIndexEquipProtector = new();
                _equipProtector = initParamFromBnd(EquipParamProtector, EquipParamProtectorParamDef, _idToRowIndexEquipProtector);
            }
            return _equipProtector;
        }
    }

    private Param? _spEffect;
    public Dictionary<int, int>? _idToRowIndexSpEffect;
    public Param SpEffect
    {
        get
        {
            if (_spEffect == null)
            {
                _idToRowIndexSpEffect = new();
                _spEffect = initParamFromBnd(SpEffectParam, SpEffectParamDef, _idToRowIndexSpEffect);
            }
            return _spEffect;
        }
    }

    private Param? _bonfireWarp;
    private Dictionary<int, int> _idToRowIndexBonfireWarp;
    public Param BonfireWarp
    {
        get
        {
            if (_bonfireWarp == null)
            {
                _idToRowIndexBonfireWarp = new();
                _bonfireWarp = initParamFromBnd(BonfireWarpParam, BonfireWarpParamDef, _idToRowIndexBonfireWarp);
            }
            return _bonfireWarp;
        }
    }

    // only has 1 row: doesn't need a paramID:rowIndex dictionary
    private Param? _gameSystemCommon;
    public Param GameSystemCommon
    {
        get
        {
            if (_gameSystemCommon == null)
            {
                _gameSystemCommon = initParamFromBnd(GameSystemCommonParam, GameSystemCommonParamDef);
            }
            return _gameSystemCommon;
        }
    }

    // Params constants for reading/writing to regulation.bin
    public const string ItemLotParam_map = "ItemLotParam_map.param";
    public const string ItemLotParam_enemy = "ItemLotParam_enemy.param";
    public const string ItemLotParamDef = "ItemLotParam";

    public const string EquipParamGoods = "EquipParamGoods.param";
    public const string EquipParamGoodsParamDef = "EquipParamGoods";

    public const string EquipParamWeapon = "EquipParamWeapon.param";
    public const string EquipParamWeaponParamDef = "EquipParamWeapon";

    public const string EquipParamCustomWeapon = "EquipParamCustomWeapon.param";
    public const string EquipParamCustomWeaponParamDef = "EquipParamCustomWeapon";

    public const string EquipParamProtector = "EquipParamProtector.param";
    public const string EquipParamProtectorParamDef = "EquipParamProtector";

    public const string ShopLineupParam = "ShopLineupParam.param";
    public const string ShopLineupParamDef = "ShopLineupParam";

    public const string CharaInitParam = "CharaInitParam.param";
    public const string CharaInitParamDef = "CharaInitParam";

    public const string SpEffectParam = "SpEffectParam.param";
    public const string SpEffectParamDef = "SpEffectParam";

    public const string GameSystemCommonParam = "GameSystemCommonParam.param";
    public const string GameSystemCommonParamDef = "GameSystemCommonParam";

    public const string BonfireWarpParam = "BonfireWarpParam.param";
    public const string BonfireWarpParamDef = "BonfireWarpParam";

    private ParamsEditor(string regulationPath)
    {
        try
        {
            _regulationBnd = SFUtil.DecryptERRegulation(regulationPath);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to decrypt regulation.bin from given {nameof(regulationPath)}: {regulationPath}. Error: ${ex.Message.ToString()}");
        }
    }

    private static Param initParam(BinderFile file, string paramdefName, Dictionary<int, int>? idToRowIndex = null)
    {
        PARAMDEF paramdef = ResourceManager.GetParamDefByName(paramdefName);
        Param param = Param.Read(file.Bytes);
        param.ApplyParamdef(paramdef);
        if (idToRowIndex != null)
        {
            //Debug.WriteLine($"Fetching IDs to rowIndex for {paramdefName}");
            int i = 0;
            foreach (Param.Row row in param.Rows)
            {
                idToRowIndex[row.ID] = i++;
            }
        }
        return param;
    }

    private Param initParamFromBnd(string paramname, string paramdefName, Dictionary<int, int>? idToRowIndex = null)
    {
        foreach (BinderFile file in _regulationBnd.Files)
        {
            if (Path.GetFileName(file.Name) == paramname)
            {
                return initParam(file, paramdefName, idToRowIndex);
            }
        }

        throw new Exception($"Param {paramname} could not be found in the decrypted regulation.bin");
    }

    private object GetValueAtCell(Param param, Dictionary<int, int>? idToRowIndex, int idOrRowIndex, int colIndex)
    {
        if (param.Rows.Count > 0)
        {
            
        }
        int rowIndex = idOrRowIndex;
        if (idToRowIndex != null)
        {
            if (!idToRowIndex.TryGetValue(idOrRowIndex, out rowIndex))
            {
                throw new Exception($"ID {idOrRowIndex} not found in idToRowIndex dictionary");
            }
        }
        if (rowIndex >= param.Rows.Count)
        {
            throw new Exception($"Attempted to access rowIndex {rowIndex} but there's only {param.Rows.Count} rows");
        }
        if (colIndex >= param.Columns.Count)
        {
            throw new Exception($"Attempted to access index {colIndex} but there's only {param.Columns.Count} columns");
        }
        Param.Row row = param.Rows[rowIndex];
        Param.Column column = param.Columns[colIndex];
        return column.GetValue(row);
    }

    private void SetValueAtCell(Param param, Dictionary<int, int>? idToRowIndex, int idOrRowIndex, int colIndex, object value)
    {
        int rowIndex = idOrRowIndex;
        if (idToRowIndex != null)
        {
            if (!idToRowIndex.TryGetValue(idOrRowIndex, out rowIndex))
            {
                throw new Exception($"ID {idOrRowIndex} not found in idToRowIndex dictionary");
            }
        }
        if (rowIndex >= param.Rows.Count) {
            throw new Exception($"Attempted to access index {rowIndex} but there's only {param.Rows.Count} rows");
        }
        if (colIndex >= param.Columns.Count)
        {
            throw new Exception($"Attempted to access index {colIndex} but there's only {param.Columns.Count} columns");
        }
        Param.Row row = param.Rows[rowIndex];
        Param.Column column = param.Columns[colIndex];
        column.SetValue(row, value);
    }

    public static ParamsEditor ReadFromRegulationPath(string regulationPath)
    {
        return new(regulationPath);
    }

    public void WriteToRegulationPath(string regulationPath)
    {
        foreach (BinderFile file in _regulationBnd.Files)
        {
            string fileName = Path.GetFileName(file.Name);
            switch (fileName)
            {
                case ItemLotParam_map:
                    {
                        if (_itemLotMap != null)
                        {
                            file.Bytes = _itemLotMap.Write();
                        }
                        break;
                    }
                case ItemLotParam_enemy:
                    {
                        if (_itemLotEnemy != null)
                        {
                            file.Bytes = _itemLotEnemy.Write();
                        }
                        break;
                    }
                case ShopLineupParam:
                    {
                        if (_shopLineup != null)
                        {
                            file.Bytes = _shopLineup.Write();
                        }
                        break;
                    }
                case CharaInitParam:
                    {
                        if (_charaInit != null)
                        {
                            file.Bytes = _charaInit.Write();
                        }
                        break;
                    }
                case EquipParamGoods:
                    {
                        if (_equipGoods != null)
                        {
                            file.Bytes = _equipGoods.Write();
                        }
                        break;
                    }
                case EquipParamWeapon:
                    {
                        if (_equipWeapon != null)
                        {
                            file.Bytes = _equipWeapon.Write();
                        }
                        break;
                    }
                case EquipParamCustomWeapon:
                    {
                        if (_equipCustomWeapon != null)
                        {
                            file.Bytes = _equipCustomWeapon.Write();
                        }
                        break;
                    }
                case EquipParamProtector:
                    {
                        if (_equipProtector != null)
                        {
                            file.Bytes = _equipProtector.Write();
                        }
                        break;
                    }
                case SpEffectParam:
                    {
                        if (_spEffect != null)
                        {
                            file.Bytes = _spEffect.Write();
                        }
                        break;
                    }
                //New Case
                case BonfireWarpParam:
                    {
                        if (_bonfireWarp != null)
                        {
                            file.Bytes = _bonfireWarp.Write();
                        }
                        break;
                    }
                case GameSystemCommonParam:
                    {
                        if (_gameSystemCommon != null)
                        {
                            file.Bytes = _gameSystemCommon.Write();
                        }
                        break;
                    }
            }
        }
        SFUtil.EncryptERRegulation(regulationPath, _regulationBnd);
    }
}
