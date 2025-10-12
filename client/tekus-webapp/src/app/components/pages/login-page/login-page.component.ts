import { Component, NgZone } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../_services/auth.service';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    CommonModule,
    ReactiveFormsModule,
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})
export class LoginPageComponent {
  loginModel = {
    username: '',
    password: ''
  };

  loginForm: FormGroup;
  hidePassword = true;

  constructor(
    private router: Router,
    private ngZone: NgZone,
    private authServiceAPI: AuthService,
    private fb: FormBuilder
  ) 
  {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  loginByEmail() {
    this.authServiceAPI.auth(this.loginForm.value).subscribe({
      next: () => this.ngZone.run(() => this.router.navigate(['/home'])),
      error: (error) => console.error('Error en la autenticación:', error)
    });
  }

}
