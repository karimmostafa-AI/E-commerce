// csharp/ScratchCard.cs
namespace ECommerce
{
    public class ScratchCard : Product
    {
        public ScratchCard(string name, double price, int quantity)
            : base(name, price, quantity)
        {
        }

        public override bool IsExpired()
        {
            return false;
        }

        public override bool RequiresShipping()
        {
            return false;
        }
    }
}
