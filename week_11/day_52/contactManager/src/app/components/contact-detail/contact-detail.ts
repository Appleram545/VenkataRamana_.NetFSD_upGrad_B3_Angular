import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { contact } from '../../services/contact';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-contact-detail',
  imports: [FormsModule],
  templateUrl: './contact-detail.html',
  styleUrl: './contact-detail.css',
})
export class ContactDetail {
  contact?: Contact; // may be undefined if not found

  constructor(
    private route: ActivatedRoute,
    private contactService: contact,
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.contact = this.contactService.getContactById(id);

    console.log('Loaded Contact:', this.contact);
  }
}
