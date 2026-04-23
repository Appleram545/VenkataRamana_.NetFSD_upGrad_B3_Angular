"use strict";
class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    getSalary() {
        return this.salary;
    }
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Salary must be greater than 0");
        }
    }
    displayDetails() {
        console.log(`ID: ${this.id}, Name: ${this.name}, Salary: ${this.salary}`);
    }
}
class Manager extends Employee {
    teamSize;
    constructor(id, name, salary, teamSize) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }
    displayDetails() {
        super.displayDetails();
        console.log(`Team Size: ${this.teamSize}`);
    }
}
const emp = new Employee(1, "Ram", 30000);
emp.displayDetails();
emp.setSalary(35000);
console.log("Updated Salary:", emp.getSalary());
const mgr = new Manager(2, "Sadvika", 50000, 10);
mgr.displayDetails();
