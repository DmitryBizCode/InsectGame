using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class MaterialAdd
{

    elp myElpInstance = new elp(); // Example values for Material, Food, Water                                                                       

    // Метод для додавання кількості Food до XML-файлу
    public void AddFood(int amount)
    {
        myElpInstance.LoadMaterialData();
        myElpInstance.Food += amount;
        myElpInstance.SaveMaterialData();
    }

    // Метод для додавання кількості Water до XML-файлу
    public void AddWater(int amount)
    {
        myElpInstance.LoadMaterialData();
        myElpInstance.Water += amount;
        myElpInstance.SaveMaterialData();
    }

    // Метод для додавання кількості MaterialBuilding до XML-файлу
    public void AddMaterialBuilding(int amount)
    {
        myElpInstance.LoadMaterialData();
        myElpInstance.MaterialBuilding += amount;
        myElpInstance.SaveMaterialData();
    }

    // Методи для отримання значень Food, Water та MaterialBuilding з XML-файлу
    public int GetMaterialBuildingValue()
    {
        myElpInstance.LoadMaterialData();
        return myElpInstance.MaterialBuilding;
    }

    public int GetFoodValue()
    {
        myElpInstance.LoadMaterialData();
        return myElpInstance.Food;
    }

    public int GetWaterValue()
    {
        myElpInstance.LoadMaterialData();
        return myElpInstance.Water;
    }
}