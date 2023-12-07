using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Helper helperInstance;

        [TestInitialize]
        public void SetUp()
        {
            helperInstance = new Helper();
        }

        [TestMethod]
        public void EnsureValuesSet_DefaultValues_AreSet()
        {
            // Arrange
            helperInstance.MaterialBuilding = 0;
            helperInstance.Food = 0;
            helperInstance.Water = 0;

            // Act
            helperInstance.EnsureValuesSet();

            // Assert
            Assert.AreEqual(50, helperInstance.MaterialBuilding);
            Assert.AreEqual(2000, helperInstance.Food);
            Assert.AreEqual(2000, helperInstance.Water);
        }

        [TestMethod]
        public void SaveMaterialData_FileExists()
        {
            // Arrange
            helperInstance.MaterialBuilding = 50;
            helperInstance.Food = 2000;
            helperInstance.Water = 2000;

            // Act
            helperInstance.SaveMaterialData();

            // Assert
            Assert.IsTrue(File.Exists("DataBaseMFW2.txt"));
        }

        [TestMethod]
        public void LoadMaterialData_DataIsLoaded()
        {
            // Arrange
            helperInstance.MaterialBuilding = 50;
            helperInstance.Food = 2000;
            helperInstance.Water = 2000;
            helperInstance.SaveMaterialData();

            // Act
            helperInstance.MaterialBuilding = 0;
            helperInstance.Food = 0;
            helperInstance.Water = 0;
            helperInstance.LoadMaterialData();

            // Assert
            Assert.AreEqual(50, helperInstance.MaterialBuilding);
            Assert.AreEqual(2000, helperInstance.Food);
            Assert.AreEqual(2000, helperInstance.Water);
        }

        [TestCleanup]
        public void TearDown()
        {
            if (File.Exists("DataBaseMFW2.txt"))
            {
                File.Delete("DataBaseMFW2.txt");
            }
        }
    }
}
