# E-Commerce System Documentation

## Table of Contents
1. [Project Overview](#project-overview)
2. [Language Implementations](#language-implementations)
3. [System Architecture](#system-architecture)
4. [Class Documentation](#class-documentation)
5. [Interface Documentation](#interface-documentation)
6. [Test Cases Documentation](#test-cases-documentation)
7. [How to Run](#how-to-run)
8. [Usage Examples](#usage-examples)
9. [Design Patterns](#design-patterns)
10. [Error Handling](#error-handling)
11. [Assumptions](#assumptions)

---

## Project Overview

This E-Commerce System is a comprehensive multi-language implementation of a complete shopping cart and checkout system. The system supports different types of products with varying characteristics such as expiration dates and shipping requirements. The same business logic and architecture are implemented across **five different programming languages** to demonstrate design patterns and object-oriented principles in various contexts.

### Key Features
- **Product Management**: Handles different product types (expirable/non-expirable, shippable/non-shippable)
- **Shopping Cart**: Add/remove products with quantity validation
- **Customer Management**: Balance tracking and payment processing
- **Checkout System**: Complete order processing with validation
- **Shipping Service**: Weight-based shipping calculation and notifications
- **Error Handling**: Comprehensive validation for all business rules

---

## System Architecture

```
E-Commerce System
├── Core Interfaces
│   └── Shippable
├── Abstract Classes
│   ├── Product
│   ├── ExpirableProduct
│   └── ShippableProduct
├── Concrete Products
│   ├── Cheese
│   ├── Biscuits
│   ├── TV
│   ├── Mobile
│   └── ScratchCard
├── System Classes
│   ├── Cart
│   ├── CartItem
│   ├── Customer
│   ├── ECommerceSystem
│   └── ShippingService
└── Test Classes
    ├── Main
    └── TestCases
```

---

## Class Documentation

### Interface: `Shippable`

**Purpose**: Defines the contract for products that require shipping.

#### Methods:
- `String getName()`: Returns the name of the shippable item
- `double getWeight()`: Returns the weight of the item in kilograms

**Implementation**: Used by products that require physical shipping

---

### Abstract Class: `Product`

**Purpose**: Base class for all products in the system.

#### Attributes:
- `String name`: Product name
- `double price`: Product price
- `int quantity`: Available quantity in stock

#### Methods:
- `Product(String name, double price, int quantity)`: Constructor
- `String getName()`: Returns product name
- `double getPrice()`: Returns product price
- `int getQuantity()`: Returns available quantity
- `void setQuantity(int quantity)`: Updates product quantity
- `boolean isAvailable(int requestedQuantity)`: Checks if requested quantity is available
- `abstract boolean isExpired()`: Must be implemented by subclasses
- `abstract boolean requiresShipping()`: Must be implemented by subclasses

**Design**: Template Method pattern - defines common behavior while leaving specific implementations to subclasses

---

### Abstract Class: `ExpirableProduct`

**Purpose**: Extends Product for items that can expire.

#### Attributes:
- `LocalDate expiryDate`: Product expiration date

#### Methods:
- `ExpirableProduct(String name, double price, int quantity, LocalDate expiryDate)`: Constructor
- `LocalDate getExpiryDate()`: Returns expiry date
- `boolean isExpired()`: Returns true if product is past expiry date

**Usage**: Base class for perishable goods like Cheese and Biscuits

---

### Abstract Class: `ShippableProduct`

**Purpose**: Extends Product for items that require shipping and implements Shippable.

#### Attributes:
- `double weight`: Product weight in kilograms

#### Methods:
- `ShippableProduct(String name, double price, int quantity, double weight)`: Constructor
- `double getWeight()`: Returns product weight
- `boolean requiresShipping()`: Always returns true

**Usage**: Base class for physical products that need shipping

---

### Concrete Class: `Cheese`

**Purpose**: Represents cheese products that expire and require shipping.

#### Inheritance:
- Extends: `ExpirableProduct`
- Implements: `Shippable`

#### Attributes:
- Inherits all from `ExpirableProduct`
- `double weight`: Weight for shipping

#### Methods:
- `Cheese(String name, double price, int quantity, LocalDate expiryDate, double weight)`: Constructor
- `double getWeight()`: Returns weight for shipping
- `boolean requiresShipping()`: Returns true

**Example Usage**:
```java
Cheese gouda = new Cheese("Gouda Cheese", 150.0, 10, LocalDate.now().plusDays(7), 0.25);
```

---

### Concrete Class: `Biscuits`

**Purpose**: Represents biscuit products that expire and require shipping.

#### Inheritance:
- Extends: `ExpirableProduct`
- Implements: `Shippable`

#### Attributes:
- Inherits all from `ExpirableProduct`
- `double weight`: Weight for shipping

#### Methods:
- `Biscuits(String name, double price, int quantity, LocalDate expiryDate, double weight)`: Constructor
- `double getWeight()`: Returns weight for shipping
- `boolean requiresShipping()`: Returns true

**Example Usage**:
```java
Biscuits cookies = new Biscuits("Chocolate Cookies", 80.0, 20, LocalDate.now().plusDays(30), 0.5);
```

---

### Concrete Class: `TV`

**Purpose**: Represents television products that don't expire but require shipping.

#### Inheritance:
- Extends: `ShippableProduct`

#### Methods:
- `TV(String name, double price, int quantity, double weight)`: Constructor
- `boolean isExpired()`: Always returns false (TVs don't expire)

**Example Usage**:
```java
TV smartTV = new TV("Smart TV 55\"", 8000.0, 5, 18.5);
```

---

### Concrete Class: `Mobile`

**Purpose**: Represents mobile phone products that don't expire but require shipping.

#### Inheritance:
- Extends: `ShippableProduct`

#### Methods:
- `Mobile(String name, double price, int quantity, double weight)`: Constructor
- `boolean isExpired()`: Always returns false (Mobiles don't expire)

**Example Usage**:
```java
Mobile iPhone = new Mobile("iPhone 15", 45000.0, 10, 0.2);
```

---

### Concrete Class: `ScratchCard`

**Purpose**: Represents digital scratch cards that don't expire and don't require shipping.

#### Inheritance:
- Extends: `Product`

#### Methods:
- `ScratchCard(String name, double price, int quantity)`: Constructor
- `boolean isExpired()`: Always returns false
- `boolean requiresShipping()`: Always returns false (digital product)

**Example Usage**:
```java
ScratchCard rechargeCard = new ScratchCard("Mobile Recharge", 100.0, 50);
```

---

### Class: `CartItem`

**Purpose**: Represents an item in the shopping cart with its quantity.

#### Attributes:
- `Product product`: The product reference
- `int quantity`: Quantity of this product in cart

#### Methods:
- `CartItem(Product product, int quantity)`: Constructor
- `Product getProduct()`: Returns the product
- `int getQuantity()`: Returns quantity
- `double getTotalPrice()`: Calculates total price (product price × quantity)
- `void setQuantity(int quantity)`: Updates quantity

**Design**: Value object that pairs a product with its cart quantity

---

### Class: `Cart`

**Purpose**: Manages the shopping cart functionality.

#### Attributes:
- `List<CartItem> items`: List of items in the cart

#### Methods:
- `Cart()`: Constructor (initializes empty cart)
- `void add(Product product, int quantity)`: Adds product to cart with validation
- `List<CartItem> getItems()`: Returns copy of cart items
- `boolean isEmpty()`: Checks if cart is empty
- `double getSubtotal()`: Calculates total price of all items
- `void clear()`: Removes all items from cart

#### Validation Rules:
- Quantity must be positive
- Product must have sufficient stock
- If product already exists in cart, quantities are combined

**Example Usage**:
```java
Cart cart = new Cart();
cart.add(cheese, 2);
cart.add(tv, 1);
double total = cart.getSubtotal();
```

---

### Class: `Customer`

**Purpose**: Represents a customer with balance management.

#### Attributes:
- `String name`: Customer name
- `double balance`: Customer's account balance

#### Methods:
- `Customer(String name, double balance)`: Constructor
- `String getName()`: Returns customer name
- `double getBalance()`: Returns current balance
- `void deductBalance(double amount)`: Deducts amount from balance with validation
- `boolean hasBalance(double amount)`: Checks if customer has sufficient balance

#### Validation Rules:
- Cannot deduct more than available balance
- Balance cannot go negative

**Example Usage**:
```java
Customer customer = new Customer("John Doe", 1000.0);
if (customer.hasBalance(500.0)) {
    customer.deductBalance(500.0);
}
```

---

### Class: `ShippingService`

**Purpose**: Handles shipping calculations and notifications.

#### Constants:
- `SHIPPING_RATE_PER_KG = 30.0`: Shipping cost per kilogram

#### Methods:
- `static void ship(List<Shippable> shippableItems)`: Prints shipping notice
- `static double calculateShippingFee(List<Shippable> shippableItems)`: Calculates shipping cost

#### Business Logic:
- Shipping fee = total weight × rate per kg
- No shipping fee for empty lists
- Prints detailed shipment notice with item weights

**Example Output**:
```
** Shipment notice **
2x Cheese 400g
1x TV 15000g
Total package weight 15.4kg
```

---

### Class: `ECommerceSystem`

**Purpose**: Main system class that orchestrates the checkout process.

#### Methods:
- `static void checkout(Customer customer, Cart cart)`: Processes complete checkout

#### Checkout Process:
1. **Validation Phase**:
   - Check if cart is empty
   - Validate all products are not expired
   - Verify sufficient stock for all items
   
2. **Calculation Phase**:
   - Calculate subtotal
   - Collect shippable items
   - Calculate shipping fees
   - Calculate total amount

3. **Payment Phase**:
   - Verify customer has sufficient balance
   - Deduct payment from customer balance
   - Update product quantities

4. **Fulfillment Phase**:
   - Send shipment notice (if applicable)
   - Print checkout receipt
   - Clear cart

#### Error Conditions:
- Empty cart
- Expired products
- Out of stock items
- Insufficient customer balance

**Example Output**:
```
** Checkout receipt **
2x Cheese 200
1x TV 5000
----------------------
Subtotal 5200
Shipping 45
Amount 5245
Customer balance after payment: 755.0
```

---

## Interface Documentation

### Shippable Interface

The `Shippable` interface is a crucial design element that enables the shipping service to handle different types of products uniformly.

#### Design Benefits:
- **Polymorphism**: Allows ShippingService to work with any shippable product
- **Extensibility**: New shippable products can be added easily
- **Separation of Concerns**: Shipping logic is decoupled from product types

#### Implementation Strategy:
- Products that require shipping implement this interface
- ShippingService accepts List<Shippable> for flexibility
- Interface provides only essential shipping-related methods

---

## Test Cases Documentation

### TestCases Class Overview

The `TestCases` class provides comprehensive testing coverage for all system functionality.

### Test 1: Product Creation and Properties
**Purpose**: Validates proper instantiation and behavior of all product types.

**Coverage**:
- Product creation with valid parameters
- Expiration logic for expirable products
- Shipping requirements validation
- Price and quantity management

**Assertions**:
- Cheese and Biscuits expire (when not past expiry date)
- TV and Mobile don't expire
- ScratchCard doesn't require shipping
- All shippable products return correct weights

---

### Test 2: Cart Operations
**Purpose**: Tests shopping cart functionality and edge cases.

**Coverage**:
- Adding single items
- Adding multiple quantities
- Adding same item multiple times (quantity aggregation)
- Cart subtotal calculation
- Cart clearing functionality

**Scenarios**:
- Empty cart state
- Mixed product types in cart
- Quantity validation

---

### Test 3: Customer Operations
**Purpose**: Validates customer balance management.

**Coverage**:
- Customer creation
- Balance inquiry
- Balance deduction with validation
- Insufficient balance handling

**Edge Cases**:
- Zero balance customers
- Negative deduction attempts
- Exact balance scenarios

---

### Test 4: Successful Checkout Scenarios
**Purpose**: Tests complete successful checkout workflows.

**Scenarios**:
- Mixed cart with shippable and non-shippable items
- Cart with only non-shippable items
- Balance deduction verification
- Receipt generation

**Validation**:
- Correct total calculation
- Proper shipping fee application
- Customer balance updates
- Cart clearing after checkout

---

### Test 5: Empty Cart Error
**Purpose**: Validates error handling for empty cart checkout.

**Expected Behavior**: System should display "Error: Cart is empty" and not process payment.

---

### Test 6: Insufficient Balance Error
**Purpose**: Tests error handling when customer cannot afford the purchase.

**Scenario**: Customer with $100 trying to buy $5000 TV
**Expected Behavior**: System should display insufficient balance error without processing payment.

---

### Test 7: Out of Stock Error
**Purpose**: Tests stock validation at both cart addition and checkout phases.

**Scenarios**:
- Adding more items than available to cart
- Stock reduction between cart addition and checkout

**Expected Behavior**: Appropriate error messages without processing payment.

---

### Test 8: Expired Product Error
**Purpose**: Validates expiration checking during checkout.

**Scenario**: Cart containing expired cheese
**Expected Behavior**: System should reject checkout with expiration error.

---

### Test 9: Shipping Service Tests
**Purpose**: Tests shipping calculations and notifications.

**Coverage**:
- Weight-based shipping fee calculation
- Shipping notice generation
- Multiple item weight aggregation

**Validation**:
- Correct shipping rate application (30 per kg)
- Proper weight display in grams
- Total package weight calculation

---

### Test 10: Edge Cases
**Purpose**: Tests boundary conditions and error scenarios.

**Coverage**:
- Zero quantity validation
- Negative quantity validation
- Zero balance customers
- Invalid balance deductions

**Expected Behavior**: Appropriate exception throwing and error messages.

---

### Test 11: Complex Scenarios
**Purpose**: Tests real-world usage patterns with multiple customers and transactions.

**Scenarios**:
- Multiple customers sharing product inventory
- Large quantity purchases
- Sequential checkouts affecting stock levels

**Validation**:
- Proper inventory management across transactions
- Stock level accuracy after multiple purchases
- Balance tracking across customers

---

## How to Run

### Prerequisites
- Java 8 or higher
- Command line access

### Compilation
```bash
cd src
javac *.java
```

### Running Main Demo
```bash
java Main
```

### Running Test Cases
```bash
java TestCases
```

### Expected Output
The system will display:
- Shipment notices for shippable items
- Detailed checkout receipts
- Error messages for invalid operations
- Test results with pass/fail status

---

## Usage Examples

### Basic Product Creation
```java
// Create different product types
Cheese cheese = new Cheese("Gouda", 150.0, 10, LocalDate.now().plusDays(7), 0.25);
TV tv = new TV("Smart TV", 8000.0, 5, 18.5);
ScratchCard card = new ScratchCard("Recharge Card", 100.0, 50);
```

### Shopping Cart Usage
```java
Cart cart = new Cart();
cart.add(cheese, 2);
cart.add(tv, 1);
cart.add(card, 3);

System.out.println("Subtotal: " + cart.getSubtotal());
```

### Customer and Checkout
```java
Customer customer = new Customer("John Doe", 10000.0);
ECommerceSystem.checkout(customer, cart);
```

### Error Handling Examples
```java
// This will throw an exception
try {
    cart.add(cheese, 100); // More than available
} catch (IllegalArgumentException e) {
    System.out.println("Error: " + e.getMessage());
}
```

---

## Design Patterns

### 1. Template Method Pattern
- **Location**: `Product` abstract class
- **Purpose**: Defines common product behavior while allowing subclasses to implement specific logic
- **Implementation**: Abstract methods `isExpired()` and `requiresShipping()`

### 2. Strategy Pattern
- **Location**: Product type implementations
- **Purpose**: Different expiration and shipping strategies for different product types
- **Implementation**: Each product type implements its own expiration and shipping logic

### 3. Facade Pattern
- **Location**: `ECommerceSystem` class
- **Purpose**: Provides simplified interface for complex checkout process
- **Implementation**: Single `checkout()` method orchestrates multiple operations

### 4. Value Object Pattern
- **Location**: `CartItem` class
- **Purpose**: Immutable data holder for product-quantity pairs
- **Implementation**: Encapsulates product reference and quantity

---

## Error Handling

### Validation Levels

#### 1. Input Validation
- Quantity must be positive
- Customer balance must be non-negative
- Product parameters must be valid

#### 2. Business Rule Validation
- Stock availability checking
- Expiration date validation
- Balance sufficiency verification

#### 3. System State Validation
- Cart emptiness checking
- Product availability at checkout time
- Inventory consistency

### Error Types

#### IllegalArgumentException
- **When**: Invalid input parameters
- **Examples**: Negative quantities, insufficient stock, invalid balance operations

#### Business Logic Errors
- **When**: Business rules are violated
- **Examples**: Expired products, empty cart, insufficient balance
- **Handling**: User-friendly error messages without exceptions

---

## Assumptions

### Business Assumptions
1. **Shipping Rate**: Fixed rate of 30 per kilogram
2. **Digital Products**: Scratch cards are delivered digitally (no shipping)
3. **Expiration**: Products expire at end of expiry date
4. **Currency**: All prices in same currency unit
5. **Inventory**: Simple inventory model (no reservations)

### Technical Assumptions
1. **Single-threaded**: No concurrent access considerations
2. **In-memory**: No persistence layer
3. **Console Output**: No GUI requirements
4. **Java 8+**: Uses LocalDate and Streams
5. **Weight Units**: All weights in kilograms

### System Assumptions
1. **Stock Updates**: Real-time inventory updates
2. **Payment**: Instantaneous balance deduction
3. **Shipping**: All shippable items ship together
4. **Cart Lifecycle**: Cart cleared after successful checkout
5. **Error Recovery**: System continues after errors

---

## Future Enhancements

### Potential Improvements
1. **Persistence Layer**: Database integration for products and customers
2. **Multi-threading**: Concurrent cart operations
3. **Advanced Shipping**: Multiple shipping options and carriers
4. **Promotions**: Discount and coupon system
5. **Order History**: Track customer purchase history
6. **Inventory Management**: Advanced stock tracking and alerts
7. **Payment Gateway**: Multiple payment methods
8. **User Interface**: Web or desktop GUI
9. **Internationalization**: Multi-language and currency support
10. **Analytics**: Sales reporting and customer insights

### Scalability Considerations
1. **Database Design**: Normalized schema for products, customers, orders
2. **Caching**: Product catalog caching for performance
3. **Load Balancing**: Distributed system architecture
4. **Microservices**: Separate services for cart, payment, shipping
5. **Event Sourcing**: Audit trail for all transactions

---

*This documentation covers the complete E-Commerce System implementation. For questions or contributions, please refer to the source code and test cases for detailed examples.*
