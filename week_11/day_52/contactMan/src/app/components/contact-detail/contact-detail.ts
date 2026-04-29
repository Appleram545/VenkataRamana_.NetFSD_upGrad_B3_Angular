import { Component ,OnInit} from '@angular/core';
import { Contact } from '../../models/contact';
import { ContactService } from '../../services/contact';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-detail',
  imports: [CommonModule],
  templateUrl: './contact-detail.html',
  styleUrl: './contact-detail.css',
})
export class ContactDetail {
  contact?: Contact;

  constructor(private contactService: ContactService) {}

  ngOnInit() {

    const id = 1;
    this.contact = this.contactService.getContactById(id);
  }

}
