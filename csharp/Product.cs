// csharp/Product.cs
using System;

namespace ECommerce
{
    public abstract class Product
    {
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public int Quantity { get; protected set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public bool IsAvailable(int requestedQuantity)
        {
            return Quantity >= requestedQuantity;
        }

        public abstract bool IsExpired();
        public abstract bool RequiresShipping();
    }
}
