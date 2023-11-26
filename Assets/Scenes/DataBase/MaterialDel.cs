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
    elp myElpInstance = new elp(); // Example values for Material, Food, Water                                                                       


    public void SubtractFood(int amount)
    {
        myElpInstance.LoadMaterialData();
        myElpInstance.Food -= amount;
        myElpInstance.SaveMaterialData();
    }

    public void SubtractWater(int amount)
    {
        myElpInstance.LoadMaterialData();
        myElpInstance.Water -= amount;
        myElpInstance.SaveMaterialData();
    }

    public void SubtractMaterialBuilding(int amount)
    {
        myElpInstance.LoadMaterialData();
        myElpInstance.MaterialBuilding -= amount;
        myElpInstance.SaveMaterialData();
    }

}

