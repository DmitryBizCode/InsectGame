using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBase
{
    public void WaterAdd(InsectBody a)
    {
        int water = a.Health switch
        {
            6 => 100,
            4 => 80,
            _ => 60
        };
        MaterialAdd add = new();
        add.AddWater(water);
    }
    public void WaterDelChild()
    {
        MaterialDel del = new(); 
        del.SubtractWater(5); 
    }
    public void WaterDel()
    {
        MaterialDel del = new();
        del.SubtractWater(1);
    }
    public void WaterDelWithoutFood()
    {
        MaterialDel del = new();
        del.SubtractWater(3);
    }
}
