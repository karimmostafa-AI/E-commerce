from datetime import date, timedelta
from cheese import Cheese
from biscuits import Biscuits
from tv import TV
from scratch_card import ScratchCard
from customer import Customer
from cart import Cart
from ecommerce_system import ECommerceSystem

def main():
    # Create products
    cheese = Cheese("Cheese", 100.0, 10, date.today() + timedelta(days=30), 0.2)  # 200g
    biscuits = Biscuits("Biscuits", 150.0, 5, date.today() + timedelta(days=60), 0.7)  # 700g
    tv = TV("TV", 5000.0, 3, 15.0)  # 15kg
    scratch_card = ScratchCard("Mobile Scratch Card", 50.0, 20)

    # Create customer with sufficient balance
    customer = Customer("John Doe", 1000.0)

    # Create cart
    cart = Cart()

    # Add products to cart (as per example)
    cart.add(cheese, 2)
    cart.add(biscuits, 1)
    cart.add(scratch_card, 1)

    # Checkout
    print("=== Example 1: Successful Checkout ===")
    ECommerceSystem.checkout(customer, cart)

    print("\n=== Example 2: Empty Cart ===")
    empty_cart = Cart()
    ECommerceSystem.checkout(customer, empty_cart)

    print("\n=== Example 3: Insufficient Balance ===")
    poor_customer = Customer("Jane Doe", 50.0)
    expensive_cart = Cart()
    expensive_cart.add(tv, 1)
    ECommerceSystem.checkout(poor_customer, expensive_cart)

    print("\n=== Example 4: Out of Stock ===")
    out_of_stock_cart = Cart()
    try:
        out_of_stock_cart.add(cheese, 15)  # Only 8 left after previous purchase
    except ValueError as e:
        print(f"Error: {e}")

    print("\n=== Example 5: Expired Product ===")
    expired_cheese = Cheese("Expired Cheese", 100.0, 5, date.today() - timedelta(days=1), 0.2)
    expired_cart = Cart()
    expired_cart.add(expired_cheese, 1)
    ECommerceSystem.checkout(customer, expired_cart)

    print("\n=== Example 6: Mixed Cart with Shipping ===")
    mixed_cart = Cart()
    mixed_cart.add(cheese, 1)
    mixed_cart.add(tv, 1)
    mixed_cart.add(scratch_card, 2)
    ECommerceSystem.checkout(customer, mixed_cart)

if __name__ == "__main__":
    main()
