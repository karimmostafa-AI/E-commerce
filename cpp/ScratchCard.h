#ifndef SCRATCHCARD_H
#define SCRATCHCARD_H

#include "Product.h"

class ScratchCard : public Product {
public:
    ScratchCard(std::string name, double price, int quantity);
    ~ScratchCard() = default;

    bool isExpired() const override;
    bool requiresShipping() const override;
};

#endif // SCRATCHCARD_H
