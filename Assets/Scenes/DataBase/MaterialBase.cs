using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBase
{ 
    public void MaterialAdd(InsectBody a)
    {        
        int material = a.Health switch
        {
            6 => 5,
            4 => 2,
            _ => 1
        };
        MaterialAdd add = new();
        add.AddMaterialBuilding(material);
    }
    public void MaterialDelHouse() {
        MaterialDel del = new();
        del.SubtractMaterialBuilding(50); 
    }

}
