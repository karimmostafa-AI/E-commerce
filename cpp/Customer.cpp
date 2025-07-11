#include "Customer.h"
#include <stdexcept>

Customer::Customer(std::string name, double balance)
    : name(name), balance(balance) {}

std::string Customer::getName() const {
    return name;
}

double Customer::getBalance() const {
    return balance;
}

void Customer::deductBalance(double amount) {
    if (amount > balance) {
        throw std::invalid_argument("Insufficient balance");
    }
    balance -= amount;
}

bool Customer::hasBalance(double amount) const {
    return balance >= amount;
}
