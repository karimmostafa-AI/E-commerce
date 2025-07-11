// javascript/Product.js
export class Product {
    constructor(name, price, quantity) {
        if (this.constructor === Product) {
            throw new Error("Abstract classes can't be instantiated.");
        }
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    getName() {
        return this.name;
    }

    getPrice() {
        return this.price;
    }

    getQuantity() {
        return this.quantity;
    }

    setQuantity(quantity) {
        this.quantity = quantity;
    }

    isAvailable(requestedQuantity) {
        return this.quantity >= requestedQuantity;
    }

    isExpired() {
        throw new Error("Method 'isExpired()' must be implemented.");
    }

    requiresShipping() {
        throw new Error("Method 'requiresShipping()' must be implemented.");
    }
}
