using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Helper : MaterialData
{
    private readonly string filePath = "DataBaseMFW2.txt";

    public Helper(int material, int food, int water)
    {
        MaterialBuilding = material;
        Food = food;
        Water = water;
    }

    public Helper()
    {
        // Default constructor without parameters
    }

    public void EnsureValuesSet()
    {
        if (MaterialBuilding == 0 || Food == 0 || Water == 0)
        {
            MaterialBuilding = 50;
            Food = 1000;
            Water = 1000;
        }
    }

    public void SaveMaterialData()
    {
        
        try
        {
            var serializer = new XmlSerializer(typeof(MaterialData));
            var fstream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            serializer.Serialize(fstream, this);
            fstream.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
        }
    }
    public void LoadMaterialData()
    {
        try
        {
            var serializer = new XmlSerializer(typeof(MaterialData));
            var fstream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            MaterialData materialData = serializer.Deserialize(fstream) as MaterialData;
            fstream.Close();

            this.MaterialBuilding = materialData.MaterialBuilding;
            this.Food = materialData.Food;
            this.Water = materialData.Water; ;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading from file: " + ex.Message);
        }
    }
}