// javascript/ExpirableProduct.js
import { Product } from './Product.js';

export class ExpirableProduct extends Product {
    constructor(name, price, quantity, expiryDate) {
        super(name, price, quantity);
        if (this.constructor === ExpirableProduct) {
            throw new Error("Abstract classes can't be instantiated.");
        }
        this.expiryDate = expiryDate;
    }

    getExpiryDate() {
        return this.expiryDate;
    }

    isExpired() {
        return new Date() > this.expiryDate;
    }
}
