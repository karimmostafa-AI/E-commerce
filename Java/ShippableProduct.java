public abstract class ShippableProduct extends Product implements Shippable {
    protected double weight;
    
    public ShippableProduct(String name, double price, int quantity, double weight) {
        super(name, price, quantity);
        this.weight = weight;
    }
    
    @Override
    public double getWeight() {
        return weight;
    }
    
    @Override
    public boolean requiresShipping() {
        return true;
    }
}
