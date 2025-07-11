#ifndef CARTITEM_H
#define CARTITEM_H

#include "Product.h"

class CartItem {
private:
    Product* product;
    int quantity;

public:
    CartItem(Product* product, int quantity);
    ~CartItem() = default;

    Product* getProduct() const;
    int getQuantity() const;
    double getTotalPrice() const;
    void setQuantity(int quantity);
};

#endif // CARTITEM_H
