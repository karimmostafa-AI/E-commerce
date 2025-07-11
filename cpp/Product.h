// cpp/Product.h
#ifndef PRODUCT_H
#define PRODUCT_H

#include <string>
#include <chrono>

class Product {
protected:
    std::string name;
    double price;
    int quantity;

public:
    Product(std::string name, double price, int quantity);
    virtual ~Product() = default;

    std::string getName() const;
    double getPrice() const;
    int getQuantity() const;
    void setQuantity(int quantity);
    bool isAvailable(int requestedQuantity) const;

    virtual bool isExpired() const = 0;
    virtual bool requiresShipping() const = 0;
};

#endif // PRODUCT_H
