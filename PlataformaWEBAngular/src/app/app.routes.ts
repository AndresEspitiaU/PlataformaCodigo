import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'auth/login',
    pathMatch: 'full', // Redirige por defecto al login
  },
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth-routing.module').then(m => m.AuthRoutingModule),
  },
  {
    path: 'admin',
    loadChildren: () => import('./modules/auth/admin-routing.module').then(m => m.AdminRoutingModule),
  },
  {
    path: 'user',
    loadChildren: () => import('./modules/auth/user-routing.module').then(m => m.UserRoutingModule),
  },
  {
    path: '**',
    redirectTo: 'auth/login', // Redirige a login si la ruta no existe
  },
];
