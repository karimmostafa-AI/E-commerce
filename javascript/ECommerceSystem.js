// javascript/ECommerceSystem.js
import { Customer } from './Customer.js';
import { Cart } from './Cart.js';
import { ShippingService } from './ShippingService.js';
import { IShippable } from './Shippable.js';

export class ECommerceSystem {
    static checkout(customer, cart) {
        if (cart.isEmpty()) {
            console.log("Error: Cart is empty");
            return;
        }

        const shippableItems = [];
        for (const item of cart.getItems()) {
            const product = item.getProduct();

            if (product.isExpired()) {
                console.log(`Error: ${product.getName()} is expired`);
                return;
            }

            if (!product.isAvailable(item.getQuantity())) {
                console.log(`Error: ${product.getName()} is out of stock`);
                return;
            }

            if (product.requiresShipping()) {
                for (let i = 0; i < item.getQuantity(); i++) {
                    shippableItems.push(product);
                }
            }
        }

        const subtotal = cart.getSubtotal();
        const shippingFee = ShippingService.calculateShippingFee(shippableItems);
        const totalAmount = subtotal + shippingFee;

        if (!customer.hasBalance(totalAmount)) {
            console.log("Error: Customer's balance is insufficient");
            return;
        }

        customer.deductBalance(totalAmount);

        for (const item of cart.getItems()) {
            const product = item.getProduct();
            product.setQuantity(product.getQuantity() - item.getQuantity());
        }

        if (shippableItems.length > 0) {
            ShippingService.ship(shippableItems);
        }

        console.log("** Checkout receipt **");
        for (const item of cart.getItems()) {
            console.log(`${item.getQuantity()}x ${item.getProduct().getName()} ${Math.floor(item.getTotalPrice())}`);
        }
        console.log("----------------------");
        console.log(`Subtotal ${Math.floor(subtotal)}`);
        console.log(`Shipping ${Math.floor(shippingFee)}`);
        console.log(`Amount ${Math.floor(totalAmount)}`);
        console.log(`Customer balance after payment: ${customer.getBalance()}`);

        cart.clear();
    }
}
