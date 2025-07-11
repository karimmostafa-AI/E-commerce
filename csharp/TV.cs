// csharp/TV.cs
namespace ECommerce
{
    public class TV : ShippableProduct
    {
        public TV(string name, double price, int quantity, double weight)
            : base(name, price, quantity, weight)
        {
        }

        public override bool IsExpired()
        {
            return false;
        }
    }
}
