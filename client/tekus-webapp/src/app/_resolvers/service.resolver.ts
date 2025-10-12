import { ResolveFn } from '@angular/router';

export const serviceResolver: ResolveFn<boolean> = (route, state) => {
  return true;
};
