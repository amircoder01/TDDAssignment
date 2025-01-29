using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDAssignment.Task.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task2.Tests
{
    [TestClass()]
    public class StringProcessorTests
    {
        [TestMethod()]
        public void ToLowerCaseTest()
        {
            // Arrange
            StringProcessor stringProcessor = new StringProcessor();
            string input = "HELLO";
            string expected = "hello";
            // Act
            string actual = stringProcessor.ToLowerCase(input);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SanitizeTest()
        {
            // Arrange
            StringProcessor stringProcessor = new StringProcessor();
            string input = "Hello? World";
            string expected = "Hello World";
            // Act
            string actual = stringProcessor.Sanitize(input);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AreEqualTest()
        {
            // Arrange
            StringProcessor stringProcessor = new StringProcessor();
            string input1 = "Hello World";
            string input2 = "Hello world";
            // Act
            bool actual = stringProcessor.AreEqual(input1, input2);
            // Assert
            Assert.IsTrue(actual);
        }
        [TestMethod()]
        public void IsEqualSanitizeTest()
        {
            StringProcessor stringProcessor = new StringProcessor();
            string input1 = "Hello? World";
            string input2 = "Hello world";
            // Act
            bool actual = stringProcessor.AreEqual(input1, input2);
            // Assert
            Assert.IsTrue(actual);
        }
        [TestMethod()]
        public void ShouldReturnFalseForReturnDiffrentString()
        {
            StringProcessor stringProcessor = new StringProcessor();
            string input1 = "Hello World";
            string input2 = "GoodBye";
            // Act
            bool actual = stringProcessor.AreEqual(input1, input2);
            // Assert
            Assert.IsFalse(actual);
        }
    }
}