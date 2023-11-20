using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public interface IResurses
{
    void WaterDel(int size);
    void FoodDel(int size);
    void WaterDelWithoutFood(int size);
    void FoodDelWithoutWater(int size);
    int FoodGet();
    int WaterGet();
}
