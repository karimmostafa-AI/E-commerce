#ifndef CUSTOMER_H
#define CUSTOMER_H

#include <string>

class Customer {
private:
    std::string name;
    double balance;

public:
    Customer(std::string name, double balance);
    ~Customer() = default;

    std::string getName() const;
    double getBalance() const;
    void deductBalance(double amount);
    bool hasBalance(double amount) const;
};

#endif // CUSTOMER_H
