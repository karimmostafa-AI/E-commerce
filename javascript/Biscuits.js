// javascript/Biscuits.js
import { ExpirableProduct } from './ExpirableProduct.js';
import { IShippable } from './Shippable.js';

export class Biscuits extends ExpirableProduct {
    constructor(name, price, quantity, expiryDate, weight) {
        super(name, price, quantity, expiryDate);
        this.weight = weight;
    }

    getWeight() {
        return this.weight;
    }

    requiresShipping() {
        return true;
    }
}
