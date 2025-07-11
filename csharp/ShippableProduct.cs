// csharp/ShippableProduct.cs
namespace ECommerce
{
    public abstract class ShippableProduct : Product, IShippable
    {
        public double Weight { get; protected set; }

        public ShippableProduct(string name, double price, int quantity, double weight)
            : base(name, price, quantity)
        {
            Weight = weight;
        }

        public override bool RequiresShipping()
        {
            return true;
        }
    }
}
