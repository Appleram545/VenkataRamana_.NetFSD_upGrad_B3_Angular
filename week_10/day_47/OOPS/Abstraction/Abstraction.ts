abstract class Animal{
    abstract sound(): void;

    move(){
        console.log("Moving ...");
    }
}

class Dog extends Animal{
    sound(){
        console.log("Bark");
    }
}
const d = new Dog();
d.sound();
d.move();