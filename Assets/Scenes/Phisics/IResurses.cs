using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public interface IResurses
{
    void WaterDel();
    void FoodDel();
    void WaterDelWithoutFood();
    void FoodDelWithoutWater();
    int FoodGet();
    int WaterGet();
}
