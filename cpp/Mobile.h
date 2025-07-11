#ifndef MOBILE_H
#define MOBILE_H

#include "ShippableProduct.h"

class Mobile : public ShippableProduct {
public:
    Mobile(std::string name, double price, int quantity, double weight);
    ~Mobile() = default;

    bool isExpired() const override;
};

#endif // MOBILE_H
