using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
public class Test4
{
    [Test]
    public void FoodAdd_HealthSix_Adds250Food()
    {
        // Arrange
        MaterialDel del = new();
        var foodBase = new FoodBase();
        var insectBody = new InsectBody (6, "yes", 0, 0);

        // Act
        foodBase.FoodAdd(insectBody);

        Assert.AreEqual(350, del.GetFoodValue());
    }

    [Test]
    public void FoodAdd_HealthFour_Adds150Food()
    {
        // Arrange
        MaterialDel del = new();
        var foodBase = new FoodBase();
        var insectBody = new InsectBody(4, "yes", 0, 0);

        // Act
        foodBase.FoodAdd(insectBody);

        Assert.AreEqual(100, del.GetFoodValue());
    }

    [Test]
    public void FoodAdd_OtherHealthValues_Adds100Food()
    {
        // Arrange
        MaterialDel del = new();
        var foodBase = new FoodBase();
        var insectBody = new InsectBody(2, "yes", 0, 0); // For health values other than 6 or 4

        // Act
        foodBase.FoodAdd(insectBody);
        Assert.AreEqual(450, del.GetFoodValue());
    }

    [Test]
    public void FoodDelChild_Subtracts4Food()
    {
        // Arrange
        var foodBase = new FoodBase();
        MaterialDel del = new();

        // Act
        foodBase.FoodDelChild();
        Assert.AreEqual(445, del.GetFoodValue());
    }

    [Test]
    public void FoodDel_Subtracts1Food()
    {
        // Arrange
        var foodBase = new FoodBase();
        MaterialDel del = new();

        // Act
        foodBase.FoodDel();

        Assert.AreEqual(449, del.GetFoodValue());
    }

    [Test]
    public void FoodDelWithoutWater_Subtracts4Food()
    {
        // Arrange
        var foodBase = new FoodBase();
        MaterialDel del = new();

        // Act
        foodBase.FoodDelWithoutWater();
     
        Assert.AreEqual(441, del.GetFoodValue());
    }
}
