import { Component } from '@angular/core';
import { ContactService } from '../../services/contact';
import { Router, RouterLink } from '@angular/router';
import { Contact } from '../../models/contact';
import { OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [RouterLink,CommonModule],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {
  contacts: Contact[] = [];
  errorMsg = '';

  constructor(
    private service: ContactService,
    private router: Router,
  ) {}

  ngOnIt() {
    this.loadContacts();
  }

  loadContacts() {
    this.service.getContacts().subscribe({
      next: (data) => (this.contacts = data),
      error: () => (this.errorMsg = 'failed to Load'),
    });
  }

  delete(id: number) {
    this.service.deleteContact(id).subscribe({
      next: () => this.loadContacts(),
      error: () => alert('failed to delete'),
    });
  }
}
