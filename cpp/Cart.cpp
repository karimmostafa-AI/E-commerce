// cpp/Cart.cpp
#include "Cart.h"
#include <stdexcept>

Cart::Cart() {}

void Cart::add(Product* product, int quantity) {
    if (quantity <= 0) {
        throw std::invalid_argument("Quantity must be positive");
    }

    if (!product->isAvailable(quantity)) {
        throw std::invalid_argument("Insufficient stock for " + product->getName());
    }

    for (auto& item : items) {
        if (item.getProduct() == product) {
            int newQuantity = item.getQuantity() + quantity;
            if (!product->isAvailable(newQuantity)) {
                throw std::invalid_argument("Insufficient stock for " + product->getName());
            }
            item.setQuantity(newQuantity);
            return;
        }
    }

    items.emplace_back(product, quantity);
}

std::vector<CartItem> Cart::getItems() const {
    return items;
}

bool Cart::isEmpty() const {
    return items.empty();
}

double Cart::getSubtotal() const {
    double subtotal = 0.0;
    for (const auto& item : items) {
        subtotal += item.getTotalPrice();
    }
    return subtotal;
}

void Cart::clear() {
    items.clear();
}
