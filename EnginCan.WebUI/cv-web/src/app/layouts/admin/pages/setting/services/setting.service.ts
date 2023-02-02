import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { HttpService } from 'src/app/shared/services/http.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SettingService {
  constructor(private http: HttpService, private router: Router) {}

  updateSetting(model) {
    return this.http
      .post(
        environment.api,
        {
          url: 'Setting/UpdateSetting/',
          version: '1.0',
        },
        model
      )
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  getSetting(id: number) {
    return this.http
      .get(environment.api, {
        url: 'Setting/GetById/' + id,
        version: '1.0',
      },true)
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
}
