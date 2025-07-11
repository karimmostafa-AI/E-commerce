#include "TV.h"

TV::TV(std::string name, double price, int quantity, double weight)
    : ShippableProduct(name, price, quantity, weight) {}

bool TV::isExpired() const {
    return false;
}
