// javascript/Customer.js
export class Customer {
    constructor(name, balance) {
        this.name = name;
        this.balance = balance;
    }

    getName() {
        return this.name;
    }

    getBalance() {
        return this.balance;
    }

    deductBalance(amount) {
        if (amount > this.balance) {
            throw new Error("Insufficient balance");
        }
        this.balance -= amount;
    }

    hasBalance(amount) {
        return this.balance >= amount;
    }
}
