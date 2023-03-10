import { IletisimTalepleriComponent } from './pages/iletisim-talepleri/iletisim-talepleri.component';
import { Routes } from '@angular/router';
import { AuthGuardService } from 'src/app/shared/services/auth-guard.service';
import { AdminComponent } from './admin.component';
import { AboutComponent } from './pages/about/about.component';
import { MainHomeComponent } from './pages/main-home/main-home.component';
import { QualificationComponent } from './pages/qualification/qualification.component';
import { SettingComponent } from './pages/setting/setting.component';
import { SkillComponent } from './pages/skill/skill.component';


export const AdminRoutes: Routes = [
  {
    path: '',
    component: AdminComponent,
    children: [
      {
        path: 'giris-islemleri',
        loadChildren: () =>
          import('../../layouts/admin/pages/registration/registration.module').then(
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
        path: 'tecrube-egitim',
        data: { pageId: 19 },
        canActivate: [AuthGuardService],
        component: QualificationComponent
      },
      {
        path: 'ayarlar',
        data: { pageId: 20 },
        canActivate: [AuthGuardService],
        component: SettingComponent
      },
      {
        path: 'iletisim-talepleri',
        data: { pageId: 21 },
        canActivate: [AuthGuardService],
        component: IletisimTalepleriComponent
      },
      {
        path: '**',
        component: MainHomeComponent,
      },
    ],
  },
];
