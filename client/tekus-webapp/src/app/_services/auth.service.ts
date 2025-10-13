import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, ReplaySubject } from 'rxjs';
import { User } from '../_models/auth/user';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User | null>(1);
  currentUser$ = this.currentUserSource.asObservable();
  
  constructor(private http: HttpClient, private router: Router) { 
    this.loadUser(); // Cargar usuario al iniciar el servicio
  }

  loadUser(){
    const user = JSON.parse(localStorage.getItem('user') || null);
    if (user){
      this.currentUserSource.next(user);
    }
  }

  auth(model: any): Observable<any> {
    return this.http.post<User>(`${this.baseUrl}account/login`, model).pipe(
      map((response: User) =>{
        const user = response;
        if (user){
          this.setCurrentUser(user);
        }
      })
    )
  }

  setCurrentUser(user: User){
    if (user === null){
      localStorage.removeItem('user');
      this.currentUserSource.next(null);
      return;
    }
    
    user.roles = [];
    const roles = this.getDecodedToken(user.token).role;
    Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  getDecodedToken(token: string){
    return JSON.parse(atob(token.split('.')[1]));
  }
}
