using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
public class Test5 
{
    [Test]
    public void MaterialAdd_HealthSix_Adds5Material()
    {
        // Arrange
        var materialBase = new MaterialBase();
        var insectBody = new InsectBody(6, "yes", 0, 0);
        MaterialDel del = new();

        // Act
        materialBase.MaterialAdd(insectBody);
        Assert.AreEqual(-3, del.GetMaterialBuildingValue());
    }

    [Test]
    public void MaterialAdd_HealthFour_Adds2Material()
    {
        // Arrange
        var materialBase = new MaterialBase();
        var insectBody = new InsectBody(4, "yes", 0, 0);
        MaterialDel del = new();

        // Act
        materialBase.MaterialAdd(insectBody);

        Assert.AreEqual(-8, del.GetMaterialBuildingValue());
    }

    [Test]
    public void MaterialAdd_OtherHealthValues_Adds1Material()
    {
        // Arrange
        var materialBase = new MaterialBase();
        var insectBody = new InsectBody(2, "yes", 0, 0); // For health values other than 6 or 4
        MaterialDel del = new();

        // Act
        materialBase.MaterialAdd(insectBody);

        Assert.AreEqual(-2, del.GetMaterialBuildingValue());
    }

    [Test]
    public void MaterialDelHouse_Subtracts50MaterialBuilding()
    {
        // Arrange
        var materialBase = new MaterialBase();
        MaterialDel del = new();

        // Act
        materialBase.MaterialDelHouse();

        Assert.AreEqual(-52, del.GetMaterialBuildingValue());
    }
}