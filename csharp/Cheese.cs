// csharp/Cheese.cs
using System;

namespace ECommerce
{
    public class Cheese : ExpirableProduct, IShippable
    {
        public double Weight { get; protected set; }

        public Cheese(string name, double price, int quantity, DateTime expiryDate, double weight)
            : base(name, price, quantity, expiryDate)
        {
            Weight = weight;
        }

        public override bool RequiresShipping()
        {
            return true;
        }
    }
}
