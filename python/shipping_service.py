class ShippingService:
    SHIPPING_RATE_PER_KG = 30.0

    @staticmethod
    def ship(shippable_items):
        if not shippable_items:
            return

        print("** Shipment notice **")
        total_weight = 0.0

        for item in shippable_items:
            print(f"1x {item.get_name()} {int(item.get_weight() * 1000)}g")
            total_weight += item.get_weight()

        print(f"Total package weight {total_weight}kg")

    @staticmethod
    def calculate_shipping_fee(shippable_items):
        if not shippable_items:
            return 0.0

        total_weight = sum(item.get_weight() for item in shippable_items)
        return total_weight * ShippingService.SHIPPING_RATE_PER_KG
