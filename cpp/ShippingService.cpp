#include "ShippingService.h"
#include <iostream>

void ShippingService::ship(const std::vector<IShippable*>& shippableItems) {
    if (shippableItems.empty()) {
        return;
    }

    std::cout << "** Shipment notice **" << std::endl;
    double totalWeight = 0.0;

    for (const auto& item : shippableItems) {
        std::cout << "1x " << item->getName() << " " << static_cast<int>(item->getWeight() * 1000) << "g" << std::endl;
        totalWeight += item->getWeight();
    }

    std::cout << "Total package weight " << totalWeight << "kg" << std::endl;
}

double ShippingService::calculateShippingFee(const std::vector<IShippable*>& shippableItems) {
    if (shippableItems.empty()) {
        return 0.0;
    }

    double totalWeight = 0.0;
    for (const auto& item : shippableItems) {
        totalWeight += item->getWeight();
    }

    return totalWeight * SHIPPING_RATE_PER_KG;
}
