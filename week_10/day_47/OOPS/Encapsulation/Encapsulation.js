"use strict";
class BankAccount {
    balance = 0;
    deposit(amount) {
        this.balance += amount;
    }
    getBalance() {
        return this.balance;
    }
}
const acc = new BankAccount();
acc.deposit(1500);
console.log(acc.getBalance());
