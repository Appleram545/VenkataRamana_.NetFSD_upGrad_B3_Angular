import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Contacts } from "./contacts/contacts";



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, Contacts],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ContactManager');
}
