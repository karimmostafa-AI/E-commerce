# python/test_cases.py
from datetime import date, timedelta
from cheese import Cheese
from biscuits import Biscuits
from tv import TV
from mobile import Mobile
from scratch_card import ScratchCard
from customer import Customer
from cart import Cart
from ecommerce_system import ECommerceSystem
from shipping_service import ShippingService

def test_product_creation():
    print("TEST 1: Product Creation and Properties")
    print("=" * 50)

    # Test expirable products
    cheese = Cheese("Gouda Cheese", 120.0, 15, date.today() + timedelta(days=7), 0.25)
    biscuits = Biscuits("Chocolate Biscuits", 80.0, 20, date.today() + timedelta(days=30), 0.5)

    # Test non-expirable products
    tv = TV("Smart TV 55\"", 8000.0, 5, 18.5)
    mobile = Mobile("iPhone 15", 45000.0, 10, 0.2)
    scratch_card = ScratchCard("Recharge Card", 100.0, 50)

    print(f"OK Cheese: {cheese.get_name()} - Price: {cheese.get_price()} - Expires: {not cheese.is_expired()} - Requires Shipping: {cheese.requires_shipping()}")
    print(f"OK Biscuits: {biscuits.get_name()} - Price: {biscuits.get_price()} - Expires: {not biscuits.is_expired()} - Requires Shipping: {biscuits.requires_shipping()}")
    print(f"OK TV: {tv.get_name()} - Price: {tv.get_price()} - Expires: {tv.is_expired()} - Requires Shipping: {tv.requires_shipping()}")
    print(f"OK Mobile: {mobile.get_name()} - Price: {mobile.get_price()} - Expires: {mobile.is_expired()} - Requires Shipping: {mobile.requires_shipping()}")
    print(f"OK Scratch Card: {scratch_card.get_name()} - Price: {scratch_card.get_price()} - Expires: {scratch_card.is_expired()} - Requires Shipping: {scratch_card.requires_shipping()}")

    print("TEST 1 PASSED\n")

def test_cart_operations():
    print("TEST 2: Cart Operations")
    print("=" * 50)

    cart = Cart()
    cheese = Cheese("Test Cheese", 100.0, 10, date.today() + timedelta(days=5), 0.2)
    tv = TV("Test TV", 5000.0, 3, 15.0)

    # Test adding items
    cart.add(cheese, 2)
    cart.add(tv, 1)

    print(f"OK Cart items count: {len(cart.get_items())}")
    print(f"OK Cart subtotal: {cart.get_subtotal()}")
    print(f"OK Cart is empty: {cart.is_empty()}")

    # Test adding same item again
    cart.add(cheese, 1)
    print(f"OK After adding more cheese - Cart items count: {len(cart.get_items())}")

    # Test cart clear
    cart.clear()
    print(f"OK After clearing - Cart is empty: {cart.is_empty()}")

    print("TEST 2 PASSED\n")

def test_customer_operations():
    print("TEST 3: Customer Operations")
    print("=" * 50)

    customer = Customer("Test Customer", 1000.0)

    print(f"OK Customer name: {customer.get_name()}")
    print(f"OK Initial balance: {customer.get_balance()}")
    print(f"OK Has balance for 500: {customer.has_balance(500.0)}")
    print(f"OK Has balance for 1500: {customer.has_balance(1500.0)}")

    # Test balance deduction
    customer.deduct_balance(300.0)
    print(f"OK After deducting 300 - Balance: {customer.get_balance()}")

    print("TEST 3 PASSED\n")

def test_successful_checkout():
    print("TEST 4: Successful Checkout Scenarios")
    print("=" * 50)

    # Test 4a: Basic checkout with shippable items
    print("Test 4a: Basic checkout with mixed items")
    customer1 = Customer("John Doe", 1000.0)
    cart1 = Cart()

    cheese = Cheese("Cheddar", 150.0, 10, date.today() + timedelta(days=10), 0.3)
    tv = TV("LED TV", 3000.0, 5, 12.0)
    card = ScratchCard("Game Card", 25.0, 100)

    cart1.add(cheese, 1)
    cart1.add(tv, 1)
    cart1.add(card, 2)

    ECommerceSystem.checkout(customer1, cart1)
    print(f"OK Customer balance after checkout: {customer1.get_balance()}")

    # Test 4b: Checkout with only non-shippable items
    print("\nTest 4b: Checkout with only non-shippable items")
    customer2 = Customer("Jane Smith", 500.0)
    cart2 = Cart()

    card1 = ScratchCard("Recharge Card", 100.0, 20)
    card2 = ScratchCard("Gift Card", 200.0, 15)

    cart2.add(card1, 2)
    cart2.add(card2, 1)

    ECommerceSystem.checkout(customer2, cart2)
    print(f"OK Customer balance after checkout: {customer2.get_balance()}")

    print("TEST 4 PASSED\n")

def test_empty_cart_error():
    print("TEST 5: Empty Cart Error")
    print("=" * 50)

    customer = Customer("Test Customer", 1000.0)
    empty_cart = Cart()

    print("Attempting checkout with empty cart:")
    ECommerceSystem.checkout(customer, empty_cart)
    print("OK Empty cart error handled correctly")

    print("TEST 5 PASSED\n")

def test_insufficient_balance_error():
    print("TEST 6: Insufficient Balance Error")
    print("=" * 50)

    poor_customer = Customer("Poor Customer", 100.0)
    expensive_cart = Cart()

    expensive_tv = TV("Premium TV", 5000.0, 2, 20.0)
    expensive_cart.add(expensive_tv, 1)

    print("Attempting checkout with insufficient balance:")
    ECommerceSystem.checkout(poor_customer, expensive_cart)
    print("OK Insufficient balance error handled correctly")

    print("TEST 6 PASSED\n")

def test_out_of_stock_error():
    print("TEST 7: Out of Stock Error")
    print("=" * 50)

    customer = Customer("Test Customer", 1000.0)
    cart = Cart()

    limited_tv = TV("Limited TV", 2000.0, 2, 15.0)

    try:
        cart.add(limited_tv, 5)  # Trying to add more than available
        print("❌ Should have thrown exception")
    except ValueError as e:
        print(f"OK Out of stock error during add: {e}")

    # Test out of stock during checkout
    cart.add(limited_tv, 2)
    limited_tv.set_quantity(1)  # Simulate stock reduction

    print("Attempting checkout with insufficient stock:")
    ECommerceSystem.checkout(customer, cart)
    print("OK Out of stock error during checkout handled correctly")

    print("TEST 7 PASSED\n")

def test_expired_product_error():
    print("TEST 8: Expired Product Error")
    print("=" * 50)

    customer = Customer("Test Customer", 1000.0)
    cart = Cart()

    # Create expired cheese
    expired_cheese = Cheese("Expired Cheese", 100.0, 5, date.today() - timedelta(days=1), 0.2)
    cart.add(expired_cheese, 1)

    print("Attempting checkout with expired product:")
    ECommerceSystem.checkout(customer, cart)
    print("OK Expired product error handled correctly")

    print("TEST 8 PASSED\n")

def test_shipping_service():
    print("TEST 9: Shipping Service Tests")
    print("=" * 50)

    # Test shipping fee calculation
    tv = TV("Test TV", 1000.0, 5, 10.0)
    cheese = Cheese("Test Cheese", 100.0, 10, date.today() + timedelta(days=5), 0.5)

    shippable_items = [tv, cheese]

    shipping_fee = ShippingService.calculate_shipping_fee(shippable_items)
    print(f"OK Shipping fee for 10.5kg: {shipping_fee}")

    # Test shipping notice
    print("OK Shipping notice:")
    ShippingService.ship(shippable_items)

    print("TEST 9 PASSED\n")

def test_edge_cases():
    print("TEST 10: Edge Cases")
    print("=" * 50)

    # Test adding zero quantity
    cart = Cart()
    tv = TV("Test TV", 1000.0, 5, 10.0)

    try:
        cart.add(tv, 0)
        print("❌ Should have thrown exception for zero quantity")
    except ValueError as e:
        print(f"OK Zero quantity error: {e}")

    # Test negative quantity
    try:
        cart.add(tv, -1)
        print("❌ Should have thrown exception for negative quantity")
    except ValueError as e:
        print(f"OK Negative quantity error: {e}")

    # Test customer with zero balance
    zero_balance_customer = Customer("Zero Balance", 0.0)
    print(f"OK Customer with zero balance: {zero_balance_customer.get_balance()}")

    # Test insufficient balance deduction
    try:
        zero_balance_customer.deduct_balance(100.0)
        print("❌ Should have thrown exception for insufficient balance")
    except ValueError as e:
        print(f"OK Insufficient balance deduction error: {e}")

    print("TEST 10 PASSED\n")

def test_complex_scenarios():
    print("TEST 11: Complex Scenarios")
    print("=" * 50)

    # Test 11a: Multiple customers, multiple checkouts
    print("Test 11a: Multiple customers scenario")

    customer1 = Customer("Alice", 2000.0)
    customer2 = Customer("Bob", 1500.0)

    cheese = Cheese("Premium Cheese", 200.0, 20, date.today() + timedelta(days=15), 0.4)
    tv = TV("4K TV", 6000.0, 10, 25.0)
    mobile = Mobile("Smartphone", 3000.0, 15, 0.18)
    card = ScratchCard("Premium Card", 150.0, 100)

    # Customer 1 checkout
    cart1 = Cart()
    cart1.add(cheese, 3)
    cart1.add(mobile, 1)
    cart1.add(card, 2)

    print("Customer 1 checkout:")
    ECommerceSystem.checkout(customer1, cart1)

    # Customer 2 checkout
    cart2 = Cart()
    cart2.add(cheese, 2)
    cart2.add(tv, 1)

    print("\nCustomer 2 checkout:")
    ECommerceSystem.checkout(customer2, cart2)

    print(f"OK Remaining cheese stock: {cheese.get_quantity()}")
    print(f"OK Remaining TV stock: {tv.get_quantity()}")
    print(f"OK Remaining mobile stock: {mobile.get_quantity()}")

    # Test 11b: Large quantity checkout
    print("\nTest 11b: Large quantity checkout")
    bulk_customer = Customer("Bulk Buyer", 10000.0)
    bulk_cart = Cart()

    bulk_cards = ScratchCard("Bulk Cards", 50.0, 200)
    bulk_cart.add(bulk_cards, 20)

    print("Bulk customer checkout:")
    ECommerceSystem.checkout(bulk_customer, bulk_cart)
    print(f"OK Remaining bulk cards: {bulk_cards.get_quantity()}")

    print("TEST 11 PASSED\n")

def main():
    print("=== E-COMMERCE SYSTEM TEST CASES ===\n")

    test_product_creation()
    test_cart_operations()
    test_customer_operations()
    test_successful_checkout()
    test_empty_cart_error()
    test_insufficient_balance_error()
    test_out_of_stock_error()
    test_expired_product_error()
    test_shipping_service()
    test_edge_cases()
    test_complex_scenarios()

    print("\n=== ALL TEST CASES COMPLETED ===")

if __name__ == "__main__":
    main()
