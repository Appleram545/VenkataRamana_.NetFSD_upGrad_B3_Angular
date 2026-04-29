import { Component } from '@angular/core';
import { Contact } from '../../models/contact';
import { ContactService } from '../../services/contact';
import { ActivatedRoute,Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact-form.html',
  styleUrl: './contact-form.css',
})
export class ContactForm {
  contact: Contact = { id: 0, name: '', email: '', phone: '', status: '' };
  isEdit = false;

  constructor(
    private Service: ContactService,
    private route: ActivatedRoute,
    private router: Router,
  ) {}

  ngOnIt() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.isEdit = true;
      this.Service.getContactById(+id).subscribe((data) => (this.contact = data));
    }
  }

  submit() {
    if (this.isEdit) {
      this.Service.updateContact(this.contact).subscribe(() => {
        alert('Updated successfully');
        this.router.navigate(['/']);
      });
    } else {
      this.Service.addContact(this.contact).subscribe(() => {
        alert('Added successfully');
        this.router.navigate(['/']);
      });
    }
  }
}
