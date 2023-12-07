using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test3 
{
    private string testFilePath = "TestDataBaseMFW2.txt";

    [SetUp]
    public void SetUp()
    {
        // Ініціалізація потрібних об'єктів/середовища перед кожним тестом
    }

    [TearDown]
    public void TearDown()
    {
        // Очищення тестового середовища після кожного тесту
        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }
    }

    [Test]
    public void SubtractFood_CorrectlySubtractsFoodAmount()
    {
        // Arrange
        var materialDel = new MaterialDel();
        var helper = new Helper();
        helper.EnsureValuesSet();
        int initialFoodAmount = helper.Food;
        int amountToSubtract = 50;

        // Act
        materialDel.SubtractFood(amountToSubtract);
        helper.LoadMaterialData();

        // Assert
        Assert.AreEqual(-50, helper.Food);
    }

    [Test]
    public void SubtractWater_CorrectlySubtractsWaterAmount()
    {
        // Arrange
        var materialDel = new MaterialDel();
        var helper = new Helper();
        helper.EnsureValuesSet();
        int initialWaterAmount = helper.Water;
        int amountToSubtract = 30;

        // Act
        materialDel.SubtractWater(amountToSubtract);
        helper.LoadMaterialData();

        // Assert
        Assert.AreEqual(-30, helper.Water);
    }

    [Test]
    public void SubtractMaterialBuilding_CorrectlySubtractsMaterialBuildingAmount()
    {
        // Arrange
        var materialDel = new MaterialDel();
        var helper = new Helper();
        helper.EnsureValuesSet();
        int initialMaterialBuildingAmount = helper.MaterialBuilding;
        int amountToSubtract = 10;

        // Act
        materialDel.SubtractMaterialBuilding(amountToSubtract);
        helper.LoadMaterialData();

        // Assert
        Assert.AreEqual(-10, helper.MaterialBuilding);
    }

    [Test]
    public void GetMaterialBuildingValue_ReturnsCorrectValue()
    {
        // Arrange
        var materialDel = new MaterialDel();
        var helper = new Helper();
        helper.MaterialBuilding = 100; // Set a specific value for testing

        // Act
        int materialBuildingValue = materialDel.GetMaterialBuildingValue();

        // Assert
        Assert.AreEqual(0, materialBuildingValue);
    }

    [Test]
    public void GetFoodValue_ReturnsCorrectValue()
    {
        // Arrange
        var materialDel = new MaterialDel();
        var helper = new Helper();
        helper.Food = 500; // Set a specific value for testing

        // Act
        int foodValue = materialDel.GetFoodValue();

        // Assert
        Assert.AreEqual(0, foodValue);
    }

    [Test]
    public void GetWaterValue_ReturnsCorrectValue()
    {
        // Arrange
        var materialDel = new MaterialDel();
        var helper = new Helper();
        helper.Water = 700; // Set a specific value for testing

        // Act
        int waterValue = materialDel.GetWaterValue();

        // Assert
        Assert.AreEqual(0, waterValue);
    }
}
