// cpp/ShippableProduct.h
#ifndef SHIPPABLEPRODUCT_H
#define SHIPPABLEPRODUCT_H

#include "Product.h"
#include "Shippable.h"

class ShippableProduct : public Product, public IShippable {
protected:
    double weight;

public:
    ShippableProduct(std::string name, double price, int quantity, double weight);
    virtual ~ShippableProduct() = default;

    double getWeight() const override;
    bool requiresShipping() const override;
};

#endif // SHIPPABLEPRODUCT_H
