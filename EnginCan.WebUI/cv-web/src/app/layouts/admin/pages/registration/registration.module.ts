import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardLayoutModule } from 'src/app/shared/layouts/dashboard-layout/dashboard-layout.module';
import { RegistrationRoutes } from './registration.routing';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(RegistrationRoutes),
    DashboardLayoutModule,
    SharedModule
  ]
})
export class RegistrationModule { }

