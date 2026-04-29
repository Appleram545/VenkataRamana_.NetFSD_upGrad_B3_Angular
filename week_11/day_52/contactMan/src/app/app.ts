import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AddContact } from "./components/add-contact/add-contact";
import { ContactDetail } from "./components/contact-detail/contact-detail";
import { ContactList } from "./components/contact-list/contact-list";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AddContact, ContactDetail, ContactList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('contactMan');
}
