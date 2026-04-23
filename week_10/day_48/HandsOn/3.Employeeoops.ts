class Employee {
  public id: number;
  protected name: string;
  private salary: number;

  constructor(id: number, name: string, salary: number) {
    this.id = id;
    this.name = name;
    this.salary = salary;
  }

  public getSalary(): number {
    return this.salary;
  }

  public setSalary(value: number): void {
    if (value > 0) {
      this.salary = value;
    } else {
      console.log("Salary must be greater than 0");
    }
  }

  public displayDetails(): void {
    console.log(`ID: ${this.id}, Name: ${this.name}, Salary: ${this.salary}`);
  }
}

class Manager extends Employee {
  private teamSize: number;

  constructor(id: number, name: string, salary: number, teamSize: number) {
    super(id, name, salary);
    this.teamSize = teamSize;
  }

  public displayDetails(): void {
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
