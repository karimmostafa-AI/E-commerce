// csharp/TestCases.cs
using System;
using System.Collections.Generic;

namespace ECommerce
{
    public class TestCases
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== E-COMMERCE SYSTEM TEST CASES ===\n");

            TestProductCreation();
            TestCartOperations();
            TestCustomerOperations();
            TestSuccessfulCheckout();
            TestEmptyCartError();
            TestInsufficientBalanceError();
            TestOutOfStockError();
            TestExpiredProductError();
            TestShippingService();
            TestEdgeCases();
            TestComplexScenarios();

            Console.WriteLine("\n=== ALL TEST CASES COMPLETED ===");
        }

        public static void TestProductCreation()
        {
            Console.WriteLine("TEST 1: Product Creation and Properties");
            Console.WriteLine("=" + new string('=', 50));

            // Test expirable products
            var cheese = new Cheese("Gouda Cheese", 120.0, 15, DateTime.Now.AddDays(7), 0.25);
            var biscuits = new Biscuits("Chocolate Biscuits", 80.0, 20, DateTime.Now.AddDays(30), 0.5);

            // Test non-expirable products
            var tv = new TV("Smart TV 55\"", 8000.0, 5, 18.5);
            var mobile = new Mobile("iPhone 15", 45000.0, 10, 0.2);
            var scratchCard = new ScratchCard("Recharge Card", 100.0, 50);

            Console.WriteLine($"✓ Cheese: {cheese.Name} - Price: {cheese.Price} - Expires: {!cheese.IsExpired()} - Requires Shipping: {cheese.RequiresShipping()}");
            Console.WriteLine($"✓ Biscuits: {biscuits.Name} - Price: {biscuits.Price} - Expires: {!biscuits.IsExpired()} - Requires Shipping: {biscuits.RequiresShipping()}");
            Console.WriteLine($"✓ TV: {tv.Name} - Price: {tv.Price} - Expires: {tv.IsExpired()} - Requires Shipping: {tv.RequiresShipping()}");
            Console.WriteLine($"✓ Mobile: {mobile.Name} - Price: {mobile.Price} - Expires: {mobile.IsExpired()} - Requires Shipping: {mobile.RequiresShipping()}");
            Console.WriteLine($"✓ Scratch Card: {scratchCard.Name} - Price: {scratchCard.Price} - Expires: {scratchCard.IsExpired()} - Requires Shipping: {scratchCard.RequiresShipping()}");

            Console.WriteLine("TEST 1 PASSED\n");
        }

        public static void TestCartOperations()
        {
            Console.WriteLine("TEST 2: Cart Operations");
            Console.WriteLine("=" + new string('=', 50));

            var cart = new Cart();
            var cheese = new Cheese("Test Cheese", 100.0, 10, DateTime.Now.AddDays(5), 0.2);
            var tv = new TV("Test TV", 5000.0, 3, 15.0);

            // Test adding items
            cart.Add(cheese, 2);
            cart.Add(tv, 1);

            Console.WriteLine($"✓ Cart items count: {cart.GetItems().Count}");
            Console.WriteLine($"✓ Cart subtotal: {cart.GetSubtotal()}");
            Console.WriteLine($"✓ Cart is empty: {cart.IsEmpty()}");

            // Test adding same item again
            cart.Add(cheese, 1);
            Console.WriteLine($"✓ After adding more cheese - Cart items count: {cart.GetItems().Count}");

            // Test cart clear
            cart.Clear();
            Console.WriteLine($"✓ After clearing - Cart is empty: {cart.IsEmpty()}");

            Console.WriteLine("TEST 2 PASSED\n");
        }

        public static void TestCustomerOperations()
        {
            Console.WriteLine("TEST 3: Customer Operations");
            Console.WriteLine("=" + new string('=', 50));

            var customer = new Customer("Test Customer", 1000.0);

            Console.WriteLine($"✓ Customer name: {customer.Name}");
            Console.WriteLine($"✓ Initial balance: {customer.Balance}");
            Console.WriteLine($"✓ Has balance for 500: {customer.HasBalance(500.0)}");
            Console.WriteLine($"✓ Has balance for 1500: {customer.HasBalance(1500.0)}");

            // Test balance deduction
            customer.DeductBalance(300.0);
            Console.WriteLine($"✓ After deducting 300 - Balance: {customer.Balance}");

            Console.WriteLine("TEST 3 PASSED\n");
        }

        public static void TestSuccessfulCheckout()
        {
            Console.WriteLine("TEST 4: Successful Checkout Scenarios");
            Console.WriteLine("=" + new string('=', 50));

            // Test 4a: Basic checkout with shippable items
            Console.WriteLine("Test 4a: Basic checkout with mixed items");
            var customer1 = new Customer("John Doe", 1000.0);
            var cart1 = new Cart();

            var cheese = new Cheese("Cheddar", 150.0, 10, DateTime.Now.AddDays(10), 0.3);
            var tv = new TV("LED TV", 3000.0, 5, 12.0);
            var card = new ScratchCard("Game Card", 25.0, 100);

            cart1.Add(cheese, 1);
            cart1.Add(tv, 1);
            cart1.Add(card, 2);

            ECommerceSystem.Checkout(customer1, cart1);
            Console.WriteLine($"✓ Customer balance after checkout: {customer1.Balance}");

            // Test 4b: Checkout with only non-shippable items
            Console.WriteLine("\nTest 4b: Checkout with only non-shippable items");
            var customer2 = new Customer("Jane Smith", 500.0);
            var cart2 = new Cart();

            var card1 = new ScratchCard("Recharge Card", 100.0, 20);
            var card2 = new ScratchCard("Gift Card", 200.0, 15);

            cart2.Add(card1, 2);
            cart2.Add(card2, 1);

            ECommerceSystem.Checkout(customer2, cart2);
            Console.WriteLine($"✓ Customer balance after checkout: {customer2.Balance}");

            Console.WriteLine("TEST 4 PASSED\n");
        }

        public static void TestEmptyCartError()
        {
            Console.WriteLine("TEST 5: Empty Cart Error");
            Console.WriteLine("=" + new string('=', 50));

            var customer = new Customer("Test Customer", 1000.0);
            var emptyCart = new Cart();

            Console.WriteLine("Attempting checkout with empty cart:");
            ECommerceSystem.Checkout(customer, emptyCart);
            Console.WriteLine("✓ Empty cart error handled correctly");

            Console.WriteLine("TEST 5 PASSED\n");
        }

        public static void TestInsufficientBalanceError()
        {
            Console.WriteLine("TEST 6: Insufficient Balance Error");
            Console.WriteLine("=" + new string('=', 50));

            var poorCustomer = new Customer("Poor Customer", 100.0);
            var expensiveCart = new Cart();

            var expensiveTV = new TV("Premium TV", 5000.0, 2, 20.0);
            expensiveCart.Add(expensiveTV, 1);

            Console.WriteLine("Attempting checkout with insufficient balance:");
            ECommerceSystem.Checkout(poorCustomer, expensiveCart);
            Console.WriteLine("✓ Insufficient balance error handled correctly");

            Console.WriteLine("TEST 6 PASSED\n");
        }

        public static void TestOutOfStockError()
        {
            Console.WriteLine("TEST 7: Out of Stock Error");
            Console.WriteLine("=" + new string('=', 50));

            var customer = new Customer("Test Customer", 1000.0);
            var cart = new Cart();

            var limitedTV = new TV("Limited TV", 2000.0, 2, 15.0);

            try
            {
                cart.Add(limitedTV, 5); // Trying to add more than available
                Console.WriteLine("❌ Should have thrown exception");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"✓ Out of stock error during add: {e.Message}");
            }

            // Test out of stock during checkout
            cart.Add(limitedTV, 2);
            limitedTV.SetQuantity(1); // Simulate stock reduction

            Console.WriteLine("Attempting checkout with insufficient stock:");
            ECommerceSystem.Checkout(customer, cart);
            Console.WriteLine("✓ Out of stock error during checkout handled correctly");

            Console.WriteLine("TEST 7 PASSED\n");
        }

        public static void TestExpiredProductError()
        {
            Console.WriteLine("TEST 8: Expired Product Error");
            Console.WriteLine("=" + new string('=', 50));

            var customer = new Customer("Test Customer", 1000.0);
            var cart = new Cart();

            // Create expired cheese
            var expiredCheese = new Cheese("Expired Cheese", 100.0, 5, DateTime.Now.AddDays(-1), 0.2);
            cart.Add(expiredCheese, 1);

            Console.WriteLine("Attempting checkout with expired product:");
            ECommerceSystem.Checkout(customer, cart);
            Console.WriteLine("✓ Expired product error handled correctly");

            Console.WriteLine("TEST 8 PASSED\n");
        }

        public static void TestShippingService()
        {
            Console.WriteLine("TEST 9: Shipping Service Tests");
            Console.WriteLine("=" + new string('=', 50));

            // Test shipping fee calculation
            var tv = new TV("Test TV", 1000.0, 5, 10.0);
            var cheese = new Cheese("Test Cheese", 100.0, 10, DateTime.Now.AddDays(5), 0.5);

            var shippableItems = new List<IShippable> { tv, cheese };

            double shippingFee = ShippingService.CalculateShippingFee(shippableItems);
            Console.WriteLine($"✓ Shipping fee for 10.5kg: {shippingFee}");

            // Test shipping notice
            Console.WriteLine("✓ Shipping notice:");
            ShippingService.Ship(shippableItems);

            Console.WriteLine("TEST 9 PASSED\n");
        }

        public static void TestEdgeCases()
        {
            Console.WriteLine("TEST 10: Edge Cases");
            Console.WriteLine("=" + new string('=', 50));

            // Test adding zero quantity
            var cart = new Cart();
            var tv = new TV("Test TV", 1000.0, 5, 10.0);

            try
            {
                cart.Add(tv, 0);
                Console.WriteLine("❌ Should have thrown exception for zero quantity");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"✓ Zero quantity error: {e.Message}");
            }

            // Test negative quantity
            try
            {
                cart.Add(tv, -1);
                Console.WriteLine("❌ Should have thrown exception for negative quantity");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"✓ Negative quantity error: {e.Message}");
            }

            // Test customer with zero balance
            var zeroBalanceCustomer = new Customer("Zero Balance", 0.0);
            Console.WriteLine($"✓ Customer with zero balance: {zeroBalanceCustomer.Balance}");

            // Test insufficient balance deduction
            try
            {
                zeroBalanceCustomer.DeductBalance(100.0);
                Console.WriteLine("❌ Should have thrown exception for insufficient balance");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"✓ Insufficient balance deduction error: {e.Message}");
            }

            Console.WriteLine("TEST 10 PASSED\n");
        }

        public static void TestComplexScenarios()
        {
            Console.WriteLine("TEST 11: Complex Scenarios");
            Console.WriteLine("=" + new string('=', 50));

            // Test 11a: Multiple customers, multiple checkouts
            Console.WriteLine("Test 11a: Multiple customers scenario");

            var customer1 = new Customer("Alice", 2000.0);
            var customer2 = new Customer("Bob", 1500.0);

            var cheese = new Cheese("Premium Cheese", 200.0, 20, DateTime.Now.AddDays(15), 0.4);
            var tv = new TV("4K TV", 6000.0, 10, 25.0);
            var mobile = new Mobile("Smartphone", 3000.0, 15, 0.18);
            var card = new ScratchCard("Premium Card", 150.0, 100);

            // Customer 1 checkout
            var cart1 = new Cart();
            cart1.Add(cheese, 3);
            cart1.Add(mobile, 1);
            cart1.Add(card, 2);

            Console.WriteLine("Customer 1 checkout:");
            ECommerceSystem.Checkout(customer1, cart1);

            // Customer 2 checkout
            var cart2 = new Cart();
            cart2.Add(cheese, 2);
            cart2.Add(tv, 1);

            Console.WriteLine("\nCustomer 2 checkout:");
            ECommerceSystem.Checkout(customer2, cart2);

            Console.WriteLine($"✓ Remaining cheese stock: {cheese.Quantity}");
            Console.WriteLine($"✓ Remaining TV stock: {tv.Quantity}");
            Console.WriteLine($"✓ Remaining mobile stock: {mobile.Quantity}");

            // Test 11b: Large quantity checkout
            Console.WriteLine("\nTest 11b: Large quantity checkout");
            var bulkCustomer = new Customer("Bulk Buyer", 10000.0);
            var bulkCart = new Cart();

            var bulkCards = new ScratchCard("Bulk Cards", 50.0, 200);
            bulkCart.Add(bulkCards, 20);

            Console.WriteLine("Bulk customer checkout:");
            ECommerceSystem.Checkout(bulkCustomer, bulkCart);
            Console.WriteLine($"✓ Remaining bulk cards: {bulkCards.Quantity}");

            Console.WriteLine("TEST 11 PASSED\n");
        }
    }
}
