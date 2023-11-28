using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBase
{

    public void FoodAdd(InsectBody a)
    {
        int food = a.Health switch
        {
            6 => 200,
            4 => 120,
            _ => 80
        };        
        MaterialAdd add = new();
        add.AddFood(food);
    }
    public void FoodDelChild()
    {
        MaterialDel del = new();
        del.SubtractFood(4);
    }
    public void FoodDel()
    {
        MaterialDel del = new();
        del.SubtractFood(1);
    }
    public void FoodDelWithoutWater()
    {
        MaterialDel del = new();
        del.SubtractFood(4);
    }
}
