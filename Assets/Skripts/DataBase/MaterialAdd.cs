using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class MaterialAdd : IAddRes
{
    // Метод для додавання кількості Food до XML-файлу
    public void AddFood(int amount)
    {
        Helper myElpInstance = new();
        myElpInstance.LoadMaterialData();
        myElpInstance.Food += amount;
        myElpInstance.SaveMaterialData();
    }

    // Метод для додавання кількості Water до XML-файлу
    public void AddWater(int amount)
    {
        Helper myElpInstance = new();
        myElpInstance.LoadMaterialData();
        myElpInstance.Water += amount;
        myElpInstance.SaveMaterialData();
    }

    // Метод для додавання кількості MaterialBuilding до XML-файлу
    public void AddMaterialBuilding(int amount)
    {
        Helper myElpInstance = new();
        myElpInstance.LoadMaterialData();
        myElpInstance.MaterialBuilding += amount;
        myElpInstance.SaveMaterialData();
    }    
}