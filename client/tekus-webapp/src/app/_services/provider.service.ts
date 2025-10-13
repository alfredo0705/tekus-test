import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Params } from '../_models/params';
import { getPaginatedResult, getPaginationHeaders } from './pagination-helper';
import { Provider } from '../_models/provider';
import { map } from 'rxjs';
import { ProviderCustomFields } from '../_models/custom-field';

@Injectable({
  providedIn: 'root'
})
export class ProviderService {
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

  getProvidersList(){
    return this.http.get<Provider[]>(this.baseUrl + 'providers/getProvidersList');
  }

  getProviders(providerParams: Params){
    let params = getPaginationHeaders(providerParams.pageNumber, providerParams.pageSize);
    params = params.append('searchCriteria', providerParams.searchCriteria);
    
    return getPaginatedResult<Provider[]>(this.baseUrl + 'providers/getProviders', params, this.http)
            .pipe(map(response => {
              this.cache.set(Object.values(providerParams).join('-'), response);
              return response;
            }))
  }

  getProvider(id: string) {
    return this.http.get<Provider>(this.baseUrl + 'providers/getProvider?id=' + id);
  }

  updateProvider(model: Provider){
    return this.http.put(this.baseUrl + 'providers/updateProvider', model);
  }

  addProvider(model: Provider){
    return this.http.post(this.baseUrl + 'providers/addProvider', model);
  }

  addCustomFields(model: ProviderCustomFields, id: string){
    return this.http.post(this.baseUrl + 'providers/' + id + '/custom-fields', model);
  }
}
