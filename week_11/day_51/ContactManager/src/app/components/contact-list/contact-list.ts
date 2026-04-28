import { Component } from '@angular/core';
import { Contact } from '../../models/contactmodel';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-list',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {
  contacts: Contact[] = [
    { id: 1, name: 'Ram', email: 'ram@gmail.com', phone: '1567987658' },
    { id: 2, name: 'Sadvi', email: 'sadvi@gmail.com', phone: '227654456' },
  ];

  constructor(private router: Router) {}

  viewContact(id: number) {
    this.router.navigate(['/contact', id]);
  }
}
