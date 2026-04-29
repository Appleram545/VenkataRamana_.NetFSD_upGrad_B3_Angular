import { Component } from '@angular/core';
import { Contact } from '../../models/contact';
import { contact } from '../../services/contact';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-contact',
  imports: [FormsModule],
  templateUrl: './add-contact.html',
  styleUrl: './add-contact.css',
})
export class AddContact {
  contact: Contact = {
    id: 0,
    name: '',
    email: '',
    phone: '',
  };

  constructor(private contactService: contact) {}

  addContact() {
    this.contactService.addContact(this.contact);

    alert('Contact Added!');

    this.contact = {
      id: 0,
      name: '',
      email: '',
      phone: '',
    };
  }
}
