from datetime import date
from expirable_product import ExpirableProduct
from shippable import Shippable

class Cheese(ExpirableProduct, Shippable):
    def __init__(self, name, price, quantity, expiry_date, weight):
        super().__init__(name, price, quantity, expiry_date)
        self.weight = weight
    
    def get_weight(self):
        return self.weight
    
    def requires_shipping(self):
        return True
