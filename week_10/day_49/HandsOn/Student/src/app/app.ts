import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Student } from '../models/student';
import { formatName,calculateAverage } from '../utils/utils';
import { getGrade,getTopper } from '../services/studentService';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('Student');

  students: Student[] = [
    { id: 1, name: 'ram', marks: 85 },
    { id: 2, name: 'sadvi', marks: 92 },
    { id: 3, name: 'priya', marks: 58 },
    { id: 4, name: 'tony', marks: 73 },
  ];

  constructor() {
    console.log('Formatted Names:');
    this.students.forEach((s) => console.log(formatName(s.name)));

    console.log('\nGrades:');
    this.students.forEach((s) => console.log(`${formatName(s.name)}: ${getGrade(s.marks)}`));

    console.log('\nAverage:', calculateAverage(this.students));

    const topper = getTopper(this.students);
    console.log('Topper:', formatName(topper.name), topper.marks);
  }
}
