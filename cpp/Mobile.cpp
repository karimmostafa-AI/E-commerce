#include "Mobile.h"

Mobile::Mobile(std::string name, double price, int quantity, double weight)
    : ShippableProduct(name, price, quantity, weight) {}

bool Mobile::isExpired() const {
    return false;
}
