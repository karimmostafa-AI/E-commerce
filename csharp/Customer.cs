// csharp/Customer.cs
using System;

namespace ECommerce
{
    public class Customer
    {
        public string Name { get; private set; }
        public double Balance { get; private set; }

        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        public void DeductBalance(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("Insufficient balance");
            }
            Balance -= amount;
        }

        public bool HasBalance(double amount)
        {
            return Balance >= amount;
        }
    }
}
