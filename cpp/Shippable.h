// cpp/Shippable.h
#ifndef SHIPPABLE_H
#define SHIPPABLE_H

#include <string>

class IShippable {
public:
    virtual ~IShippable() = default;
    virtual std::string getName() const = 0;
    virtual double getWeight() const = 0;
};

#endif // SHIPPABLE_H
