import { NgModule} from '@angular/core';
import { Routes,RouterModule } from '@angular/router';
import { ContactForm } from './components/contact-form/contact-form';
import { ContactDetail } from './components/contact-detail/contact-detail';
import { ContactList } from './components/contact-list/contact-list';

export const routes: Routes = [
  { path: '', component: ContactList },
  { path: 'add', component: ContactForm },
  { path: 'edit/:id', component: ContactForm },
  { path: 'view/:id', component: ContactDetail },
];




