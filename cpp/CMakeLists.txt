cmake_minimum_required(VERSION 3.10)
project(ECommerceSystem)

# Set C++ standard
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# Add all source files
set(SOURCES
    main.cpp
    Product.cpp
    Customer.cpp
    Cart.cpp
    CartItem.cpp
    ExpirableProduct.cpp
    ShippableProduct.cpp
    Cheese.cpp
    Biscuits.cpp
    TV.cpp
    Mobile.cpp
    ScratchCard.cpp
    ECommerceSystem.cpp
    ShippingService.cpp
)

# Create executable
add_executable(ecommerce ${SOURCES})

# Set compiler flags
if(MSVC)
    target_compile_options(ecommerce PRIVATE /W4)
else()
    target_compile_options(ecommerce PRIVATE -Wall -Wextra -pedantic)
endif()
