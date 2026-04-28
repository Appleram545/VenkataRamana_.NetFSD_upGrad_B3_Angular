import { Component } from '@angular/core';
import { Contact } from '../../models/contactmodel';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [FormsModule],
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

  constructor(private router: Router) {}

  addContact() {
    console.log(this.newContact);
    this.router.navigate(['/contacts']);
  }
}
