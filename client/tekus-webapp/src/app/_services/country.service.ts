import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Country } from '../_models/country';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  baseUrl = environment.apiUrl;
  cache = new Map();

  constructor(private http: HttpClient) { }

  getCountries(){
    return this.http.get<Country[]>(this.baseUrl + 'countries');
  }
}
