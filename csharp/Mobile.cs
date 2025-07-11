// csharp/Mobile.cs
namespace ECommerce
{
    public class Mobile : ShippableProduct
    {
        public Mobile(string name, double price, int quantity, double weight)
            : base(name, price, quantity, weight)
        {
        }

        public override bool IsExpired()
        {
            return false;
        }
    }
}
