using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDAssignment.Task;
using TDDAssignment.Task.Task6;
using TDDAssignment.Task.Task7;

namespace TDDAssignmentTests.Test.Task7
{
    [TestClass()]
    public class ObjectValidatorTests
    {
        [TestMethod()]
        public void IsNullTest()
        {
            // Arrange
            ObjectValidator objectValidator = new ObjectValidator();
            object obj = null;
            // Act
            bool result = objectValidator.IsNull(obj);
            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void IsNotNullFalseTest()
        {
            ObjectValidator objectValidator = new ObjectValidator();
            object obj = new object();
            // Act
            bool result = objectValidator.IsNull(obj);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void GetNullPropertiesReturnListTest()
        {
            // Arrange
            ObjectValidator objectValidator = new ObjectValidator();
            var testObject = new TestClass
            {
                Name = null,
                Age = 0,
                Address = null
            };
            // Act
            List<string> result = objectValidator.GetNullProperties(testObject);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new List<string> { "Name", "Address" }, result);
        }
        [TestMethod()]
        public void GetNullPropertiesReturnEmptyListTest()
        {
            // Arrange
            ObjectValidator objectValidator = new ObjectValidator();
            var testObject = new TestClass
            {
                Name = "Test",
                Age = 0,
                Address = "Test"
            };
            // Act
            List<string> result = objectValidator.GetNullProperties(testObject);
            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod()]
        public void IfObjectHasNoPropertieseturnEmptyListTest()
        {
            // Arrange
            ObjectValidator objectValidator = new ObjectValidator();
            var testObject = new object();
            // Act
            List<string> result = objectValidator.GetNullProperties(testObject);
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod()]
        public void SentAnIntInstedOfObjectReturnEmptyListTest()
        {
            // Arrange
            ObjectValidator objectValidator = new ObjectValidator();
            int testObject = 42;
            // Act&Aseert
            Assert.ThrowsException<ArgumentException>(() => objectValidator.GetNullProperties(testObject));
        }
    }
}