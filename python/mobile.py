from shippable_product import ShippableProduct

class Mobile(ShippableProduct):
    def __init__(self, name, price, quantity, weight):
        super().__init__(name, price, quantity, weight)

    def is_expired(self):
        return False
