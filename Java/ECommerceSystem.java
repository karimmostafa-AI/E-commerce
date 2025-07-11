import java.util.ArrayList;
import java.util.List;

public class ECommerceSystem {
    
    public static void checkout(Customer customer, Cart cart) {
        // Check if cart is empty
        if (cart.isEmpty()) {
            System.out.println("Error: Cart is empty");
            return;
        }
        
        // Check for expired products and stock availability
        List<Shippable> shippableItems = new ArrayList<>();
        
        for (CartItem item : cart.getItems()) {
            Product product = item.getProduct();
            
            // Check if product is expired
            if (product.isExpired()) {
                System.out.println("Error: " + product.getName() + " is expired");
                return;
            }
            
            // Check if product is out of stock
            if (!product.isAvailable(item.getQuantity())) {
                System.out.println("Error: " + product.getName() + " is out of stock");
                return;
            }
            
            // Collect shippable items
            if (product.requiresShipping() && product instanceof Shippable) {
                // Add multiple instances for quantity
                for (int i = 0; i < item.getQuantity(); i++) {
                    shippableItems.add((Shippable) product);
                }
            }
        }
        
        // Calculate costs
        double subtotal = cart.getSubtotal();
        double shippingFee = ShippingService.calculateShippingFee(shippableItems);
        double totalAmount = subtotal + shippingFee;
        
        // Check if customer has sufficient balance
        if (!customer.hasBalance(totalAmount)) {
            System.out.println("Error: Customer's balance is insufficient");
            return;
        }
        
        // Process payment
        customer.deductBalance(totalAmount);
        
        // Update product quantities
        for (CartItem item : cart.getItems()) {
            Product product = item.getProduct();
            product.setQuantity(product.getQuantity() - item.getQuantity());
        }
        
        // Send shipment notice
        if (!shippableItems.isEmpty()) {
            ShippingService.ship(shippableItems);
        }
        
        // Print checkout receipt
        System.out.println("** Checkout receipt **");
        for (CartItem item : cart.getItems()) {
            System.out.println(item.getQuantity() + "x " + item.getProduct().getName() + " " + (int)item.getTotalPrice());
        }
        System.out.println("----------------------");
        System.out.println("Subtotal " + (int)subtotal);
        System.out.println("Shipping " + (int)shippingFee);
        System.out.println("Amount " + (int)totalAmount);
        System.out.println("Customer balance after payment: " + customer.getBalance());
        
        // Clear cart
        cart.clear();
    }
}
