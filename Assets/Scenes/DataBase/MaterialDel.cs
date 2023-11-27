using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class MaterialDel
{
    public void SubtractFood(int amount)
    {
        Helper myElpInstance = new ();
        myElpInstance.LoadMaterialData();
        myElpInstance.Food -= amount;
        myElpInstance.SaveMaterialData();
    }

    public void SubtractWater(int amount)
    {
        Helper myElpInstance = new ();
        myElpInstance.LoadMaterialData();
        myElpInstance.Water -= amount;
        myElpInstance.SaveMaterialData();
    }

    public void SubtractMaterialBuilding(int amount)
    {
        Helper myElpInstance = new ();
        myElpInstance.LoadMaterialData();
        myElpInstance.MaterialBuilding -= amount;
        myElpInstance.SaveMaterialData();
    }
    // Методи для отримання значень Food, Water та MaterialBuilding з XML-файлу
    public int GetMaterialBuildingValue()
    {
        Helper myElpInstance = new ();
        myElpInstance.LoadMaterialData();
        return myElpInstance.MaterialBuilding;
    }

    public int GetFoodValue()
    {
        Helper myElpInstance = new ();
        myElpInstance.LoadMaterialData();
        return myElpInstance.Food;
    }

    public int GetWaterValue()
    {
        Helper myElpInstance = new ();
        myElpInstance.LoadMaterialData();
        return myElpInstance.Water;
    }

}

