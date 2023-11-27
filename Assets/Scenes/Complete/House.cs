using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class House : MonoBehaviour
{
    [SerializeField] private GameObject HouseObg;
    private float timer = 0f; //timer
    private readonly float delay = 1f; //limit timer
    private readonly List<GameObject> list = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Add time passed since the last frame        
        if (timer >= delay)
        {
            MaterialDel datadel = new();
            var rand = new System.Random();
            // Assuming GetMaterialBuildingValue() is a method in MaterialAdd class
            if (datadel != null && datadel.GetMaterialBuildingValue() >= 50)
            {
                int randomNumberX = rand.Next(-30, 43);
                int randomNumberY = rand.Next(-18, 19);

                var newHouse = Instantiate(HouseObg, transform.position, Quaternion.identity);
                newHouse.transform.position = new Vector3(randomNumberX, randomNumberY, 0);
                list.Add(newHouse);
                CoordinateHouse.StaticValue.Add((randomNumberX, randomNumberY));
                MaterialBase a = new();
                a.MaterialDelHouse(); 
            }
            timer = 0f; // Reset the timer for a new delay
        }
    }
}
