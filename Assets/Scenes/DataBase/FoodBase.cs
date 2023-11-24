using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBase : MonoBehaviour
{
    readonly MaterialAdd add;
    readonly MaterialDel del;

    public void FoodAdd(InsectBody a)
    {
        int food = a.Health switch
        {
            6 => 200,
            4 => 120,
            _ => 80
        };
        add.AddFood(food);
    }
    public void FoodDelChild() => del.SubtractFood(1);
    public void FoodDel() => del.SubtractFood(1);
    public void FoodDelWithoutWater() => del.SubtractFood(6);
}
