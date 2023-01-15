import { SkillComponent } from './../../modules/skill/skill.component';
import { AboutComponent } from './../../modules/about/about.component';
import { Routes } from '@angular/router';

import { MainHomeComponent } from './main-home/main-home.component';
import { MainComponent } from './main.component';
import { AuthGuardService } from 'src/app/shared/services/auth-guard.service';

export const MainRoutes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: 'giris-islemleri',
        loadChildren: () =>
          import('../../modules/registration/registration.module').then(
            (m) => m.RegistrationModule
          ),
      },
      {
        path: 'hakkimda',
        data: { pageId: 17 },
        canActivate: [AuthGuardService],
        component: AboutComponent
      },
      {
        path: 'yetenekler',
        data: { pageId: 18 },
        canActivate: [AuthGuardService],
        component: SkillComponent
      },
      {
        path: '**',
        component: MainHomeComponent,
      },
    ],
  },
];
