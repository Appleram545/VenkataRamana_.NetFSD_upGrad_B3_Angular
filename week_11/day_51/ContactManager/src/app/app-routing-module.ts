import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule,Routes } from '@angular/router';
import { AddContact } from './components/add-contact/add-contact';
import { ContactList } from './components/contact-list/contact-list';
import { ContactDetail } from './components/contact-detail/contact-detail';




const routes: Routes = [
  { path: 'contacts', component: ContactList },
  { path: 'add-contact', component: AddContact},
  { path: 'contact/:id', component: ContactDetail },
  { path: '', redirectTo: 'contacts', pathMatch: 'full' },
];


@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
