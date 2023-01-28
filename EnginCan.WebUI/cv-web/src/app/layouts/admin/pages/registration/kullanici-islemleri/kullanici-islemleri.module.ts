import { ToastrModule } from 'ngx-toastr';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardLayoutModule } from 'src/app/shared/layouts/dashboard-layout/dashboard-layout.module';
import { TumKullanicilarComponent } from './tum-kullanicilar/tum-kullanicilar.component';
import { YeniKullaniciComponent } from './yeni-kullanici/yeni-kullanici.component';
import { KullaniciIslemleriRoutes } from './kullanici-islemleri.routing';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [TumKullanicilarComponent,YeniKullaniciComponent],
  imports: [
    CommonModule,SharedModule,
    RouterModule.forChild(KullaniciIslemleriRoutes),
    DashboardLayoutModule
  ]
})
export class KullaniciIslemleriModule { }

