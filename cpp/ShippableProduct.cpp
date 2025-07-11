// cpp/ShippableProduct.cpp
#include "ShippableProduct.h"

ShippableProduct::ShippableProduct(std::string name, double price, int quantity, double weight)
    : Product(name, price, quantity), weight(weight) {}

double ShippableProduct::getWeight() const {
    return weight;
}

bool ShippableProduct::requiresShipping() const {
    return true;
}
