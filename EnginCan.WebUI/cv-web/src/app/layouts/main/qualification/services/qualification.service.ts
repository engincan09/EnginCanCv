import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { HttpService } from 'src/app/shared/services/http.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class QualificationService {
  constructor(private http: HttpService, private router: Router) {}

  getAllQualification() {
    return this.http
      .get(
        environment.api,
        {
          url: 'Qualification/GetAllQualification',
          version: '1.0',
        },
        true
      )
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
}
