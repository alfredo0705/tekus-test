import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { DashboardSummary } from '../_models/dashboard-summary';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  baseUrl = environment.apiUrl;
  cache = new Map();

  constructor(private http: HttpClient) { }

  getDashboard(){
    return this.http.get<DashboardSummary>(this.baseUrl + 'dashBoard/summary');
  }
}
