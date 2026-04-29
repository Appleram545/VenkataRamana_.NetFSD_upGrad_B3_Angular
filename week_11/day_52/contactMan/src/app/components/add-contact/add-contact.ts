import { Component } from '@angular/core';
import { Contact } from '../../models/contact';
import { ContactService } from '../../services/contact';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-add-contact',
  imports: [FormsModule,CommonModule],
  templateUrl: './add-contact.html',
  styleUrl: './add-contact.css',
})
export class AddContact {
  newContact: Contact = {
    id: 0,
    name: '',
    email: '',
    phone: '',
  };

  constructor(private contactService: ContactService) {}

  addContact() {
    this.contactService.addContact(this.newContact);


    this.newContact = { id: 0, name: '', email: '', phone: '' };
  }
}
