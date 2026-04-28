import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contact';
import { Contact } from '../models/contacts';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-contactlist',
  imports: [CommonModule],
  templateUrl: './contactlist.html',
  styleUrl: './contactlist.css',
})
export class Contactlist {

  contacts: Contact[]=[];

  constructor(private contactService: ContactService) { }
  ngOnInit() {


    this.contacts = this.contactService.getContacts();
  }
}


