using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class MaterialAdd
{

    elp myElpInstance = new elp(); // Example values for Material, Food, Water                                                                       

    // ����� ��� ��������� ������� Food �� XML-�����
    public void AddFood(int amount)
    {
        myElpInstance.LoadMaterialData();
        myElpInstance.Food += amount;
        myElpInstance.SaveMaterialData();
    }

    // ����� ��� ��������� ������� Water �� XML-�����
    public void AddWater(int amount)
    {
        myElpInstance.LoadMaterialData();
        myElpInstance.Water += amount;
        myElpInstance.SaveMaterialData();
    }

    // ����� ��� ��������� ������� MaterialBuilding �� XML-�����
    public void AddMaterialBuilding(int amount)
    {
        myElpInstance.LoadMaterialData();
        myElpInstance.MaterialBuilding += amount;
        myElpInstance.SaveMaterialData();
    }

    // ������ ��� ��������� ������� Food, Water �� MaterialBuilding � XML-�����
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