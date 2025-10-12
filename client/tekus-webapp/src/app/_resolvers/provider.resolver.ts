import { ResolveFn } from '@angular/router';

export const providerResolver: ResolveFn<boolean> = (route, state) => {
  return true;
};
