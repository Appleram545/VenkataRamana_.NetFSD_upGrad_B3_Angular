import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root',
})
export class ContactService{
  private contacts: Contact[] = [
    { id: 1, name: 'Ram', email: 'ram@gmail.com', phone: '73308099546' },
    { id: 2, name: 'Sita', email: 'sita@gmail.com', phone: '57657669832' },
  ];

  constructor() {}

  // Get all contacts
  getContacts(): Contact[] {
    return this.contacts;
  }

  // Add new contact
  addContact(contact: Contact): void {
    this.contacts.push(contact);
  }

  // Get contact by ID
  getContactById(id: number): Contact | undefined {
    return this.contacts.find((c) => c.id === id);
  }
}
