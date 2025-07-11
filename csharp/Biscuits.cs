// csharp/Biscuits.cs
using System;

namespace ECommerce
{
    public class Biscuits : ExpirableProduct, IShippable
    {
        public double Weight { get; protected set; }

        public Biscuits(string name, double price, int quantity, DateTime expiryDate, double weight)
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
