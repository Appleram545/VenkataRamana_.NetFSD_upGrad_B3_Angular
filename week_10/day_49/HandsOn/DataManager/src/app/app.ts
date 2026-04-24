import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserComponent } from "../user-component/user-component";
import { ProductComponent } from "../product-component/product-component";


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, UserComponent, ProductComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('DataManager');
}
