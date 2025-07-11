public class Mobile extends ShippableProduct {
    
    public Mobile(String name, double price, int quantity, double weight) {
        super(name, price, quantity, weight);
    }
    
    @Override
    public boolean isExpired() {
        return false; // Mobiles don't expire
    }
}
