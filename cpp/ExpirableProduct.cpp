// cpp/ExpirableProduct.cpp
#include "ExpirableProduct.h"

ExpirableProduct::ExpirableProduct(std::string name, double price, int quantity, std::chrono::system_clock::time_point expiryDate)
    : Product(name, price, quantity), expiryDate(expiryDate) {}

std::chrono::system_clock::time_point ExpirableProduct::getExpiryDate() const {
    return expiryDate;
}

bool ExpirableProduct::isExpired() const {
    return std::chrono::system_clock::now() > expiryDate;
}
