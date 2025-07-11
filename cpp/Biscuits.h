#ifndef BISCUITS_H
#define BISCUITS_H

#include "ExpirableProduct.h"
#include "Shippable.h"

class Biscuits : public ExpirableProduct, public IShippable {
private:
    double weight;
public:
    Biscuits(std::string name, double price, int quantity, std::chrono::system_clock::time_point expiryDate, double weight);
    ~Biscuits() = default;

    double getWeight() const override;
    bool requiresShipping() const override;
};

#endif // BISCUITS_H
