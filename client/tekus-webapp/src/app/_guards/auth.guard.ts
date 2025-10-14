import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { AuthService } from '../_services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private autService: AuthService, private router: Router){}
  
  canActivate(): Observable<boolean> {
    return this.autService.currentUser$.pipe(
      map(user => {
        if (user) return true;
        this.router.navigate(['/auth/login']);
        return false;
      })
    )
  }
  
}