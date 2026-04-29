import { Routes,RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { ContactList } from './components/contact-list/contact-list';
import { ContactDetail } from './components/contact-detail/contact-detail';
import { AddContact } from './components/add-contact/add-contact';
import { AuthGuard } from './guards/auth-guard';

export const routes: Routes = [
  { path: 'contacts', component: ContactList },

  { path: 'add-contact', component: AddContact, canActivate: [AuthGuard] },

  { path: 'contact/:id', component: ContactDetail, canActivate: [AuthGuard] },

  { path: '', redirectTo: 'contacts', pathMatch: 'full' },
  { path: '**', redirectTo: 'contacts' },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

