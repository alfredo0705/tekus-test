import { ResolveFn } from '@angular/router';
import { Service } from '../_models/service';
import { inject } from '@angular/core';
import { ServiceService } from '../_services/service.service';

export const serviceResolver: ResolveFn<Service> = (route, state) => {
  return inject(ServiceService).getService(route.paramMap.get('id'));
};
