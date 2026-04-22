class person{
    name :string;

    constructor(name :string){
        this.name = name;
    }

    greet(){
        console.log(`Hello ${this.name}`);

    }
}
const p = new person("RAM");
p.greet();