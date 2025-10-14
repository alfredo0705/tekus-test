import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { DashboardSummary } from '../../../../_models/dashboard-summary';
import { DashboardService } from '../../../../_services/dashboard.service';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit {
  summary: DashboardSummary;

  constructor(private dashboardService: DashboardService){}

  ngOnInit(): void {
    this.loadDashboard();
  }

  loadDashboard(){
    this.dashboardService.getDashboard().subscribe({
      next: (response) =>{
        this.summary = response;
      }
    })
  }

}
