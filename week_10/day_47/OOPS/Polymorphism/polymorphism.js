"use strict";
class Animal {
    sound() {
        console.log("Animal Sound");
    }
}
class Cat extends Animal {
    sound() {
        console.log("Meow");
    }
}
const a = new Cat();
a.sound();
