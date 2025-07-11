// cpp/ExpirableProduct.h
#ifndef EXPIRABLEPRODUCT_H
#define EXPIRABLEPRODUCT_H

#include "Product.h"
#include <chrono>

class ExpirableProduct : public Product {
protected:
    std::chrono::system_clock::time_point expiryDate;

public:
    ExpirableProduct(std::string name, double price, int quantity, std::chrono::system_clock::time_point expiryDate);
    virtual ~ExpirableProduct() = default;

    std::chrono::system_clock::time_point getExpiryDate() const;
    bool isExpired() const override;
};

#endif // EXPIRABLEPRODUCT_H
