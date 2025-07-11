class Customer:
    def __init__(self, name, balance):
        self.name = name
        self.balance = balance
    
    def get_name(self):
        return self.name
    
    def get_balance(self):
        return self.balance
    
    def deduct_balance(self, amount):
        if amount > self.balance:
            raise ValueError("Insufficient balance")
        self.balance -= amount
    
    def has_balance(self, amount):
        return self.balance >= amount
