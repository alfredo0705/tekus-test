import { Routes } from '@angular/router';
import { ProviderListComponent } from './components/pages/providers/provider-list/provider-list.component';
import { ProviderCreateComponent } from './components/pages/providers/provider-create/provider-create.component';
import { ProviderEditComponent } from './components/pages/providers/provider-edit/provider-edit.component';
import { ServiceListComponent } from './components/pages/services/service-list/service-list.component';
import { ServiceCreateComponent } from './components/pages/services/service-create/service-create.component';
import { ServiceEditComponent } from './components/pages/services/service-edit/service-edit.component';
import { AuthGuard } from './_guards/auth.guard';
import { MainLayoutComponent } from './components/layouts/main-layout/main-layout.component';
import { AuthLayoutComponent } from './components/layouts/auth-layout/auth-layout.component';
import { LoginPageComponent } from './components/pages/login-page/login-page.component';
import { HomePageComponent } from './components/pages/home-page/home-page.component';
import { providerResolver } from './_resolvers/provider.resolver';
import { serviceResolver } from './_resolvers/service.resolver';

export const routes: Routes = [{
    path: '',
    runGuardsAndResolvers: 'always',
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'home', component: HomePageComponent },
      { path: 'providers', component: ProviderListComponent },
      { path: 'providers/create', component: ProviderCreateComponent},
      { path: 'providers/edit/:id', component: ProviderEditComponent, resolve: { provider: providerResolver }},
      { path: 'services', component: ServiceListComponent},
      { path: 'services-create', component: ServiceCreateComponent},
      { path: 'services-edit/:id', component: ServiceEditComponent, resolve: {service: serviceResolver }}
    ]
  },
{
    path: 'auth',
    component: AuthLayoutComponent,
    children: [
      { path: 'login', component: LoginPageComponent },
    ]
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];