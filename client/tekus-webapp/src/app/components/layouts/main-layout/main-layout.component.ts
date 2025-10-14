import { CommonModule, NgFor } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { take } from 'rxjs';
import { User } from '../../../_models/auth/user';
import { AuthService } from '../../../_services/auth.service';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule, MatIconButton } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [CommonModule, 
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatButtonModule,
    MatIconButton,
    RouterOutlet,
    MatIconModule,
    NgFor, 
    RouterOutlet, 
    RouterModule],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.scss'
})
export class MainLayoutComponent implements OnInit {
  menuItems: any[] = [];
  drawerOpened = true;
  navigation = [
  {
    text: 'Administración',
    icon: 'preferences',
    items: [
      { text: 'Proveedores', path: 'providers' },
      { text: 'Servicios', path: 'services' },
    ]
  }
];

  buttonOptions = {
    icon: 'menu',
    onClick: () => {
      this.drawerOpened = !this.drawerOpened;
    }
  };

  ngOnInit(): void {
      this.authService.currentUser$.pipe(take(1)).subscribe((user: User | null) => {
        if (!user) return;
      });
    }

  toggleDrawer() {
    this.drawerOpened = this.drawerOpened;
  }

  navigate(path: string) {
    this.router.navigate([path]);
  }

  constructor(public router: Router,
      private authService: AuthService){
  }
  
  isLoginPage(): boolean {
    return this.router.url === '/auth/login';
  }

}
