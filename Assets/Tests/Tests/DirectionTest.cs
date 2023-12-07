using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    private string testFilePath = "TestDataBaseMFW2.txt";
    private string testFilePath2 = "DataBaseMFW2.txt";

    [SetUp]
    public void SetUp(){ }

    [TearDown]
    public void TearDown()
    {
        // Очищення тестового середовища після кожного тесту, якщо потрібно
        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }
        if (File.Exists(testFilePath2))
        {
            File.Delete(testFilePath2);
        }
    }

    [Test]
    public void EnsureValuesSet_ValuesAreZero_DefaultValuesSet()
    {
        // Arrange
        var helper = new Helper(0, 0, 0);

        // Act
        helper.EnsureValuesSet();

        // Assert
        Assert.AreEqual(50, helper.MaterialBuilding);
        Assert.AreEqual(2000, helper.Food);
        Assert.AreEqual(2000, helper.Water);
    }

    [Test]
    public void EnsureValuesSet_ValuesAreNonZero_NoDefaultValuesSet()
    {
        // Arrange
        var helper = new Helper(100, 500, 700);

        // Act
        helper.EnsureValuesSet();

        // Assert
        Assert.AreNotEqual(50, helper.MaterialBuilding);
        Assert.AreNotEqual(2000, helper.Food);
        Assert.AreNotEqual(2000, helper.Water);
    }

    [Test]
    public void SaveMaterialData_FileCreatedAndDataSaved()
    {
        // Arrange
        var helper = new Helper(50, 2000, 2000);

        // Act
        helper.SaveMaterialData();

        // Assert
        Assert.IsTrue(File.Exists(testFilePath2));

        // Additional Assertion - Check if data can be deserialized correctly
        try
        {
            var serializer = new XmlSerializer(typeof(MaterialData));
            var fstream = new FileStream(testFilePath2, FileMode.Open, FileAccess.Read, FileShare.None);
            MaterialData materialData = serializer.Deserialize(fstream) as MaterialData;
            fstream.Close();

            Assert.AreEqual(50, materialData.MaterialBuilding);
            Assert.AreEqual(2000, materialData.Food);
            Assert.AreEqual(2000, materialData.Water);
        }
        catch (Exception ex)
        {
            Assert.Fail("Exception thrown while deserializing: " + ex.Message);
        }
    }

    [Test]
    public void LoadMaterialData_FileExistsAndDataLoaded()
    {
        // Arrange
        var helper = new Helper();
        var materialData = new MaterialData { MaterialBuilding = 30, Food = 1500, Water = 1800 };

        try
        {
            var serializer = new XmlSerializer(typeof(MaterialData));
            var fstream = new FileStream(testFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            serializer.Serialize(fstream, materialData);
            fstream.Close();
        }
        catch (Exception ex)
        {
            Assert.Fail("Exception thrown while serializing: " + ex.Message);
        }

        // Act
        helper.LoadMaterialData();

        // Assert
        Assert.AreEqual(0, helper.MaterialBuilding);
        Assert.AreEqual(0, helper.Food);
        Assert.AreEqual(0, helper.Water);
    }
}
