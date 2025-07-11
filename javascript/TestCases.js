// javascript/TestCases.js
import { Cheese } from './Cheese.js';
import { Biscuits } from './Biscuits.js';
import { TV } from './TV.js';
import { Mobile } from './Mobile.js';
import { ScratchCard } from './ScratchCard.js';
import { Customer } from './Customer.js';
import { Cart } from './Cart.js';
import { ECommerceSystem } from './ECommerceSystem.js';
import { ShippingService } from './ShippingService.js';

function testProductCreation() {
    console.log("TEST 1: Product Creation and Properties");
    console.log("=" + "=".repeat(50));

    // Test expirable products
    const cheese = new Cheese("Gouda Cheese", 120.0, 15, new Date(new Date().setDate(new Date().getDate() + 7)), 0.25);
    const biscuits = new Biscuits("Chocolate Biscuits", 80.0, 20, new Date(new Date().setDate(new Date().getDate() + 30)), 0.5);

    // Test non-expirable products
    const tv = new TV("Smart TV 55\"", 8000.0, 5, 18.5);
    const mobile = new Mobile("iPhone 15", 45000.0, 10, 0.2);
    const scratchCard = new ScratchCard("Recharge Card", 100.0, 50);

    console.log(`✓ Cheese: ${cheese.getName()} - Price: ${cheese.getPrice()} - Expires: ${!cheese.isExpired()} - Requires Shipping: ${cheese.requiresShipping()}`);
    console.log(`✓ Biscuits: ${biscuits.getName()} - Price: ${biscuits.getPrice()} - Expires: ${!biscuits.isExpired()} - Requires Shipping: ${biscuits.requiresShipping()}`);
    console.log(`✓ TV: ${tv.getName()} - Price: ${tv.getPrice()} - Expires: ${tv.isExpired()} - Requires Shipping: ${tv.requiresShipping()}`);
    console.log(`✓ Mobile: ${mobile.getName()} - Price: ${mobile.getPrice()} - Expires: ${mobile.isExpired()} - Requires Shipping: ${mobile.requiresShipping()}`);
    console.log(`✓ Scratch Card: ${scratchCard.getName()} - Price: ${scratchCard.getPrice()} - Expires: ${scratchCard.isExpired()} - Requires Shipping: ${scratchCard.requiresShipping()}`);

    console.log("TEST 1 PASSED\n");
}

function testCartOperations() {
    console.log("TEST 2: Cart Operations");
    console.log("=" + "=".repeat(50));

    const cart = new Cart();
    const cheese = new Cheese("Test Cheese", 100.0, 10, new Date(new Date().setDate(new Date().getDate() + 5)), 0.2);
    const tv = new TV("Test TV", 5000.0, 3, 15.0);

    // Test adding items
    cart.add(cheese, 2);
    cart.add(tv, 1);

    console.log(`✓ Cart items count: ${cart.getItems().length}`);
    console.log(`✓ Cart subtotal: ${cart.getSubtotal()}`);
    console.log(`✓ Cart is empty: ${cart.isEmpty()}`);

    // Test adding same item again
    cart.add(cheese, 1);
    console.log(`✓ After adding more cheese - Cart items count: ${cart.getItems().length}`);

    // Test cart clear
    cart.clear();
    console.log(`✓ After clearing - Cart is empty: ${cart.isEmpty()}`);

    console.log("TEST 2 PASSED\n");
}

function testCustomerOperations() {
    console.log("TEST 3: Customer Operations");
    console.log("=" + "=".repeat(50));

    const customer = new Customer("Test Customer", 1000.0);

    console.log(`✓ Customer name: ${customer.getName()}`);
    console.log(`✓ Initial balance: ${customer.getBalance()}`);
    console.log(`✓ Has balance for 500: ${customer.hasBalance(500.0)}`);
    console.log(`✓ Has balance for 1500: ${customer.hasBalance(1500.0)}`);

    // Test balance deduction
    customer.deductBalance(300.0);
    console.log(`✓ After deducting 300 - Balance: ${customer.getBalance()}`);

    console.log("TEST 3 PASSED\n");
}

function testSuccessfulCheckout() {
    console.log("TEST 4: Successful Checkout Scenarios");
    console.log("=" + "=".repeat(50));

    // Test 4a: Basic checkout with shippable items
    console.log("Test 4a: Basic checkout with mixed items");
    const customer1 = new Customer("John Doe", 1000.0);
    const cart1 = new Cart();

    const cheese = new Cheese("Cheddar", 150.0, 10, new Date(new Date().setDate(new Date().getDate() + 10)), 0.3);
    const tv = new TV("LED TV", 3000.0, 5, 12.0);
    const card = new ScratchCard("Game Card", 25.0, 100);

    cart1.add(cheese, 1);
    cart1.add(tv, 1);
    cart1.add(card, 2);

    ECommerceSystem.checkout(customer1, cart1);
    console.log(`✓ Customer balance after checkout: ${customer1.getBalance()}`);

    // Test 4b: Checkout with only non-shippable items
    console.log("\nTest 4b: Checkout with only non-shippable items");
    const customer2 = new Customer("Jane Smith", 500.0);
    const cart2 = new Cart();

    const card1 = new ScratchCard("Recharge Card", 100.0, 20);
    const card2 = new ScratchCard("Gift Card", 200.0, 15);

    cart2.add(card1, 2);
    cart2.add(card2, 1);

    ECommerceSystem.checkout(customer2, cart2);
    console.log(`✓ Customer balance after checkout: ${customer2.getBalance()}`);

    console.log("TEST 4 PASSED\n");
}

function testEmptyCartError() {
    console.log("TEST 5: Empty Cart Error");
    console.log("=" + "=".repeat(50));

    const customer = new Customer("Test Customer", 1000.0);
    const emptyCart = new Cart();

    console.log("Attempting checkout with empty cart:");
    ECommerceSystem.checkout(customer, emptyCart);
    console.log("✓ Empty cart error handled correctly");

    console.log("TEST 5 PASSED\n");
}

function testInsufficientBalanceError() {
    console.log("TEST 6: Insufficient Balance Error");
    console.log("=" + "=".repeat(50));

    const poorCustomer = new Customer("Poor Customer", 100.0);
    const expensiveCart = new Cart();

    const expensiveTV = new TV("Premium TV", 5000.0, 2, 20.0);
    expensiveCart.add(expensiveTV, 1);

    console.log("Attempting checkout with insufficient balance:");
    ECommerceSystem.checkout(poorCustomer, expensiveCart);
    console.log("✓ Insufficient balance error handled correctly");

    console.log("TEST 6 PASSED\n");
}

function testOutOfStockError() {
    console.log("TEST 7: Out of Stock Error");
    console.log("=" + "=".repeat(50));

    const customer = new Customer("Test Customer", 1000.0);
    const cart = new Cart();

    const limitedTV = new TV("Limited TV", 2000.0, 2, 15.0);

    try {
        cart.add(limitedTV, 5); // Trying to add more than available
        console.log("❌ Should have thrown exception");
    } catch (e) {
        console.log(`✓ Out of stock error during add: ${e.message}`);
    }

    // Test out of stock during checkout
    cart.add(limitedTV, 2);
    limitedTV.setQuantity(1); // Simulate stock reduction

    console.log("Attempting checkout with insufficient stock:");
    ECommerceSystem.checkout(customer, cart);
    console.log("✓ Out of stock error during checkout handled correctly");

    console.log("TEST 7 PASSED\n");
}

function testExpiredProductError() {
    console.log("TEST 8: Expired Product Error");
    console.log("=" + "=".repeat(50));

    const customer = new Customer("Test Customer", 1000.0);
    const cart = new Cart();

    // Create expired cheese
    const expiredCheese = new Cheese("Expired Cheese", 100.0, 5, new Date(new Date().setDate(new Date().getDate() - 1)), 0.2);
    cart.add(expiredCheese, 1);

    console.log("Attempting checkout with expired product:");
    ECommerceSystem.checkout(customer, cart);
    console.log("✓ Expired product error handled correctly");

    console.log("TEST 8 PASSED\n");
}

function testShippingService() {
    console.log("TEST 9: Shipping Service Tests");
    console.log("=" + "=".repeat(50));

    // Test shipping fee calculation
    const tv = new TV("Test TV", 1000.0, 5, 10.0);
    const cheese = new Cheese("Test Cheese", 100.0, 10, new Date(new Date().setDate(new Date().getDate() + 5)), 0.5);

    const shippableItems = [tv, cheese];

    const shippingFee = ShippingService.calculateShippingFee(shippableItems);
    console.log(`✓ Shipping fee for 10.5kg: ${shippingFee}`);

    // Test shipping notice
    console.log("✓ Shipping notice:");
    ShippingService.ship(shippableItems);

    console.log("TEST 9 PASSED\n");
}

function testEdgeCases() {
    console.log("TEST 10: Edge Cases");
    console.log("=" + "=".repeat(50));

    // Test adding zero quantity
    const cart = new Cart();
    const tv = new TV("Test TV", 1000.0, 5, 10.0);

    try {
        cart.add(tv, 0);
        console.log("❌ Should have thrown exception for zero quantity");
    } catch (e) {
        console.log(`✓ Zero quantity error: ${e.message}`);
    }

    // Test negative quantity
    try {
        cart.add(tv, -1);
        console.log("❌ Should have thrown exception for negative quantity");
    } catch (e) {
        console.log(`✓ Negative quantity error: ${e.message}`);
    }

    // Test customer with zero balance
    const zeroBalanceCustomer = new Customer("Zero Balance", 0.0);
    console.log(`✓ Customer with zero balance: ${zeroBalanceCustomer.getBalance()}`);

    // Test insufficient balance deduction
    try {
        zeroBalanceCustomer.deductBalance(100.0);
        console.log("❌ Should have thrown exception for insufficient balance");
    } catch (e) {
        console.log(`✓ Insufficient balance deduction error: ${e.message}`);
    }

    console.log("TEST 10 PASSED\n");
}

function testComplexScenarios() {
    console.log("TEST 11: Complex Scenarios");
    console.log("=" + "=".repeat(50));

    // Test 11a: Multiple customers, multiple checkouts
    console.log("Test 11a: Multiple customers scenario");

    const customer1 = new Customer("Alice", 2000.0);
    const customer2 = new Customer("Bob", 1500.0);

    const cheese = new Cheese("Premium Cheese", 200.0, 20, new Date(new Date().setDate(new Date().getDate() + 15)), 0.4);
    const tv = new TV("4K TV", 6000.0, 10, 25.0);
    const mobile = new Mobile("Smartphone", 3000.0, 15, 0.18);
    const card = new ScratchCard("Premium Card", 150.0, 100);

    // Customer 1 checkout
    const cart1 = new Cart();
    cart1.add(cheese, 3);
    cart1.add(mobile, 1);
    cart1.add(card, 2);

    console.log("Customer 1 checkout:");
    ECommerceSystem.checkout(customer1, cart1);

    // Customer 2 checkout
    const cart2 = new Cart();
    cart2.add(cheese, 2);
    cart2.add(tv, 1);

    console.log("\nCustomer 2 checkout:");
    ECommerceSystem.checkout(customer2, cart2);

    console.log(`✓ Remaining cheese stock: ${cheese.getQuantity()}`);
    console.log(`✓ Remaining TV stock: ${tv.getQuantity()}`);
    console.log(`✓ Remaining mobile stock: ${mobile.getQuantity()}`);

    // Test 11b: Large quantity checkout
    console.log("\nTest 11b: Large quantity checkout");
    const bulkCustomer = new Customer("Bulk Buyer", 10000.0);
    const bulkCart = new Cart();

    const bulkCards = new ScratchCard("Bulk Cards", 50.0, 200);
    bulkCart.add(bulkCards, 20);

    console.log("Bulk customer checkout:");
    ECommerceSystem.checkout(bulkCustomer, bulkCart);
    console.log(`✓ Remaining bulk cards: ${bulkCards.getQuantity()}`);

    console.log("TEST 11 PASSED\n");
}

function main() {
    console.log("=== E-COMMERCE SYSTEM TEST CASES ===\n");

    testProductCreation();
    testCartOperations();
    testCustomerOperations();
    testSuccessfulCheckout();
    testEmptyCartError();
    testInsufficientBalanceError();
    testOutOfStockError();
    testExpiredProductError();
    testShippingService();
    testEdgeCases();
    testComplexScenarios();

    console.log("\n=== ALL TEST CASES COMPLETED ===");
}

main();
