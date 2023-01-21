import { SkillComponent } from './../../modules/skill/skill.component';
import { AboutComponent } from './../../modules/about/about.component';
import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardLayoutModule } from 'src/app/shared/layouts/dashboard-layout/dashboard-layout.module';
import { MainRoutes } from './main.routing';
import { MainComponent } from './main.component';
import { MainHomeComponent } from './main-home/main-home.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { QualificationComponent } from 'src/app/modules/qualification/qualification.component';
@NgModule({
  declarations: [MainComponent,MainHomeComponent,QualificationComponent,AboutComponent,SkillComponent],
  providers:[DatePipe],
  imports: [
    CommonModule,
    RouterModule.forChild(MainRoutes),
    DashboardLayoutModule,
    SharedModule
  ]
})
export class MainModule { }

