using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public interface IResursesD
{
    void SubtractFood(int amount);
    void SubtractWater(int amount);
    void SubtractMaterialBuilding(int amount);
    int GetFoodValue();
    int GetWaterValue();
    
}
