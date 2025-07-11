// javascript/Shippable.js
export class IShippable {
    constructor() {
        if (this.constructor === IShippable) {
            throw new Error("Interfaces can't be instantiated.");
        }
    }

    getName() {
        throw new Error("Method 'getName()' must be implemented.");
    }

    getWeight() {
        throw new Error("Method 'getWeight()' must be implemented.");
    }
}
