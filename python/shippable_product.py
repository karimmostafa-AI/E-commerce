from product import Product
from shippable import Shippable

class ShippableProduct(Product, Shippable):
    def __init__(self, name, price, quantity, weight):
        super().__init__(name, price, quantity)
        self.weight = weight
    
    def get_weight(self):
        return self.weight
    
    def requires_shipping(self):
        return True
