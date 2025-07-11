from abc import ABC, abstractmethod

class Product(ABC):
    def __init__(self, name, price, quantity):
        self.name = name
        self.price = price
        self.quantity = quantity
    
    def get_name(self):
        return self.name
    
    def get_price(self):
        return self.price
    
    def get_quantity(self):
        return self.quantity
    
    def set_quantity(self, quantity):
        self.quantity = quantity
    
    def is_available(self, requested_quantity):
        return self.quantity >= requested_quantity
    
    @abstractmethod
    def is_expired(self):
        pass
    
    @abstractmethod
    def requires_shipping(self):
        pass
