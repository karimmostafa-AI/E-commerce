CXX = g++
CXXFLAGS = -std=c++17 -Wall -Wextra -pedantic -O2
TARGET = ecommerce
SOURCES = main.cpp Product.cpp Customer.cpp Cart.cpp CartItem.cpp \
          ExpirableProduct.cpp ShippableProduct.cpp Cheese.cpp Biscuits.cpp \
          TV.cpp Mobile.cpp ScratchCard.cpp ECommerceSystem.cpp ShippingService.cpp

OBJECTS = $(SOURCES:.cpp=.o)

all: $(TARGET)

$(TARGET): $(OBJECTS)
	$(CXX) $(CXXFLAGS) -o $(TARGET) $(OBJECTS)

%.o: %.cpp
	$(CXX) $(CXXFLAGS) -c $< -o $@

clean:
	rm -f $(OBJECTS) $(TARGET)

.PHONY: all clean
