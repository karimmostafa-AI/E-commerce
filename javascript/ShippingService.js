// javascript/ShippingService.js
import { IShippable } from './Shippable.js';

export class ShippingService {
    static SHIPPING_RATE_PER_KG = 30.0;

    static ship(shippableItems) {
        if (shippableItems.length === 0) {
            return;
        }

        console.log("** Shipment notice **");
        let totalWeight = 0.0;

        for (const item of shippableItems) {
            console.log(`1x ${item.getName()} ${Math.floor(item.getWeight() * 1000)}g`);
            totalWeight += item.getWeight();
        }

        console.log(`Total package weight ${totalWeight}kg`);
    }

    static calculateShippingFee(shippableItems) {
        if (shippableItems.length === 0) {
            return 0.0;
        }

        const totalWeight = shippableItems.reduce((total, item) => total + item.getWeight(), 0);
        return totalWeight * ShippingService.SHIPPING_RATE_PER_KG;
    }
}
