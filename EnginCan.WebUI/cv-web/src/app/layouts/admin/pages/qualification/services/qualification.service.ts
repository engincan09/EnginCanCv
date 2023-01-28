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
      .get(environment.api, {
        url: 'Qualification/GetAllQualification',
        version: '1.0',
      },true)
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  postQualification(model) {
    return this.http
      .post(
        environment.api,
        {
          url: 'Qualification/PostQualification/',
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
  updateQualification(model) {
    return this.http
      .post(
        environment.api,
        {
          url: 'Qualification/UpdateQualification/',
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
  deleteQualification(id) {
    return this.http
      .get(environment.api, {
        url: 'Qualification/DeleteQualification/' + id,
        version: '1.0',
      },true)
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  getQualification(id: number) {
    return this.http
      .get(environment.api, {
        url: 'Qualification/GetById/' + id,
        version: '1.0',
      },true)
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  uploadFile(data) {
    return this.http
      .post(environment.api, {
        url: 'Qualification/UploadFile',
        version: '1.0',
      },
      data)
      .pipe(
        map((res: any) => {
          console.log(res);
          return res;
        })
      );
  }
}
