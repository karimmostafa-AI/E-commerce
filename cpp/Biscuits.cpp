#include "Biscuits.h"

Biscuits::Biscuits(std::string name, double price, int quantity, std::chrono::system_clock::time_point expiryDate, double weight)
    : ExpirableProduct(name, price, quantity, expiryDate), weight(weight) {}

double Biscuits::getWeight() const {
    return weight;
}

bool Biscuits::requiresShipping() const {
    return true;
}
