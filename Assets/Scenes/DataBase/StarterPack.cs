using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StarterPack : MonoBehaviour
{
    private string filePath = "InsectGame/Assets/Scenes/DataBase/DataBaseMFW.json";

    [SerializeField] private int Material;
    [SerializeField] private int Food;
    [SerializeField] private int Water;

    private class MaterialData2
    {
        public int MaterialBuilding { get; set; }
        public int Food { get; set; }
        public int Water { get; set; }
    }

    private void S(MaterialData2 start)
    {
        if (Material == 0 || Food == 0 || Water == 0)
        {
            start.MaterialBuilding = 20;
            start.Food = 1000;
            start.Water = 1000;
        }
        else
        {
            start.MaterialBuilding = Material;
            start.Food = Food;
            start.Water = Water;
        }
    }

    private void SaveMaterialData(MaterialData2 materialData)
    {
        string json = JsonUtility.ToJson(materialData, true);
        File.WriteAllText(filePath, json);
    }

    private void Awake()
    {
        MaterialData2 start = new MaterialData2(); // Створення екземпляру класу MaterialData2
        S(start); // Передача створеного екземпляру класу в метод S
        SaveMaterialData(start); // Збереження об'єкта MaterialData2 у форматі JSON
    }
}
