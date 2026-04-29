import { Component } from '@angular/core';
import { contact } from '../../services/contact';
import { Contact } from '../../models/contact';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-list',
  imports: [CommonModule],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {
  contacts: Contact[] = [];

  constructor(private contactService: contact) {}

  ngOnInit() {
    this.contacts = this.contactService.getContacts();
  }
}
