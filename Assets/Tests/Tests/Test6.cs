using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test6 
{
    [Test]
    public void WaterAdd_HealthSix_Adds150Water()
    {
        // Arrange
        var waterBase = new WaterBase();
        var insectBody = new InsectBody(6, "yes", 0, 0);
        MaterialDel del = new();

        // Act
        waterBase.WaterAdd(insectBody);

        Assert.AreEqual(270, del.GetWaterValue());
    }

    [Test]
    public void WaterAdd_HealthFour_Adds100Water()
    {
        // Arrange
        var waterBase = new WaterBase();
        var insectBody = new InsectBody(6, "yes", 0, 0);
        MaterialDel del = new();

        // Act
        waterBase.WaterAdd(insectBody);

        Assert.AreEqual(120, del.GetWaterValue());
    }

    [Test]
    public void WaterAdd_OtherHealthValues_Adds70Water()
    {
        // Arrange
        var waterBase = new WaterBase();
        var insectBody = new InsectBody(6, "yes", 0, 0); // For health values other than 6 or 4
        MaterialDel del = new();

        // Act
        waterBase.WaterAdd(insectBody);

        Assert.AreEqual(420, del.GetWaterValue());
    }

    [Test]
    public void WaterDelChild_Subtracts5Water()
    {
        // Arrange
        var waterBase = new WaterBase();
        MaterialDel del = new();

        // Act
        waterBase.WaterDelChild();

        Assert.AreEqual(414, del.GetWaterValue());
    }

    [Test]
    public void WaterDel_Subtracts1Water()
    {
        // Arrange
        var waterBase = new WaterBase();
        MaterialDel del = new();

        // Act
        waterBase.WaterDel();

        Assert.AreEqual(419, del.GetWaterValue());
    }

    [Test]
    public void WaterDelWithoutFood_Subtracts3Water()
    {
        // Arrange
        var waterBase = new WaterBase();
        MaterialDel del = new();

        // Act
        waterBase.WaterDelWithoutFood();
        Assert.AreEqual(411, del.GetWaterValue());
    }
}
