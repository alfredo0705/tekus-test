import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, Observable } from 'rxjs';
import { AuthService } from '../_services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private autService: AuthService, private router: Router){}
  
  logout(){
    this.router.navigateByUrl('/');
  }

  canActivate(): Observable<boolean> {
    return this.autService.currentUser$.pipe(
      map(user => {
        if (user) return true;
        this.logout()
        return false;
      })
    )
  }
  
}