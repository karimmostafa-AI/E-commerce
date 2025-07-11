// javascript/ScratchCard.js
import { Product } from './Product.js';

export class ScratchCard extends Product {
    constructor(name, price, quantity) {
        super(name, price, quantity);
    }

    isExpired() {
        return false;
    }

    requiresShipping() {
        return false;
    }
}
