using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MaterialAdd : MaterialData
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
   
    // Метод для додавання кількості Food до файлу JSON
    public void AddFood(int amount)
    {
        MaterialData materialData = LoadMaterialData(); // Завантаження даних з файлу JSON
        materialData.Food += amount; // Додавання кількості Food

        SaveMaterialData(materialData); // Збереження змін у файл JSON
    }

    // Метод для додавання кількості Water до файлу JSON
    public void AddWater(int amount)
    {
        MaterialData materialData = LoadMaterialData(); // Завантаження даних з файлу JSON
        materialData.Water += amount; // Додавання кількості Food

        SaveMaterialData(materialData); // Збереження змін у файл JSON
    }
    // Метод для додавання кількості Material до файлу JSON
    public void AddMaterialBuilding(int amount)
    {
        MaterialData materialData = LoadMaterialData(); // Завантаження даних з файлу JSON
        materialData.MaterialBuilding += amount; // Додавання кількості Food

        SaveMaterialData(materialData); // Збереження змін у файл JSON
    }


}