# C++ E-Commerce System

This is a C++ port of the Java e-commerce system, implementing a complete object-oriented e-commerce solution with products, shopping cart, customer management, and shipping functionality.

## Features

- **Product Management**: Abstract product base class with concrete implementations for different product types
- **Expirable Products**: Products with expiration dates (Cheese, Biscuits)
- **Shippable Products**: Products that require shipping with weight calculation
- **Shopping Cart**: Add items, calculate totals, and manage quantities
- **Customer Management**: Customer with balance management
- **Checkout System**: Complete checkout process with validation and receipt generation
- **Shipping Service**: Calculate shipping costs and generate shipping notices

## Project Structure

### Core Classes
- `Product`: Abstract base class for all products
- `Customer`: Customer with name and balance
- `Cart`: Shopping cart functionality
- `CartItem`: Individual items in the cart
- `ECommerceSystem`: Main checkout logic
- `ShippingService`: Shipping calculations and notices

### Product Hierarchy
- `ExpirableProduct`: Base class for products with expiration dates
- `ShippableProduct`: Base class for products that require shipping
- `Cheese`: Expirable and shippable product
- `Biscuits`: Expirable and shippable product
- `TV`: Shippable product (non-expirable)
- `Mobile`: Shippable product (non-expirable)
- `ScratchCard`: Digital product (no shipping, no expiration)

### Interfaces
- `IShippable`: Interface for shippable items

## Building the Project

### Option 1: Using CMake (Recommended)
```bash
mkdir build
cd build
cmake ..
make
```

### Option 2: Using Make
```bash
make
```

### Option 3: Manual Compilation
```bash
g++ -std=c++17 -Wall -Wextra -pedantic -O2 -o ecommerce *.cpp
```

## Running the Application

After building, run the executable:
```bash
./ecommerce
```

## Example Scenarios

The application demonstrates several scenarios:

1. **Successful Checkout**: Complete purchase with receipt and shipping
2. **Empty Cart**: Error handling for empty cart
3. **Insufficient Balance**: Customer doesn't have enough money
4. **Out of Stock**: Product quantity exceeded
5. **Expired Product**: Product past expiration date
6. **Mixed Cart**: Multiple products with shipping calculations

## Key Differences from Java Version

- Uses `std::chrono` for date handling instead of `LocalDate`
- Uses raw pointers for product references (could be improved with smart pointers)
- Uses `std::vector` instead of Java's `ArrayList`
- Uses `dynamic_cast` for interface checking
- Exception handling with `std::exception` instead of Java exceptions

## Requirements

- C++17 compatible compiler (GCC 7+, Clang 5+, MSVC 2017+)
- CMake 3.10+ (if using CMake build)
- Make (if using Makefile build)

## Notes

- The project uses modern C++ features like `auto`, range-based for loops, and smart pointers
- Memory management is handled automatically for stack-allocated objects
- The interface design follows C++ idioms while maintaining the original Java structure
