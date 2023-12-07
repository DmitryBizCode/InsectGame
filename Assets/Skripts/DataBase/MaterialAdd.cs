using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class MaterialAdd : IAddRes
{
    // ����� ��� ��������� ������� Food �� XML-�����
    public void AddFood(int amount)
    {
        Helper myElpInstance = new();
        myElpInstance.LoadMaterialData();
        myElpInstance.Food += amount;
        myElpInstance.SaveMaterialData();
    }

    // ����� ��� ��������� ������� Water �� XML-�����
    public void AddWater(int amount)
    {
        Helper myElpInstance = new();
        myElpInstance.LoadMaterialData();
        myElpInstance.Water += amount;
        myElpInstance.SaveMaterialData();
    }

    // ����� ��� ��������� ������� MaterialBuilding �� XML-�����
    public void AddMaterialBuilding(int amount)
    {
        Helper myElpInstance = new();
        myElpInstance.LoadMaterialData();
        myElpInstance.MaterialBuilding += amount;
        myElpInstance.SaveMaterialData();
    }    
}