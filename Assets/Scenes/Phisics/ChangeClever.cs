using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Drawing;
using System.Reflection;
public class ChangeClever
{
    readonly InsectBody insec;

    public ChangeClever(InsectBody a) => insec = a;

    public void ChangePositions()
    {
        if (insec != null && insec.Live == "yes")
        {
            MaterialDel info = new();
            (int, int) A;
            (int, int) B;
            if (info.GetFoodValue() * 1.1 < info.GetWaterValue()) 
                A = BestPosFood((insec.XY.Item1, insec.XY.Item2));
            else
                A = BestPosWater((insec.XY.Item1, insec.XY.Item2));
            B = NextPoint((insec.XY.Item1, insec.XY.Item2), A);
            insec.XY = (B);
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

        if (itemsToRemoveFood != (-100, -100))
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

    private (int,int) BestPosFood((int x,int y)A)
    {
        int index = 0;
        float a = (float)Math.Sqrt(Math.Pow(100 - A.x, 2) + Math.Pow(100 - A.y, 2));
        for (int i = 0; i < CoordinateFoodMaterial.StaticFoodCoordinate.Count; i++)
        {
            float b = (float)Math.Sqrt(Math.Pow(CoordinateFoodMaterial.StaticFoodCoordinate[i].Item1 - A.x, 2) + Math.Pow(CoordinateFoodMaterial.StaticFoodCoordinate[i].Item2 - A.y, 2));
            if (a > b)
            {
                index = i;
                a = b;
            }
        }
        return (CoordinateFoodMaterial.StaticFoodCoordinate[index]);
    }
    private (int, int) BestPosWater((int x, int y) A)
    {
        Water water = new();
        int index = 0;
        float a = (float)Math.Sqrt(Math.Pow(100 - A.x, 2) + Math.Pow(100 - A.y, 2));
        for (int i = 0; i < water.waterList.Count; i++)
        {
            float b = (float)Math.Sqrt(Math.Pow(water.waterList[i].Item1 - A.x, 2) + Math.Pow(water.waterList[i].Item2 - A.y, 2));
            if (a > b)
            {
                index = i;
                a = b;
            }
        }
        return (water.waterList[index]);
    }
    private (int,int) NextPoint((int, int) pointA, (int,int) pointB)
    {
        if (pointA.Item1 == pointB.Item1)
        {
            if (pointA.Item2 < pointB.Item2)            
                return (pointA.Item1, pointA.Item2 + 1);            
            else            
                return (pointA.Item1, pointA.Item2 - 1);            
        }
        else
        {
            if (pointA.Item1 < pointB.Item1)            
                return (pointA.Item1 + 1, pointA.Item2);            
            else            
                return (pointA.Item1 - 1, pointA.Item2);            
        }
    }
}
