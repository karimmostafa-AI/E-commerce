// csharp/ExpirableProduct.cs
using System;

namespace ECommerce
{
    public abstract class ExpirableProduct : Product
    {
        public DateTime ExpiryDate { get; protected set; }

        public ExpirableProduct(string name, double price, int quantity, DateTime expiryDate)
            : base(name, price, quantity)
        {
            ExpiryDate = expiryDate;
        }

        public override bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }
    }
}
