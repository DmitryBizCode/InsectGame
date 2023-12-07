using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestUnit2
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
    public void AddFood_CorrectlyAddsFoodAmount()
    {
        // Arrange
        var materialAdd = new MaterialAdd();
        var helper = new Helper();
        helper.EnsureValuesSet();
        int initialFoodAmount = helper.Food;
        int amountToAdd = 100;

        // Act
        materialAdd.AddFood(amountToAdd);
        helper.LoadMaterialData();

        // Assert
        Assert.AreEqual(541, helper.Food);
    }

    [Test]
    public void AddWater_CorrectlyAddsWaterAmount()
    {
        // Arrange
        var materialAdd = new MaterialAdd();
        var helper = new Helper();
        helper.EnsureValuesSet();
        int initialWaterAmount = helper.Water;
        int amountToAdd = 50;

        // Act
        materialAdd.AddWater(amountToAdd);
        helper.LoadMaterialData();

        // Assert
        Assert.AreEqual(461, helper.Water);
    }

    [Test]
    public void AddMaterialBuilding_CorrectlyAddsMaterialBuildingAmount()
    {
        // Arrange
        var materialAdd = new MaterialAdd();
        var helper = new Helper();
        helper.EnsureValuesSet();
        int initialMaterialBuildingAmount = helper.MaterialBuilding;
        int amountToAdd = 72;

        // Act
        materialAdd.AddMaterialBuilding(amountToAdd);
        helper.LoadMaterialData();

        // Assert
        Assert.AreEqual(20, helper.MaterialBuilding);
    }
}
