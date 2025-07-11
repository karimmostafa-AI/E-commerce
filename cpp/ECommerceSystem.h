#ifndef ECOMMERCESYSTEM_H
#define ECOMMERCESYSTEM_H

#include "Customer.h"
#include "Cart.h"

class ECommerceSystem {
public:
    static void checkout(Customer& customer, Cart& cart);
};

#endif // ECOMMERCESYSTEM_H
