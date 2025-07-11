#ifndef CART_H
#define CART_H

#include <vector>
#include "CartItem.h"
#include "Product.h"

class Cart {
private:
    std::vector<CartItem> items;

public:
    Cart();
    ~Cart() = default;

    void add(Product* product, int quantity);
    std::vector<CartItem> getItems() const;
    bool isEmpty() const;
    double getSubtotal() const;
    void clear();
};

#endif // CART_H
