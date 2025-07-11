// csharp/Main.cs
using System;

namespace ECommerce
{
    public class MainApp
    {
        public static void Main(string[] args)
        {
            // Create products
            var cheese = new Cheese("Cheese", 100.0, 10, DateTime.Now.AddDays(30), 0.2); // 200g
            var biscuits = new Biscuits("Biscuits", 150.0, 5, DateTime.Now.AddDays(60), 0.7); // 700g
            var tv = new TV("TV", 5000.0, 3, 15.0); // 15kg
            var scratchCard = new ScratchCard("Mobile Scratch Card", 50.0, 20);

            // Create customer with sufficient balance
            var customer = new Customer("John Doe", 1000.0);

            // Create cart
            var cart = new Cart();

            // Add products to cart (as per example)
            cart.Add(cheese, 2);
            cart.Add(biscuits, 1);
            cart.Add(scratchCard, 1);

            // Checkout
            Console.WriteLine("=== Example 1: Successful Checkout ===");
            ECommerceSystem.Checkout(customer, cart);

            Console.WriteLine("\n=== Example 2: Empty Cart ===");
            var emptyCart = new Cart();
            ECommerceSystem.Checkout(customer, emptyCart);

            Console.WriteLine("\n=== Example 3: Insufficient Balance ===");
            var poorCustomer = new Customer("Jane Doe", 50.0);
            var expensiveCart = new Cart();
            expensiveCart.Add(tv, 1);
            ECommerceSystem.Checkout(poorCustomer, expensiveCart);

            Console.WriteLine("\n=== Example 4: Out of Stock ===");
            var outOfStockCart = new Cart();
            try
            {
                outOfStockCart.Add(cheese, 15); // Only 8 left after previous purchase
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.WriteLine("\n=== Example 5: Expired Product ===");
            var expiredCheese = new Cheese("Expired Cheese", 100.0, 5, DateTime.Now.AddDays(-1), 0.2);
            var expiredCart = new Cart();
            expiredCart.Add(expiredCheese, 1);
            ECommerceSystem.Checkout(customer, expiredCart);

            Console.WriteLine("\n=== Example 6: Mixed Cart with Shipping ===");
            var mixedCart = new Cart();
            mixedCart.Add(cheese, 1);
            mixedCart.Add(tv, 1);
            mixedCart.Add(scratchCard, 2);
            ECommerceSystem.Checkout(customer, mixedCart);
        }
    }
}
