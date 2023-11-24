using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBase : MonoBehaviour
{
    readonly MaterialAdd add;
    readonly MaterialDel del;

    public void MaterialAdd(InsectBody a)
    {        
        int material = a.Health switch
        {
            6 => 5,
            4 => 2,
            _ => 1
        };        
        add.AddMaterialBuilding(material);
    }
    public void MaterialDelHouse() => del.SubtractMaterialBuilding(50);
}
