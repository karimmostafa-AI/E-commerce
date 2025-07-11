#ifndef TV_H
#define TV_H

#include "ShippableProduct.h"

class TV : public ShippableProduct {
public:
    TV(std::string name, double price, int quantity, double weight);
    ~TV() = default;

    bool isExpired() const override;
};

#endif // TV_H
