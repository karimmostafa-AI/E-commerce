from customer import Customer
from cart import Cart
from shipping_service import ShippingService
from shippable import Shippable

class ECommerceSystem:
    @staticmethod
    def checkout(customer, cart):
        if cart.is_empty():
            print("Error: Cart is empty")
            return

        shippable_items = []
        for item in cart.get_items():
            product = item.get_product()

            if product.is_expired():
                print(f"Error: {product.get_name()} is expired")
                return

            if not product.is_available(item.get_quantity()):
                print(f"Error: {product.get_name()} is out of stock")
                return

            if product.requires_shipping() and isinstance(product, Shippable):
                for _ in range(item.get_quantity()):
                    shippable_items.append(product)

        subtotal = cart.get_subtotal()
        shipping_fee = ShippingService.calculate_shipping_fee(shippable_items)
        total_amount = subtotal + shipping_fee

        if not customer.has_balance(total_amount):
            print("Error: Customer's balance is insufficient")
            return

        customer.deduct_balance(total_amount)

        for item in cart.get_items():
            product = item.get_product()
            product.set_quantity(product.get_quantity() - item.get_quantity())

        if shippable_items:
            ShippingService.ship(shippable_items)

        print("** Checkout receipt **")
        for item in cart.get_items():
            print(f"{item.get_quantity()}x {item.get_product().get_name()} {int(item.get_total_price())}")
        print("----------------------")
        print(f"Subtotal {int(subtotal)}")
        print(f"Shipping {int(shipping_fee)}")
        print(f"Amount {int(total_amount)}")
        print(f"Customer balance after payment: {customer.get_balance()}")

        cart.clear()
