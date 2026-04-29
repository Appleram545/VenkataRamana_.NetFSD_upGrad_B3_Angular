

import { CanActivate} from '@angular/router';
import { CanActivateFn, Router } from '@angular/router';
import { Auth } from '../services/auth';

export class AuthGuard implements CanActivate {
  constructor(
    private auth: Auth,
    private router: Router,
  ) {}

  canActivate(): boolean {
    if (this.auth.isAuthenticated()) {
      return true;
    } else {
      alert('Access Denied! Please login first.');
      this.router.navigate(['/contacts']);
      return false;
    }
  }
}
