#include "ScratchCard.h"

ScratchCard::ScratchCard(std::string name, double price, int quantity)
    : Product(name, price, quantity) {}

bool ScratchCard::isExpired() const {
    return false;
}

bool ScratchCard::requiresShipping() const {
    return false;
}
