import { Component } from '@angular/core';
import { DashboardComponent } from '../dashboard/dashboard/dashboard.component';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [
    DashboardComponent
  ],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent {

}
