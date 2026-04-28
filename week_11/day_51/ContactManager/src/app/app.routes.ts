import { Routes } from '@angular/router';
import { ContactList } from './components/contact-list/contact-list';
import { AddContact } from './components/add-contact/add-contact';
import { ContactDetail } from './components/contact-detail/contact-detail';

export const routes: Routes = [
  { path: 'contacts', component: ContactList },
  { path: 'add-contact', component: AddContact },
  { path: 'contact/:id', component: ContactDetail },
  { path: '', redirectTo: 'contacts', pathMatch: 'full' },
];
