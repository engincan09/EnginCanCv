import { SettingComponent } from './pages/setting/setting.component';
import { AdminRoutes } from './admin.routing';
import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { MainHomeComponent } from './pages/main-home/main-home.component';
import { QualificationComponent } from './pages/qualification/qualification.component';
import { AboutComponent } from './pages/about/about.component';
import { SkillComponent } from './pages/skill/skill.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardLayoutModule } from 'src/app/shared/layouts/dashboard-layout/dashboard-layout.module';


@NgModule({
  declarations: [AdminComponent,MainHomeComponent,QualificationComponent,AboutComponent,SkillComponent,SettingComponent],
  providers:[DatePipe],
  imports: [
    CommonModule,
    SharedModule,
    DashboardLayoutModule,
    RouterModule.forChild(AdminRoutes),
  ]
})
export class AdminModule { }

