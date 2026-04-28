import { Component } from '@angular/core';
import { ContactService } from '../services/contact';
import { Contact } from '../models/contacts';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-addcontact',
  imports: [FormsModule],
  templateUrl: './addcontact.html',
  styleUrl: './addcontact.css',
})
export class Addcontact {

  newContact :Contact = {

    id:0,
    name:"",
    email:"",
    phone:""
  };

  constructor(private contactservice :ContactService){}

  addContact(){
    this.contactservice.addContact(this.newContact);

    this.newContact={
    id:0,
    name:"",
    email:"",
    phone:""};
  }

}
