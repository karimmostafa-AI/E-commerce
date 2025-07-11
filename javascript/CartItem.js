// javascript/CartItem.js
export class CartItem {
    constructor(product, quantity) {
        this.product = product;
        this.quantity = quantity;
    }

    getProduct() {
        return this.product;
    }

    getQuantity() {
        return this.quantity;
    }

    getTotalPrice() {
        return this.product.getPrice() * this.quantity;
    }

    setQuantity(quantity) {
        this.quantity = quantity;
    }
}
