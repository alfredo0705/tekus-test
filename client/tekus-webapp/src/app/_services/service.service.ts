import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Params } from '../_models/params';
import { HttpClient } from '@angular/common/http';
import { getPaginatedResult, getPaginationHeaders } from './pagination-helper';
import { map } from 'rxjs';
import { Service } from '../_models/service';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  baseUrl = environment.apiUrl;
  cache = new Map();
  params: Params = new Params();

  constructor(private http: HttpClient) { }

  getParams(){
      return this.params;
  }
  
  setParams(params: Params){
    this.params = params;
  }
  
  resetParams(){
    return this.params;
  }

  getServices(ServiceParams: Params){
    let params = getPaginationHeaders(ServiceParams.pageNumber, ServiceParams.pageSize);
    params = params.append('searchCriteria', ServiceParams.searchCriteria);
    
    return getPaginatedResult<Service[]>(this.baseUrl + 'services/getServices', params, this.http)
            .pipe(map(response => {
              this.cache.set(Object.values(ServiceParams).join('-'), response);
              return response;
            }))
  }

  getService(id: string) {
    return this.http.get<Service>(this.baseUrl + 'services/getService?id=' + id);
  }

  updateService(model: Service){
    return this.http.put(this.baseUrl + 'services/updateService', model);
  }

  addService(model: Service){
    return this.http.post(this.baseUrl + 'services/addService', model);
  }
}
