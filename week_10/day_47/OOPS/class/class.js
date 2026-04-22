"use strict";
class person {
    name;
    constructor(name) {
        this.name = name;
    }
    greet() {
        console.log(`Hello ${this.name}`);
    }
}
const p1 = new person("RAM");
p1.greet();
