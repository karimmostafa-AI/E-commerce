#include <iostream>
#include <chrono>
#include <memory>
#include "ECommerceSystem.h"
#include "Customer.h"
#include "Cart.h"
#include "Cheese.h"
#include "Biscuits.h"
#include "TV.h"
#include "ScratchCard.h"
#include "Mobile.h"

// Helper function to create a date that's N days from now
std::chrono::system_clock::time_point daysFromNow(int days) {
    auto now = std::chrono::system_clock::now();
    return now + std::chrono::hours(24 * days);
}

int main() {
    try {
        // Create products
        auto cheese = std::make_unique<Cheese>("Cheese", 100.0, 10, daysFromNow(30), 0.2); // 200g
        auto biscuits = std::make_unique<Biscuits>("Biscuits", 150.0, 5, daysFromNow(60), 0.7); // 700g
        auto tv = std::make_unique<TV>("TV", 5000.0, 3, 15.0); // 15kg
        auto scratchCard = std::make_unique<ScratchCard>("Mobile Scratch Card", 50.0, 20);
        
        // Create customer with sufficient balance
        Customer customer("John Doe", 1000.0);
        
        // Create cart
        Cart cart;
        
        // Add products to cart (as per example)
        cart.add(cheese.get(), 2);
        cart.add(biscuits.get(), 1);
        cart.add(scratchCard.get(), 1);
        
        // Checkout
        std::cout << "=== Example 1: Successful Checkout ===" << std::endl;
        ECommerceSystem::checkout(customer, cart);
        
        std::cout << "\n=== Example 2: Empty Cart ===" << std::endl;
        Cart emptyCart;
        ECommerceSystem::checkout(customer, emptyCart);
        
        std::cout << "\n=== Example 3: Insufficient Balance ===" << std::endl;
        Customer poorCustomer("Jane Doe", 50.0);
        Cart expensiveCart;
        expensiveCart.add(tv.get(), 1);
        ECommerceSystem::checkout(poorCustomer, expensiveCart);
        
        std::cout << "\n=== Example 4: Out of Stock ===" << std::endl;
        Cart outOfStockCart;
        try {
            outOfStockCart.add(cheese.get(), 15); // Only 8 left after previous purchase
        } catch (const std::exception& e) {
            std::cout << "Error: " << e.what() << std::endl;
        }
        
        std::cout << "\n=== Example 5: Expired Product ===" << std::endl;
        auto expiredCheese = std::make_unique<Cheese>("Expired Cheese", 100.0, 5, daysFromNow(-1), 0.2);
        Cart expiredCart;
        expiredCart.add(expiredCheese.get(), 1);
        ECommerceSystem::checkout(customer, expiredCart);
        
        std::cout << "\n=== Example 6: Mixed Cart with Shipping ===" << std::endl;
        Cart mixedCart;
        mixedCart.add(cheese.get(), 1);
        mixedCart.add(tv.get(), 1);
        mixedCart.add(scratchCard.get(), 2);
        ECommerceSystem::checkout(customer, mixedCart);
        
    } catch (const std::exception& e) {
        std::cerr << "Exception occurred: " << e.what() << std::endl;
        return 1;
    }
    
    return 0;
}
