import { Routes } from '@angular/router';
import { ProviderListComponent } from './components/pages/providers/provider-list/provider-list.component';
import { ProviderCreateComponent } from './components/pages/providers/provider-create/provider-create.component';
import { ProviderEditComponent } from './components/pages/providers/provider-edit/provider-edit.component';
import { ServiceListComponent } from './components/pages/services/service-list/service-list.component';
import { ServiceCreateComponent } from './components/pages/services/service-create/service-create.component';
import { ServiceEditComponent } from './components/pages/services/service-edit/service-edit.component';

export const routes: Routes = [
    { 
        path: 'providers', 
        loadComponent: () => import('./components/pages/providers/provider-list/provider-list.component').then(h => ProviderListComponent)
    },
    { 
        path: 'providers-create', 
        loadComponent: () => import('./components/pages/providers/provider-create/provider-create.component').then(h => ProviderCreateComponent)
    },
    { 
        path: 'providers-edit', 
        loadComponent: () => import('./components/pages/providers/provider-edit/provider-edit.component').then(h => ProviderEditComponent)
    },
    { 
        path: 'services', 
        loadComponent: () => import('./components/pages/services/service-list/service-list.component').then(h => ServiceListComponent)
    },
    { 
        path: 'services-create', 
        loadComponent: () => import('./components/pages/services/service-create/service-create.component').then(h => ServiceCreateComponent)
    },
    { 
        path: 'services-edit', 
        loadComponent: () => import('./components/pages/services/service-edit/service-edit.component').then(h => ServiceEditComponent)
    },
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: '**', redirectTo: '' }
];
