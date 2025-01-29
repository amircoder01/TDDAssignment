using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task4
{
    public class BankAccount
    {
        private decimal _balance;

        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Initial balance must be greater than 0");
            }
            _balance = initialBalance;
        }
        public decimal GetBalance()
        {
            return _balance;
        }
        public decimal Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
            if(amount == 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
            _balance += amount;
            return _balance;
        }
        public decimal Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
            if (amount == 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
            if (amount > _balance)
            {
                throw new ArgumentException("Insufficient funds");
            }
            _balance -= amount;
            return _balance;
        }
    }
}
