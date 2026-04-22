"use strict";
class Animal {
    move() {
        console.log("Moving ...");
    }
}
class Dog extends Animal {
    sound() {
        console.log("Bark");
    }
}
const d = new Dog();
d.sound();
d.move();
