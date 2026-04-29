import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root',
})
export class contact {
  private contacts: Contact[] = [];

  // get all contacts
  getContacts(): Contact[] {
    return this.contacts;
  }

  // add contact
  addContact(contact: Contact) {
    this.contacts.push({ ...contact });
  }

  // get by id
  getContactById(id: number): Contact | undefined {
    return this.contacts.find((c) => c.id === id);
  }
}
