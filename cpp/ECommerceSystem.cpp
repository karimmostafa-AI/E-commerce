#include "ECommerceSystem.h"
#include "ShippingService.h"
#include "Shippable.h"
#include <iostream>
#include <vector>

void ECommerceSystem::checkout(Customer& customer, Cart& cart) {
    // Check if cart is empty
    if (cart.isEmpty()) {
        std::cout << "Error: Cart is empty" << std::endl;
        return;
    }

    // Check for expired products and stock availability
    std::vector<IShippable*> shippableItems;

    for (const auto& item : cart.getItems()) {
        Product* product = item.getProduct();

        // Check if product is expired
        if (product->isExpired()) {
            std::cout << "Error: " << product->getName() << " is expired" << std::endl;
            return;
        }

        // Check if product is out of stock
        if (!product->isAvailable(item.getQuantity())) {
            std::cout << "Error: " << product->getName() << " is out of stock" << std::endl;
            return;
        }

        // Collect shippable items
        if (product->requiresShipping()) {
            // Try to cast to IShippable
            IShippable* shippable = dynamic_cast<IShippable*>(product);
            if (shippable) {
                // Add multiple instances for quantity
                for (int i = 0; i < item.getQuantity(); i++) {
                    shippableItems.push_back(shippable);
                }
            }
        }
    }

    // Calculate costs
    double subtotal = cart.getSubtotal();
    double shippingFee = ShippingService::calculateShippingFee(shippableItems);
    double totalAmount = subtotal + shippingFee;

    // Check if customer has sufficient balance
    if (!customer.hasBalance(totalAmount)) {
        std::cout << "Error: Customer's balance is insufficient" << std::endl;
        return;
    }

    // Process payment
    customer.deductBalance(totalAmount);

    // Update product quantities
    for (const auto& item : cart.getItems()) {
        Product* product = item.getProduct();
        product->setQuantity(product->getQuantity() - item.getQuantity());
    }

    // Send shipment notice
    if (!shippableItems.empty()) {
        ShippingService::ship(shippableItems);
    }

    // Print checkout receipt
    std::cout << "** Checkout receipt **" << std::endl;
    for (const auto& item : cart.getItems()) {
        std::cout << item.getQuantity() << "x " << item.getProduct()->getName() 
                  << " " << static_cast<int>(item.getTotalPrice()) << std::endl;
    }
    std::cout << "----------------------" << std::endl;
    std::cout << "Subtotal " << static_cast<int>(subtotal) << std::endl;
    std::cout << "Shipping " << static_cast<int>(shippingFee) << std::endl;
    std::cout << "Amount " << static_cast<int>(totalAmount) << std::endl;
    std::cout << "Customer balance after payment: " << customer.getBalance() << std::endl;

    // Clear cart
    cart.clear();
}
