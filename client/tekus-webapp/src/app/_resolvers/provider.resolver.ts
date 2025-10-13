import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { ProviderService } from '../_services/provider.service';
import { Provider } from '../_models/provider';

export const providerResolver: ResolveFn<Provider> = (route, state) => {
  return inject(ProviderService).getProvider(route.paramMap.get('id'))
};
