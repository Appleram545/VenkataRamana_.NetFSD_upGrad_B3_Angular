"use strict";
class Vehicle {
    start() {
        console.log("Vehicle Started");
    }
}
class Car extends Vehicle {
    drive() {
        console.log("Vehicle Moving");
    }
}
const car = new Car();
car.start();
car.drive();
