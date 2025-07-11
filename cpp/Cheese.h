#ifndef CHEESE_H
#define CHEESE_H

#include "ExpirableProduct.h"
#include "Shippable.h"

class Cheese : public ExpirableProduct, public IShippable {
private:
    double weight;
public:
    Cheese(std::string name, double price, int quantity, std::chrono::system_clock::time_point expiryDate, double weight);
    ~Cheese() = default;

    double getWeight() const override;
    bool requiresShipping() const override;
};

#endif // CHEESE_H
