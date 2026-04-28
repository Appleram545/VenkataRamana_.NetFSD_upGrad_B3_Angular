import { Component } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { CommonModule } from '@angular/common';
import { SearchFilterPipe } from '../pipes/search-filter-pipe';
import { PhoneFormatPipe } from '../pipes/phone-format-pipe';
import { StatusPipe } from '../pipes/status-pipe';

interface Contact{
  name :string;
  email :string;
  phone :string;
  status :boolean;
}

@Component({
  selector: 'app-contacts',
  imports: [FormsModule,CommonModule,SearchFilterPipe,
    PhoneFormatPipe,
    StatusPipe],
  templateUrl: './contacts.html',
  styleUrl: './contacts.css',
})
export class Contacts {

  searchText:string="";
  showAll:boolean=false;

  contacts :Contact[]=[
    { name: 'ram', email: 'ram@gmail.com', phone: '73309099876', status: true },
    { name: 'sadvika', email: 'sadvi@gmail.com', phone: '5679678697', status: false },
    { name: 'priya', email: 'priya@gmail.com', phone: '9988776655', status: true },
    { name: 'tony', email: 'tony@gmail.com', phone: '9871234560', status: true },
    { name: 'Leela', email: 'leela@gmail.com', phone: '9012345678', status: false },
    { name: 'satwik', email: 'satwik@gmail.com', phone: '9998887776', status: true },
    { name: 'kelly', email: 'kelly@gmail.com', phone: '8887776665', status: true },
    { name: 'kohli', email: 'kohli@gmail.com', phone: '746665554', status: false },
    { name: 'surya', email: 'surya@gmail.com', phone: '6665554443', status: true },
    { name: 'kajal', email: 'kajal@gmail.com', phone: '5554443332', status: false }
  ];


  toggleStatus(contact:Contact){
    contact.status= !contact.status;
  }

  get displayContacts(){
    return this.showAll ? this.contacts : this.contacts.slice(0,5);
  }


  toggleShow(){
    this.showAll=!this.showAll;
  }
}
