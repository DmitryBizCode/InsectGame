using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resurses : IResurses, IAddRes
{
    private int Food_ { get; set; }
    private int Water_ { get; set; }
    private int Size_ { get; set; }
    private int HealthInsect { get; set; }
    public void FoodAdd()
    {
        Food_ += HealthInsect switch
        {
            6 => 200,
            4 => 120,
            _ => 80
        };
    }
    public void WaterAdd()
    {
        Food_ += HealthInsect switch
        {
            6 => 100,
            4 => 60,
            _ => 40
        };
    }

    public Resurses(int size, InsectBody a) 
    {
        Size_ = size;
        HealthInsect = a.Health;
        Water_ = 1500; 
    }
    public void WaterDel() => Water_ -= Size_;
    public void FoodDel() => Food_ -= Size_;    
    public void WaterDelWithoutFood() => Water_ -= Size_ * 3;   
    public void FoodDelWithoutWater() => Food_ -= Size_ * 6;
    public int FoodGet() => Food_;
    public int WaterGet() => Water_;
}
