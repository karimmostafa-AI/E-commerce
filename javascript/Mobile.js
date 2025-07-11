// javascript/Mobile.js
import { ShippableProduct } from './ShippableProduct.js';

export class Mobile extends ShippableProduct {
    constructor(name, price, quantity, weight) {
        super(name, price, quantity, weight);
    }

    isExpired() {
        return false;
    }
}
