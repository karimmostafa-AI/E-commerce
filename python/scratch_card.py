from product import Product

class ScratchCard(Product):
    def __init__(self, name, price, quantity):
        super().__init__(name, price, quantity)

    def is_expired(self):
        return False

    def requires_shipping(self):
        return False
