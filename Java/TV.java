public class TV extends ShippableProduct {
    
    public TV(String name, double price, int quantity, double weight) {
        super(name, price, quantity, weight);
    }
    
    @Override
    public boolean isExpired() {
        return false; // TVs don't expire
    }
}
