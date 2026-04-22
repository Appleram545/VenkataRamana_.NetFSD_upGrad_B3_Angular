class BankAccount{
    private balance : number =0;

    deposit(amount:number){
        this.balance += amount;
    }
    getBalance(){
        return this.balance;
    }
}
const ac= new BankAccount();
acc.deposit(1500);
console.log(ac.getBalance());