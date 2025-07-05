import java.util.List;

public class ShippingService {
    private static final double SHIPPING_RATE_PER_KG = 30.0; // 30 per kg
    
    public static void ship(List<Shippable> shippableItems) {
        if (shippableItems.isEmpty()) {
            return;
        }
        
        System.out.println("** Shipment notice **");
        double totalWeight = 0.0;
        
        for (Shippable item : shippableItems) {
            System.out.println("1x " + item.getName() + " " + (int)(item.getWeight() * 1000) + "g");
            totalWeight += item.getWeight();
        }
        
        System.out.println("Total package weight " + totalWeight + "kg");
    }
    
    public static double calculateShippingFee(List<Shippable> shippableItems) {
        if (shippableItems.isEmpty()) {
            return 0.0;
        }
        
        double totalWeight = shippableItems.stream()
                .mapToDouble(Shippable::getWeight)
                .sum();
        
        return totalWeight * SHIPPING_RATE_PER_KG;
    }
}
