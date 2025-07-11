// javascript/Cart.js
import { CartItem } from './CartItem.js';

export class Cart {
    constructor() {
        this.items = [];
    }

    add(product, quantity) {
        if (quantity <= 0) {
            throw new Error("Quantity must be positive");
        }

        if (!product.isAvailable(quantity)) {
            throw new Error(`Insufficient stock for ${product.getName()}`);
        }

        const existingItem = this.items.find(item => item.getProduct() === product);
        if (existingItem) {
            const newQuantity = existingItem.getQuantity() + quantity;
            if (!product.isAvailable(newQuantity)) {
                throw new Error(`Insufficient stock for ${product.getName()}`);
            }
            existingItem.setQuantity(newQuantity);
        } else {
            this.items.push(new CartItem(product, quantity));
        }
    }

    getItems() {
        return [...this.items];
    }

    isEmpty() {
        return this.items.length === 0;
    }

    getSubtotal() {
        return this.items.reduce((total, item) => total + item.getTotalPrice(), 0);
    }

    clear() {
        this.items = [];
    }
}
