using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDAssignment.Task.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TDDAssignmentTests.Task.Test.Test1
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            Calculator calculator = new Calculator();
            float a = 5;
            float b = 10;
            float expected = 15;
            // Act
            float actual = calculator.Add(a, b);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubtractTest()
        {
            // Arrange
            Calculator calculator = new Calculator();
            float a = 10;
            float b = 5;
            float expected = 5;
            // Act
            float actual = calculator.Subtract(a, b);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            // Arrange
            Calculator calculator = new Calculator();
            float a = 5;
            float b = 10;
            float expected = 50;
            // Act
            float actual = calculator.Multiply(a, b);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideTest()
        {
            // Arrange
            Calculator calculator = new Calculator();
            float a = 10;
            float b = 5;
            float expected = 2;
            // Act
            float actual = calculator.Divide(a, b);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DivideByZeroTest()
        {
            // Arrange
            Calculator calculator = new Calculator();
            float a = 10;
            float b = 0;
            // Act and Assert
            Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(a, b));
        }
        [TestMethod()]
        public void DivideByDecimalTest()
        {
            //Arrange
            Calculator calculator = new Calculator();
            float a = 1;
            float b = 0.003f;
            float expected = 333.33334f;
            //Act
            float actual = calculator.Divide(a, b);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void MultiplhyByNaNTest()
        {
            Calculator calculator = new Calculator();
            float a = 5;
            float b = float.NaN;
            float expected = float.NaN;
            //Act
            float actual = calculator.Multiply(a, b);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void AddByFloatNumberTest()
        {
            //Arrange
            Calculator calculator = new Calculator();
            float a = 1.2f;
            float b = 2.3f;
            float expected = 3.5f;
            //Act
            float actual = calculator.Add(a, b);
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}