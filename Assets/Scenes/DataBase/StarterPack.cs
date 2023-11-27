using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StarterPack : MonoBehaviour
{
    [SerializeField] private int Material;
    [SerializeField] private int Food;
    [SerializeField] private int Water;
    

    private void Awake()
    {
        Helper myElpInstance = new (this.Material, this.Food, this.Water); // Example values for Material, Food, Water
        // Save the updated data to JSON file
        myElpInstance.EnsureValuesSet();
        myElpInstance.SaveMaterialData();
    }
}
