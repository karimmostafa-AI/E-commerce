#include "Cheese.h"

Cheese::Cheese(std::string name, double price, int quantity, std::chrono::system_clock::time_point expiryDate, double weight)
    : ExpirableProduct(name, price, quantity, expiryDate), weight(weight) {}

double Cheese::getWeight() const {
    return weight;
}

bool Cheese::requiresShipping() const {
    return true;
}
