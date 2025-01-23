using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDAssignment.Task.Task5;

namespace TDDAssignmentTests.Test.Test5
{
    [TestClass()]
    public class InventoryManagerTests
    {
        [TestMethod()]
        public void AddItemTest()
        {
            //Arrange
            var inventoryManager = new InventoryManager();
            //Act
            inventoryManager.AddItem("Item1", 10);
            inventoryManager.AddItem("Item1", 20);
            //Assert
            Assert.AreEqual(30, inventoryManager.GetQuantity("Item1"));
        }
        [TestMethod()]
        public void RemoveItemTest()
        {
            //Arrange
            var inventoryManager = new InventoryManager();
            //Act
            inventoryManager.AddItem("Item1", 10);
            inventoryManager.RemoveItem("Item1", 5);
            //Assert
            Assert.AreEqual(5, inventoryManager.GetQuantity("Item1"));
        }
        [TestMethod()]
        public void GetOutOfStockItemsTest()
        {
            //Arrange
            var inventoryManager = new InventoryManager();
            //Act
            inventoryManager.AddItem("Item1", 10);
            inventoryManager.AddItem("Item2", 0);
            inventoryManager.AddItem("Item3", 5);
            //Assert
            var expectedOutOfStockItems = new List<string> { "Item2" };
            CollectionAssert.AreEqual(expectedOutOfStockItems, inventoryManager.GetOutOfStockItems());
        }
        [TestMethod()]
        public void RemoveItemTestMoreThanAvailable()
        {
            //Arrange
            var inventoryManager = new InventoryManager();
            //Act
            inventoryManager.AddItem("Item1", 10);
            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => inventoryManager.RemoveItem("Item1", 15));
        }
        [TestMethod()]
        public void AddItemTestNegativeQuantity()
        {
            //Arrange
            var inventoryManager = new InventoryManager();
            //Assert
            Assert.ThrowsException<ArgumentException>(() => inventoryManager.AddItem("Item1", -10));
        }
        [TestMethod()]
        public void AddItemTestNullItem()
        {
            //Arrange
            var inventoryManager = new InventoryManager();
            //Assert
            Assert.ThrowsException<ArgumentException>(() => inventoryManager.AddItem(null, 10));
        }
        [TestMethod()]
        public void AddNullNumberOfItems()
        {
            //Arrange
           var inventoryManager = new InventoryManager();
            //Act&Assert
            inventoryManager.AddItem("Item1", 0);
            Assert.AreEqual(0, inventoryManager.GetQuantity("Item1"));
        }
        [TestMethod()]
        public void RemoveItemWhenNotAvalibaleInInventory()
        {
            //Arrange
            var inventoryManager = new InventoryManager();
            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => inventoryManager.RemoveItem("Item1", 10));
        }
        [TestMethod()]
        public void GetQuantityWhickNeverAdded()
        {
            //Arrange
            var inventoryManager = new InventoryManager();
            //Act
            var quantity = inventoryManager.GetQuantity("Item1");
            //Assert
            Assert.AreEqual(0, quantity);
        }
        [TestMethod()]
        public void RemoveItemMoreThanAvailable()
        {
            //Arrange
            var inventoryManager = new InventoryManager();
            //Act
            inventoryManager.AddItem("Item1", 10);
            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => inventoryManager.RemoveItem("Item1", 15));
        }
    }
}