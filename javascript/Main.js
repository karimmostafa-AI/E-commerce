// javascript/Main.js
import { Cheese } from './Cheese.js';
import { Biscuits } from './Biscuits.js';
import { TV } from './TV.js';
import { ScratchCard } from './ScratchCard.js';
import { Customer } from './Customer.js';
import { Cart } from './Cart.js';
import { ECommerceSystem } from './ECommerceSystem.js';

function main() {
    // Create products
    const cheese = new Cheese("Cheese", 100.0, 10, new Date(new Date().setDate(new Date().getDate() + 30)), 0.2); // 200g
    const biscuits = new Biscuits("Biscuits", 150.0, 5, new Date(new Date().setDate(new Date().getDate() + 60)), 0.7); // 700g
    const tv = new TV("TV", 5000.0, 3, 15.0); // 15kg
    const scratchCard = new ScratchCard("Mobile Scratch Card", 50.0, 20);

    // Create customer with sufficient balance
    const customer = new Customer("John Doe", 1000.0);

    // Create cart
    const cart = new Cart();

    // Add products to cart (as per example)
    cart.add(cheese, 2);
    cart.add(biscuits, 1);
    cart.add(scratchCard, 1);

    // Checkout
    console.log("=== Example 1: Successful Checkout ===");
    ECommerceSystem.checkout(customer, cart);

    console.log("\n=== Example 2: Empty Cart ===");
    const emptyCart = new Cart();
    ECommerceSystem.checkout(customer, emptyCart);

    console.log("\n=== Example 3: Insufficient Balance ===");
    const poorCustomer = new Customer("Jane Doe", 50.0);
    const expensiveCart = new Cart();
    expensiveCart.add(tv, 1);
    ECommerceSystem.checkout(poorCustomer, expensiveCart);

    console.log("\n=== Example 4: Out of Stock ===");
    const outOfStockCart = new Cart();
    try {
        outOfStockCart.add(cheese, 15); // Only 8 left after previous purchase
    } catch (e) {
        console.log("Error: " + e.message);
    }

    console.log("\n=== Example 5: Expired Product ===");
    const expiredCheese = new Cheese("Expired Cheese", 100.0, 5, new Date(new Date().setDate(new Date().getDate() - 1)), 0.2);
    const expiredCart = new Cart();
    expiredCart.add(expiredCheese, 1);
    ECommerceSystem.checkout(customer, expiredCart);

    console.log("\n=== Example 6: Mixed Cart with Shipping ===");
    const mixedCart = new Cart();
    mixedCart.add(cheese, 1);
    mixedCart.add(tv, 1);
    mixedCart.add(scratchCard, 2);
    ECommerceSystem.checkout(customer, mixedCart);
}

main();