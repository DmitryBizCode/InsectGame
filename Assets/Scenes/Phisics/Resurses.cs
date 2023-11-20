using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resurses : IResurses, IAddRes
{
    private int Food_ { get; set; }
    private int Water_ { get; set; }
    public void FoodAdd(InsectBody a)
    {
        Food_ += a.Health switch
        {
            6 => 200,
            4 => 120,
            _ => 80
        };
    }
    public void WaterAdd(InsectBody a)
    {
        Food_ += a.Health switch
        {
            6 => 100,
            4 => 60,
            _ => 40
        };
    }
    public void WaterDelChild(int size) => Water_ -= 1;
    public void FoodDelChild(int size) => Food_ -= 1;
    public void WaterDel(int size) => Water_ -= size;
    public void FoodDel(int size) => Food_ -= size;    
    public void WaterDelWithoutFood(int size) => Water_ -= size * 3;   
    public void FoodDelWithoutWater(int size) => Food_ -= size * 6;
    public int FoodGet() => Food_;
    public int WaterGet() => Water_;
}
