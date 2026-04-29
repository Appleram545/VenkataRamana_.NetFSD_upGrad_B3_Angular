import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginToggle } from './components/login-toggle/login-toggle';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth-guard';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,LoginToggle,FormsModule,CommonModule,RouterModule],
  templateUrl: './app.html',
  styleUrl: './app.css'

})
export class App {
  protected readonly title = signal('contactManager');
}
