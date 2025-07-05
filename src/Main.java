import java.time.LocalDate;

public class Main {
    public static void main(String[] args) {
        // Create products
        Cheese cheese = new Cheese("Cheese", 100.0, 10, LocalDate.now().plusDays(30), 0.2); // 200g
        Biscuits biscuits = new Biscuits("Biscuits", 150.0, 5, LocalDate.now().plusDays(60), 0.7); // 700g
        TV tv = new TV("TV", 5000.0, 3, 15.0); // 15kg
        ScratchCard scratchCard = new ScratchCard("Mobile Scratch Card", 50.0, 20);
        
        // Create customer with sufficient balance
        Customer customer = new Customer("John Doe", 1000.0);
        
        // Create cart
        Cart cart = new Cart();
        
        // Add products to cart (as per example)
        cart.add(cheese, 2);
        cart.add(biscuits, 1);
        cart.add(scratchCard, 1);
        
        // Checkout
        System.out.println("=== Example 1: Successful Checkout ===");
        ECommerceSystem.checkout(customer, cart);
        
        System.out.println("\n=== Example 2: Empty Cart ===");
        Cart emptyCart = new Cart();
        ECommerceSystem.checkout(customer, emptyCart);
        
        System.out.println("\n=== Example 3: Insufficient Balance ===");
        Customer poorCustomer = new Customer("Jane Doe", 50.0);
        Cart expensiveCart = new Cart();
        expensiveCart.add(tv, 1);
        ECommerceSystem.checkout(poorCustomer, expensiveCart);
        
        System.out.println("\n=== Example 4: Out of Stock ===");
        Cart outOfStockCart = new Cart();
        try {
            outOfStockCart.add(cheese, 15); // Only 8 left after previous purchase
        } catch (IllegalArgumentException e) {
            System.out.println("Error: " + e.getMessage());
        }
        
        System.out.println("\n=== Example 5: Expired Product ===");
        Cheese expiredCheese = new Cheese("Expired Cheese", 100.0, 5, LocalDate.now().minusDays(1), 0.2);
        Cart expiredCart = new Cart();
        expiredCart.add(expiredCheese, 1);
        ECommerceSystem.checkout(customer, expiredCart);
        
        System.out.println("\n=== Example 6: Mixed Cart with Shipping ===");
        Cart mixedCart = new Cart();
        mixedCart.add(cheese, 1);
        mixedCart.add(tv, 1);
        mixedCart.add(scratchCard, 2);
        ECommerceSystem.checkout(customer, mixedCart);
    }
}
