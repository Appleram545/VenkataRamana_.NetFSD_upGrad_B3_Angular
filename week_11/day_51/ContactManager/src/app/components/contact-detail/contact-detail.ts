import { Component } from '@angular/core';
import { Contact } from '../../models/contactmodel';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-detail',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './contact-detail.html',
  styleUrl: './contact-detail.css',
})
export class ContactDetail {
  contact!: Contact;

  contacts: Contact[] = [
    { id: 1, name: 'Ram', email: 'ram@gmail.com', phone: '1567987658' },
    { id: 2, name: 'Sadvi', email: 'sadvi@gmail.com', phone: '227654456' },
  ];

  constructor(private route: ActivatedRoute) {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.contact = this.contacts.find((c) => c.id === id)!;
  }
}
