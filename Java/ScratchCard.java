public class ScratchCard extends Product {
    
    public ScratchCard(String name, double price, int quantity) {
        super(name, price, quantity);
    }
    
    @Override
    public boolean isExpired() {
        return false; // Scratch cards don't expire
    }
    
    @Override
    public boolean requiresShipping() {
        return false; // Scratch cards don't require shipping
    }
}
