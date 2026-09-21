// SPDX-License-Identifier: GPL-3.0-only
using System.Reflection;
using SoulsFormats;
using System.Xml;
using System.Text.Json;

namespace EldenRingParamsEditor;

public enum ItemLotType
{
    Map,
    Enemy
}

public class ItemLotEntry
{
    public int ID { get; set; }
    public List<int> LotItems { get; set; } = new();
}

internal class ResourceManager
{
    public static PARAMDEF GetParamDefByName(string resourceName)
    {
        string filePath = Path.Combine("Resources", "ParamDefs", $"{resourceName}.xml");

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"ParamDef file not found: {filePath}");
        }

        string xmlContent = File.ReadAllText(filePath);
        XmlDocument xml = new();
        xml.LoadXml(xmlContent);
        return PARAMDEF.XmlSerializer.Deserialize(xml, false);
    }

    private static void SaveDictionary<T>(string filePath, Dictionary<int, List<T>> data)
    {
        // Convert int keys to strings because JSON object keys must be strings
        var stringKeyed = data.ToDictionary(
            kvp => kvp.Key.ToString(),
            kvp => kvp.Value
        );

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        string json = JsonSerializer.Serialize(stringKeyed, options);

        // Ensure the directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        File.WriteAllText(filePath, json);
    }

    private static Dictionary<int, List<T>> GetDictionary<T>(string filePath)
    {
        string json = File.ReadAllText(filePath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Deserialize into Dictionary<string, List<T>> first
        var stringKeyed = JsonSerializer.Deserialize<Dictionary<string, List<T>>>(json, options)
                          ?? throw new Exception("Failed to parse JSON.");

        // Convert string keys to int
        var result = new Dictionary<int, List<T>>();
        foreach (var (key, value) in stringKeyed)
        {
            if (int.TryParse(key, out int parsedKey))
            {
                result[parsedKey] = value;
            }
            else
            {
                throw new FormatException($"Invalid key in JSON: '{key}' is not a valid int.");
            }
        }

        return result;
    }

    public static Dictionary<int, List<ItemLotEntry>> GetWeaponIdsToItemLot(ItemLotType itemLotType)
    {
        string filePath = Path.Combine("Resources", "Metadata");
        string fileName = "";
        switch (itemLotType)
        {
            case ItemLotType.Map:
                fileName = "WeaponIdsToItemLotMap.json";
                break;
            case ItemLotType.Enemy:
                fileName = "WeaponIdsToItemLotEnemy.json";
                break;
        }
        filePath = Path.Combine(filePath, fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Could not find {fileName} at {filePath}");
        }

        return GetDictionary<ItemLotEntry>(filePath);
    }

    public static Dictionary<int, List<int>> GetWeaponIdsToShopLineup()
    {
        string fileName = "WeaponIdsToShopLineup.json";
        string filePath = Path.Combine("Resources", "Metadata", fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Could not find {fileName} at {filePath}");
        }

        return GetDictionary<int>(filePath);
    }

    public static Dictionary<int, List<ItemLotEntry>> GetGoodsIdsToItemLot(ItemLotType itemLotType)
    {
        string filePath = Path.Combine("Resources", "Metadata");
        string fileName = "";
        switch (itemLotType)
        {
            case ItemLotType.Map:
                fileName = "GoodsIdsToItemLotMap.json";
                break;
            case ItemLotType.Enemy:
                fileName = "GoodsIdsToItemLotEnemy.json";
                break;
        }
        filePath = Path.Combine(filePath, fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Could not find {fileName} at {filePath}");
        }

        return GetDictionary<ItemLotEntry>(filePath);
    }

    public static Dictionary<int, List<int>> GetGoodsIdsToShopLineup()
    {
        string fileName = "GoodsIdsToShopLineup.json";
        string filePath = Path.Combine("Resources", "Metadata", fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Could not find {fileName} at {filePath}");
        }

        return GetDictionary<int>(filePath);
    }

    public static void SaveWeaponIdsToItemLot(ItemLotType itemLotType, Dictionary<int, List<ItemLotEntry>> data)
    {
        string filePath = Path.Combine("Resources", "Metadata");
        string fileName = "";
        switch (itemLotType)
        {
            case ItemLotType.Map:
                fileName = "WeaponIdsToItemLotMap.json";
                break;
            case ItemLotType.Enemy:
                fileName = "WeaponIdsToItemLotEnemy.json";
                break;
        }
        filePath = Path.Combine(filePath, fileName);

        SaveDictionary(filePath, data);
    }

    public static void SaveWeaponIdsToShopLineup(Dictionary<int, List<int>> data)
    {
        SaveDictionary(Path.Combine("Resources", "Metadata", "WeaponIdsToShopLineup.json"), data);
    }

    public static void SaveGoodsIdsToItemLot(ItemLotType itemLotType, Dictionary<int, List<ItemLotEntry>> data)
    {
        string filePath = Path.Combine("Resources", "Metadata");
        string fileName = "";
        switch (itemLotType)
        {
            case ItemLotType.Map:
                fileName = "GoodsIdsToItemLotMap.json";
                break;
            case ItemLotType.Enemy:
                fileName = "GoodsIdsToItemLotEnemy.json";
                break;
        }
        filePath = Path.Combine(filePath, fileName);

        SaveDictionary(filePath, data);
    }

    public static void SaveGoodsIdsToShopLineup(Dictionary<int, List<int>> data)
    {
        SaveDictionary(Path.Combine("Resources", "Metadata", "GoodsIdsToShopLineup.json"), data);
    }
}
