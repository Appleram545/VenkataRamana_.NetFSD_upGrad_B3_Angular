import { Component } from '@angular/core';
import { Auth } from '../../services/auth';

@Component({
  selector: 'app-login-toggle',
  imports: [],
  templateUrl: './login-toggle.html',
  styleUrl: './login-toggle.css',
})
export class LoginToggle {
  constructor(public auth: Auth) {}

  toggleLogin() {
    if (this.auth.isLoggedIn) {
      this.auth.logout();
    } else {
      this.auth.login();
    }
  }
}
