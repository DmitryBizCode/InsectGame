using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class CoordinateHouse
{
    public static List<(int,int)> StaticValue { get; set; } = new List<(int, int)>();

    static CoordinateHouse() => StaticValue.Add((0,0));
    
    public static (int, int) GetRandomCoordinate()
    {
        System.Random rand = new ();
        int randomIndex = rand.Next(0, StaticValue.Count);

        // Повертаємо випадковий елемент
        return StaticValue[randomIndex];
    }
}
