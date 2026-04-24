import { Component, OnInit } from '@angular/core';
import { DataManager } from '../Services/service';
import { User } from '../models/User';
import { getFirstElement } from '../generic/genericFunction';

@Component({
  selector: 'app-user-component',
  imports: [],
  templateUrl: './user-component.html',
  styleUrl: './user-component.css',
})
export class UserComponent  {

  private UserManager =new DataManager<User>();

  ngOnInit(): void {
    this.UserManager.add({ id: 1, name: 'Ram' });
    this.UserManager.add({ id: 2, name: 'Sadvika' });

    const users = this.UserManager.getAll();

     console.log('Users:', users);
    console.log('First User:', getFirstElement(users));

  }

}
