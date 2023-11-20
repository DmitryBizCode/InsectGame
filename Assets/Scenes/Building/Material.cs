using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material 
{
    private int Material_ {  get; set; }
    public Material() => Material_ = 50;
    public int GetMaterialCollect() => Material_;
    public void AddMaterial(InsectBody a)
    {
        Material_ += a.Health switch
        {
            6 => 5,
            4 => 2,
            _ => 1
        };
    }
    public void RemoveMaterialHouse() => Material_ -= 50;

}
