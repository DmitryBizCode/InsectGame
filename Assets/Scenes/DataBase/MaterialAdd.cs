using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MaterialAdd : MaterialData
{
    readonly string filePath = "InsectGame/Assets/Scenes/DataBase/DataBaseMFW.json";

    // ����� ��� ������������ ����� � ����� JSON
    private MaterialData LoadMaterialData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<MaterialData>(json);
        }
        else
        {
            Debug.LogError("���� JSON �� ��������.");
            return null;
        }
    }
    // ����� ��� ���������� ��� � ���� JSON
    private void SaveMaterialData(MaterialData materialData)
    {
        string json = JsonUtility.ToJson(materialData, true);
        File.WriteAllText(filePath, json);
    }
   
    // ����� ��� ��������� ������� Food �� ����� JSON
    public void AddFood(int amount)
    {
        MaterialData materialData = LoadMaterialData(); // ������������ ����� � ����� JSON
        materialData.Food += amount; // ��������� ������� Food

        SaveMaterialData(materialData); // ���������� ��� � ���� JSON
    }

    // ����� ��� ��������� ������� Water �� ����� JSON
    public void AddWater(int amount)
    {
        MaterialData materialData = LoadMaterialData(); // ������������ ����� � ����� JSON
        materialData.Water += amount; // ��������� ������� Food

        SaveMaterialData(materialData); // ���������� ��� � ���� JSON
    }
    // ����� ��� ��������� ������� Material �� ����� JSON
    public void AddMaterialBuilding(int amount)
    {
        MaterialData materialData = LoadMaterialData(); // ������������ ����� � ����� JSON
        materialData.MaterialBuilding += amount; // ��������� ������� Food

        SaveMaterialData(materialData); // ���������� ��� � ���� JSON
    }


}