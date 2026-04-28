import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Addcontact } from "./addcontact/addcontact";
import { Contactdetail } from "./contactdetail/contactdetail";
import { Contactlist } from "./contactlist/contactlist";
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Addcontact, Contactdetail, Contactlist,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ContactManagement');
}
