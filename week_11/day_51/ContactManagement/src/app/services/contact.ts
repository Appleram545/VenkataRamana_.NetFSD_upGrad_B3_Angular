import { Injectable } from '@angular/core';
import { Contact } from '../models/contacts';

@Injectable({
  providedIn: 'root',
})
export class ContactService {

private contacts:Contact[]=[
  { id: 1, name: 'Ram', email: 'ram@gmail.com', phone: '9877264210' },
    { id: 2, name: 'sadvi', email: 'sadvi@gmail.com', phone: '9178456930' }
];


//get all contacts
getContacts():Contact[]{

  return this.contacts;
}

//add contact
addContact(contact :Contact):void{
  this.contacts.push(contact);
}

//get contact by Id
getContactById(id:number):Contact | undefined{
  return this.contacts.find(c=> c.id === id);
}


}
