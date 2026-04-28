import { Component,OnInit } from '@angular/core';
import { ContactService } from '../services/contact';
import { Contact } from '../models/contacts';
import { NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contactdetail',
  imports: [NgIf,FormsModule],
  templateUrl: './contactdetail.html',
  styleUrl: './contactdetail.css',
})
export class Contactdetail {

  id:number=0;
    contact?: Contact;

    constructor(private contactService: ContactService) { }

    getContact() {
    this.contact = this.contactService.getContactById(this.id);
  }
}
