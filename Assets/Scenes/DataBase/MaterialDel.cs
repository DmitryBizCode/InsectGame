using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;

public class MaterialDel : MaterialData
{
    readonly string filePath = "InsectGame/Assets/Scenes/DataBase/DataBaseMFW.json";

    // Метод для завантаження даних з файлу JSON
    private MaterialData LoadMaterialData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<MaterialData>(json);
        }
        else
        {
            Debug.LogError("Файл JSON не знайдено.");
            return null;
        }
    }
    // Метод для збереження змін у файл JSON
    private void SaveMaterialData(MaterialData materialData)
    {
        string json = JsonUtility.ToJson(materialData, true);
        File.WriteAllText(filePath, json);
    }

    // Метод для віднімання кількості Food з файлу JSON

    public void SubtractFood(int amount)
    {
        MaterialData materialData = LoadMaterialData(); // Завантаження даних з файлу JSON
        materialData.Food -= amount; // Віднімання кількості Food

        SaveMaterialData(materialData); // Збереження змін у файл JSON
    }
    // Метод для віднімання кількості Water з файлу JSON

    public void SubtractWater(int amount)
    {
        MaterialData materialData = LoadMaterialData(); // Завантаження даних з файлу JSON
        materialData.Water -= amount; // Віднімання кількості Food

        SaveMaterialData(materialData); // Збереження змін у файл JSON
    }
    // Метод для віднімання кількості Material з файлу JSON

    public void SubtractMaterialBuilding(int amount)
    {
        MaterialData materialData = LoadMaterialData(); // Завантаження даних з файлу JSON
        materialData.MaterialBuilding -= amount; // Віднімання кількості Food

        SaveMaterialData(materialData); // Збереження змін у файл JSON
    }

}

