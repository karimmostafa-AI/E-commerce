from cart_item import CartItem

class Cart:
    def __init__(self):
        self.items = []
    
    def add(self, product, quantity):
        if quantity <= 0:
            raise ValueError("Quantity must be positive")
        
        if not product.is_available(quantity):
            raise ValueError(f"Insufficient stock for {product.get_name()}")
        
        for item in self.items:
            if item.get_product() == product:
                new_quantity = item.get_quantity() + quantity
                if not product.is_available(new_quantity):
                    raise ValueError(f"Insufficient stock for {product.get_name()}")
                item.set_quantity(new_quantity)
                return
        
        self.items.append(CartItem(product, quantity))
    
    def get_items(self):
        return self.items.copy()
    
    def is_empty(self):
        return not self.items
    
    def get_subtotal(self):
        return sum(item.get_total_price() for item in self.items)
    
    def clear(self):
        self.items.clear()
