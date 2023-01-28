import { Routes } from '@angular/router';
import { LoginComponent } from './layouts/admin/login/login.component';
import { AuthGuardService, IsLoggedIn } from './shared/services/auth-guard.service';

export const AppRoutes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./layouts/main/main.module').then((m) => m.MainModule),
  },
  {
    path: 'yonetim',
    loadChildren: () =>
      import('./layouts/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: 'giris',
    component: LoginComponent,
    resolve: [IsLoggedIn],
  },

];
