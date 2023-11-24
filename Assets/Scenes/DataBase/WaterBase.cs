using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBase : MonoBehaviour
{
    readonly MaterialAdd add;
    readonly MaterialDel del;

    public void WaterAdd(InsectBody a)
    {
        int water = a.Health switch
        {
            6 => 100,
            4 => 80,
            _ => 60
        };
        add.AddWater(water);
    }
    public void WaterDelChild() => del.SubtractWater(5);
    public void WaterDel() => del.SubtractWater(1);
    public void WaterDelWithoutFood() => del.SubtractWater(3);
}
