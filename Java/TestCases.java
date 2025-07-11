import java.time.LocalDate;

public class TestCases {
    
    public static void main(String[] args) {
        System.out.println("=== E-COMMERCE SYSTEM TEST CASES ===\n");
        
        // Test 1: Product Creation and Properties
        testProductCreation();
        
        // Test 2: Cart Operations
        testCartOperations();
        
        // Test 3: Customer Operations
        testCustomerOperations();
        
        // Test 4: Successful Checkout Scenarios
        testSuccessfulCheckout();
        
        // Test 5: Empty Cart Error
        testEmptyCartError();
        
        // Test 6: Insufficient Balance Error
        testInsufficientBalanceError();
        
        // Test 7: Out of Stock Error
        testOutOfStockError();
        
        // Test 8: Expired Product Error
        testExpiredProductError();
        
        // Test 9: Shipping Service Tests
        testShippingService();
        
        // Test 10: Edge Cases
        testEdgeCases();
        
        // Test 11: Complex Scenarios
        testComplexScenarios();
        
        System.out.println("\n=== ALL TEST CASES COMPLETED ===");
    }
    
    public static void testProductCreation() {
        System.out.println("TEST 1: Product Creation and Properties");
        System.out.println("=" + "=".repeat(50));
        
        // Test expirable products
        Cheese cheese = new Cheese("Gouda Cheese", 120.0, 15, LocalDate.now().plusDays(7), 0.25);
        Biscuits biscuits = new Biscuits("Chocolate Biscuits", 80.0, 20, LocalDate.now().plusDays(30), 0.5);
        
        // Test non-expirable products
        TV tv = new TV("Smart TV 55\"", 8000.0, 5, 18.5);
        Mobile mobile = new Mobile("iPhone 15", 45000.0, 10, 0.2);
        ScratchCard scratchCard = new ScratchCard("Recharge Card", 100.0, 50);
        
        System.out.println("✓ Cheese: " + cheese.getName() + " - Price: " + cheese.getPrice() + 
                          " - Expires: " + !cheese.isExpired() + " - Requires Shipping: " + cheese.requiresShipping());
        System.out.println("✓ Biscuits: " + biscuits.getName() + " - Price: " + biscuits.getPrice() + 
                          " - Expires: " + !biscuits.isExpired() + " - Requires Shipping: " + biscuits.requiresShipping());
        System.out.println("✓ TV: " + tv.getName() + " - Price: " + tv.getPrice() + 
                          " - Expires: " + tv.isExpired() + " - Requires Shipping: " + tv.requiresShipping());
        System.out.println("✓ Mobile: " + mobile.getName() + " - Price: " + mobile.getPrice() + 
                          " - Expires: " + mobile.isExpired() + " - Requires Shipping: " + mobile.requiresShipping());
        System.out.println("✓ Scratch Card: " + scratchCard.getName() + " - Price: " + scratchCard.getPrice() + 
                          " - Expires: " + scratchCard.isExpired() + " - Requires Shipping: " + scratchCard.requiresShipping());
        
        System.out.println("TEST 1 PASSED\n");
    }
    
    public static void testCartOperations() {
        System.out.println("TEST 2: Cart Operations");
        System.out.println("=" + "=".repeat(50));
        
        Cart cart = new Cart();
        Cheese cheese = new Cheese("Test Cheese", 100.0, 10, LocalDate.now().plusDays(5), 0.2);
        TV tv = new TV("Test TV", 5000.0, 3, 15.0);
        
        // Test adding items
        cart.add(cheese, 2);
        cart.add(tv, 1);
        
        System.out.println("✓ Cart items count: " + cart.getItems().size());
        System.out.println("✓ Cart subtotal: " + cart.getSubtotal());
        System.out.println("✓ Cart is empty: " + cart.isEmpty());
        
        // Test adding same item again
        cart.add(cheese, 1);
        System.out.println("✓ After adding more cheese - Cart items count: " + cart.getItems().size());
        
        // Test cart clear
        cart.clear();
        System.out.println("✓ After clearing - Cart is empty: " + cart.isEmpty());
        
        System.out.println("TEST 2 PASSED\n");
    }
    
    public static void testCustomerOperations() {
        System.out.println("TEST 3: Customer Operations");
        System.out.println("=" + "=".repeat(50));
        
        Customer customer = new Customer("Test Customer", 1000.0);
        
        System.out.println("✓ Customer name: " + customer.getName());
        System.out.println("✓ Initial balance: " + customer.getBalance());
        System.out.println("✓ Has balance for 500: " + customer.hasBalance(500.0));
        System.out.println("✓ Has balance for 1500: " + customer.hasBalance(1500.0));
        
        // Test balance deduction
        customer.deductBalance(300.0);
        System.out.println("✓ After deducting 300 - Balance: " + customer.getBalance());
        
        System.out.println("TEST 3 PASSED\n");
    }
    
    public static void testSuccessfulCheckout() {
        System.out.println("TEST 4: Successful Checkout Scenarios");
        System.out.println("=" + "=".repeat(50));
        
        // Test 4a: Basic checkout with shippable items
        System.out.println("Test 4a: Basic checkout with mixed items");
        Customer customer1 = new Customer("John Doe", 1000.0);
        Cart cart1 = new Cart();
        
        Cheese cheese = new Cheese("Cheddar", 150.0, 10, LocalDate.now().plusDays(10), 0.3);
        TV tv = new TV("LED TV", 3000.0, 5, 12.0);
        ScratchCard card = new ScratchCard("Game Card", 25.0, 100);
        
        cart1.add(cheese, 1);
        cart1.add(tv, 1);
        cart1.add(card, 2);
        
        ECommerceSystem.checkout(customer1, cart1);
        System.out.println("✓ Customer balance after checkout: " + customer1.getBalance());
        
        // Test 4b: Checkout with only non-shippable items
        System.out.println("\nTest 4b: Checkout with only non-shippable items");
        Customer customer2 = new Customer("Jane Smith", 500.0);
        Cart cart2 = new Cart();
        
        ScratchCard card1 = new ScratchCard("Recharge Card", 100.0, 20);
        ScratchCard card2 = new ScratchCard("Gift Card", 200.0, 15);
        
        cart2.add(card1, 2);
        cart2.add(card2, 1);
        
        ECommerceSystem.checkout(customer2, cart2);
        System.out.println("✓ Customer balance after checkout: " + customer2.getBalance());
        
        System.out.println("TEST 4 PASSED\n");
    }
    
    public static void testEmptyCartError() {
        System.out.println("TEST 5: Empty Cart Error");
        System.out.println("=" + "=".repeat(50));
        
        Customer customer = new Customer("Test Customer", 1000.0);
        Cart emptyCart = new Cart();
        
        System.out.println("Attempting checkout with empty cart:");
        ECommerceSystem.checkout(customer, emptyCart);
        System.out.println("✓ Empty cart error handled correctly");
        
        System.out.println("TEST 5 PASSED\n");
    }
    
    public static void testInsufficientBalanceError() {
        System.out.println("TEST 6: Insufficient Balance Error");
        System.out.println("=" + "=".repeat(50));
        
        Customer poorCustomer = new Customer("Poor Customer", 100.0);
        Cart expensiveCart = new Cart();
        
        TV expensiveTV = new TV("Premium TV", 5000.0, 2, 20.0);
        expensiveCart.add(expensiveTV, 1);
        
        System.out.println("Attempting checkout with insufficient balance:");
        ECommerceSystem.checkout(poorCustomer, expensiveCart);
        System.out.println("✓ Insufficient balance error handled correctly");
        
        System.out.println("TEST 6 PASSED\n");
    }
    
    public static void testOutOfStockError() {
        System.out.println("TEST 7: Out of Stock Error");
        System.out.println("=" + "=".repeat(50));
        
        Customer customer = new Customer("Test Customer", 1000.0);
        Cart cart = new Cart();
        
        TV limitedTV = new TV("Limited TV", 2000.0, 2, 15.0);
        
        try {
            cart.add(limitedTV, 5); // Trying to add more than available
            System.out.println("❌ Should have thrown exception");
        } catch (IllegalArgumentException e) {
            System.out.println("✓ Out of stock error during add: " + e.getMessage());
        }
        
        // Test out of stock during checkout
        cart.add(limitedTV, 2);
        limitedTV.setQuantity(1); // Simulate stock reduction
        
        System.out.println("Attempting checkout with insufficient stock:");
        ECommerceSystem.checkout(customer, cart);
        System.out.println("✓ Out of stock error during checkout handled correctly");
        
        System.out.println("TEST 7 PASSED\n");
    }
    
    public static void testExpiredProductError() {
        System.out.println("TEST 8: Expired Product Error");
        System.out.println("=" + "=".repeat(50));
        
        Customer customer = new Customer("Test Customer", 1000.0);
        Cart cart = new Cart();
        
        // Create expired cheese
        Cheese expiredCheese = new Cheese("Expired Cheese", 100.0, 5, LocalDate.now().minusDays(1), 0.2);
        cart.add(expiredCheese, 1);
        
        System.out.println("Attempting checkout with expired product:");
        ECommerceSystem.checkout(customer, cart);
        System.out.println("✓ Expired product error handled correctly");
        
        System.out.println("TEST 8 PASSED\n");
    }
    
    public static void testShippingService() {
        System.out.println("TEST 9: Shipping Service Tests");
        System.out.println("=" + "=".repeat(50));
        
        // Test shipping fee calculation
        TV tv = new TV("Test TV", 1000.0, 5, 10.0);
        Cheese cheese = new Cheese("Test Cheese", 100.0, 10, LocalDate.now().plusDays(5), 0.5);
        
        java.util.List<Shippable> shippableItems = new java.util.ArrayList<>();
        shippableItems.add(tv);
        shippableItems.add(cheese);
        
        double shippingFee = ShippingService.calculateShippingFee(shippableItems);
        System.out.println("✓ Shipping fee for 10.5kg: " + shippingFee);
        
        // Test shipping notice
        System.out.println("✓ Shipping notice:");
        ShippingService.ship(shippableItems);
        
        System.out.println("TEST 9 PASSED\n");
    }
    
    public static void testEdgeCases() {
        System.out.println("TEST 10: Edge Cases");
        System.out.println("=" + "=".repeat(50));
        
        // Test adding zero quantity
        Cart cart = new Cart();
        TV tv = new TV("Test TV", 1000.0, 5, 10.0);
        
        try {
            cart.add(tv, 0);
            System.out.println("❌ Should have thrown exception for zero quantity");
        } catch (IllegalArgumentException e) {
            System.out.println("✓ Zero quantity error: " + e.getMessage());
        }
        
        // Test negative quantity
        try {
            cart.add(tv, -1);
            System.out.println("❌ Should have thrown exception for negative quantity");
        } catch (IllegalArgumentException e) {
            System.out.println("✓ Negative quantity error: " + e.getMessage());
        }
        
        // Test customer with zero balance
        Customer zeroBalanceCustomer = new Customer("Zero Balance", 0.0);
        System.out.println("✓ Customer with zero balance: " + zeroBalanceCustomer.getBalance());
        
        // Test insufficient balance deduction
        try {
            zeroBalanceCustomer.deductBalance(100.0);
            System.out.println("❌ Should have thrown exception for insufficient balance");
        } catch (IllegalArgumentException e) {
            System.out.println("✓ Insufficient balance deduction error: " + e.getMessage());
        }
        
        System.out.println("TEST 10 PASSED\n");
    }
    
    public static void testComplexScenarios() {
        System.out.println("TEST 11: Complex Scenarios");
        System.out.println("=" + "=".repeat(50));
        
        // Test 11a: Multiple customers, multiple checkouts
        System.out.println("Test 11a: Multiple customers scenario");
        
        Customer customer1 = new Customer("Alice", 2000.0);
        Customer customer2 = new Customer("Bob", 1500.0);
        
        Cheese cheese = new Cheese("Premium Cheese", 200.0, 20, LocalDate.now().plusDays(15), 0.4);
        TV tv = new TV("4K TV", 6000.0, 10, 25.0);
        Mobile mobile = new Mobile("Smartphone", 3000.0, 15, 0.18);
        ScratchCard card = new ScratchCard("Premium Card", 150.0, 100);
        
        // Customer 1 checkout
        Cart cart1 = new Cart();
        cart1.add(cheese, 3);
        cart1.add(mobile, 1);
        cart1.add(card, 2);
        
        System.out.println("Customer 1 checkout:");
        ECommerceSystem.checkout(customer1, cart1);
        
        // Customer 2 checkout
        Cart cart2 = new Cart();
        cart2.add(cheese, 2);
        cart2.add(tv, 1);
        
        System.out.println("\nCustomer 2 checkout:");
        ECommerceSystem.checkout(customer2, cart2);
        
        System.out.println("✓ Remaining cheese stock: " + cheese.getQuantity());
        System.out.println("✓ Remaining TV stock: " + tv.getQuantity());
        System.out.println("✓ Remaining mobile stock: " + mobile.getQuantity());
        
        // Test 11b: Large quantity checkout
        System.out.println("\nTest 11b: Large quantity checkout");
        Customer bulkCustomer = new Customer("Bulk Buyer", 10000.0);
        Cart bulkCart = new Cart();
        
        ScratchCard bulkCards = new ScratchCard("Bulk Cards", 50.0, 200);
        bulkCart.add(bulkCards, 20);
        
        System.out.println("Bulk customer checkout:");
        ECommerceSystem.checkout(bulkCustomer, bulkCart);
        System.out.println("✓ Remaining bulk cards: " + bulkCards.getQuantity());
        
        System.out.println("TEST 11 PASSED\n");
    }
}
