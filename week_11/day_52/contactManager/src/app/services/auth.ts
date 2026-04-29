import { Injectable } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';



@Injectable({
  providedIn: 'root',
})
export class Auth {
  isLoggedIn: boolean = false;

  login() {
    this.isLoggedIn = true;
  }

  logout() {
    this.isLoggedIn = false;
  }

  isAuthenticated(): boolean {
    return this.isLoggedIn;
  }
}
