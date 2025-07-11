// javascript/ShippableProduct.js
import { Product } from './Product.js';
import { IShippable } from './Shippable.js';

export class ShippableProduct extends Product {
    constructor(name, price, quantity, weight) {
        super(name, price, quantity);
        if (this.constructor === ShippableProduct) {
            throw new Error("Abstract classes can't be instantiated.");
        }
        this.weight = weight;
    }

    getWeight() {
        return this.weight;
    }

    requiresShipping() {
        return true;
    }
}
