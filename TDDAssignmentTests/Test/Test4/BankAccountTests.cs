using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDAssignment.Task.Task4;

namespace TDDAssignmentTests.Test.Test4
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        public void DepositTest()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount(100);
            decimal expected = 150;
            // Act
            decimal actual = bankAccount.Deposit(50);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void WithdrawTest()
        {
            BankAccount bankAccount = new BankAccount(100);
            decimal expected = 50;
            // Act
            decimal actual = bankAccount.Withdraw(50);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void WithdrawTestWhenSaldoIsNotEnough()
        {
            BankAccount bankAccount = new BankAccount(100);
            // Act
            Assert.ThrowsException<ArgumentException>(() => bankAccount.Withdraw(150));
        }
        [TestMethod()]
        public void NegativeDepositTest()
        {
            BankAccount bankAccount = new BankAccount(100);
            // Act
            Assert.ThrowsException<ArgumentException>(() => bankAccount.Deposit(-50));
        }
        [TestMethod()]
        public void NullWithdrawTest()
        {
            BankAccount bankAccount = new BankAccount(100);
            // Act
            Assert.ThrowsException<ArgumentException>(() => bankAccount.Withdraw(0));
        }
        [TestMethod()]
        public void DepositNullTest()
        {
            BankAccount bankAccount = new BankAccount(100);
            // Act
            Assert.ThrowsException<ArgumentException>(() => bankAccount.Deposit(0));
        }

    }
}