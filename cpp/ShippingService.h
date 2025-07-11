#ifndef SHIPPINGSERVICE_H
#define SHIPPINGSERVICE_H

#include <vector>
#include <memory>
#include "Shippable.h"

class ShippingService {
private:
    static constexpr double SHIPPING_RATE_PER_KG = 30.0; // 30 per kg

public:
    static void ship(const std::vector<IShippable*>& shippableItems);
    static double calculateShippingFee(const std::vector<IShippable*>& shippableItems);
};

#endif // SHIPPINGSERVICE_H
