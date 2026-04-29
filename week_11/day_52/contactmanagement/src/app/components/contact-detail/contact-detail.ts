import { Component ,OnInit} from '@angular/core';
import { ContactService } from '../../services/contact';
import { ActivatedRoute } from '@angular/router';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-contact-detail',
  imports: [],
  templateUrl: './contact-detail.html',
  styleUrl: './contact-detail.css',
})
export class ContactDetail {
  contact!: Contact;

  constructor(
    private service: ContactService,
    private route: ActivatedRoute,
  ) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.service.getContactById(id).subscribe((data) => (this.contact = data));
  }
}
