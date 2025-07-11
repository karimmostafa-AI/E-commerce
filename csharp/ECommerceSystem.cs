// csharp/ECommerceSystem.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce
{
    public class ECommerceSystem
    {
        public static void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
            {
                Console.WriteLine("Error: Cart is empty");
                return;
            }

            var shippableItems = new List<IShippable>();
            foreach (var item in cart.GetItems())
            {
                var product = item.Product;

                if (product.IsExpired())
                {
                    Console.WriteLine($"Error: {product.Name} is expired");
                    return;
                }

                if (!product.IsAvailable(item.Quantity))
                {
                    Console.WriteLine($"Error: {product.Name} is out of stock");
                    return;
                }

                if (product.RequiresShipping() && product is IShippable shippable)
                {
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        shippableItems.Add(shippable);
                    }
                }
            }

            double subtotal = cart.GetSubtotal();
            double shippingFee = ShippingService.CalculateShippingFee(shippableItems);
            double totalAmount = subtotal + shippingFee;

            if (!customer.HasBalance(totalAmount))
            {
                Console.WriteLine("Error: Customer's balance is insufficient");
                return;
            }

            customer.DeductBalance(totalAmount);

            foreach (var item in cart.GetItems())
            {
                var product = item.Product;
                product.SetQuantity(product.Quantity - item.Quantity);
            }

            if (shippableItems.Any())
            {
                ShippingService.Ship(shippableItems);
            }

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.GetItems())
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name} {(int)item.GetTotalPrice()}");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal {(int)subtotal}");
            Console.WriteLine($"Shipping {(int)shippingFee}");
            Console.WriteLine($"Amount {(int)totalAmount}");
            Console.WriteLine($"Customer balance after payment: {customer.Balance}");

            cart.Clear();
        }
    }
}
