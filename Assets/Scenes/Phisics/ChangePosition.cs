using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition
{
    readonly InsectBody insec;

    public ChangePosition(InsectBody a) => insec = a;
       
    public void ChangePositions()
    {
        var rand = new System.Random();   
        if (insec != null && insec.Live == "yes")
        {                
            int randomNumber = rand.Next(1, 5);
            if (randomNumber == 1)
                insec.XY = (insec.XY.Item1, insec.XY.Item2 + 1);//вверх
            else if (randomNumber == 2)
                insec.XY = (insec.XY.Item1 + 1, insec.XY.Item2);//вправо
            else if (randomNumber == 3)
                insec.XY = (insec.XY.Item1, insec.XY.Item2 - 1);//вниз
            else if (randomNumber == 4)
                insec.XY = (insec.XY.Item1 - 1, insec.XY.Item2);//вліво
        }
    }
    public void DetectedFMW()
    {
        var wat = new Water();
        WaterBase water = new();
        FoodBase food = new();
        MaterialBase material = new();

        (int, int) itemsToRemoveFood = (-100, -100);
        (int, int) itemsToRemoveMaterial = (-100, -100);


        foreach ((int x, int y) in wat.waterList)        
            if (insec.XY == (x, y))
            {
                water.WaterAdd(insec);
                insec.XY = (0, 0);
                break;
            }       

        foreach ((int x, int y) in CoordinateFoodMaterial.StaticFoodCoordinate)        
            if (insec.XY == (x, y))
            {
                food.FoodAdd(insec);
                itemsToRemoveFood = (x, y);
                insec.XY = (0, 0);
                break;
            }
        
        if (itemsToRemoveFood != (-100,-100))       
            CoordinateFoodMaterial.StaticFoodCoordinate.Remove(itemsToRemoveFood);
        
        foreach ((int x, int y) in CoordinateFoodMaterial.StaticMaterailCoordinate)        
            if (insec.XY == (x, y))
            {
                material.MaterialAdd(insec);
                itemsToRemoveMaterial = (x, y);
                insec.XY = (0, 0);
                break;
            }
        
        if (itemsToRemoveFood == (-100, -100))
            CoordinateFoodMaterial.StaticMaterailCoordinate.Remove(itemsToRemoveMaterial);
    }
}

