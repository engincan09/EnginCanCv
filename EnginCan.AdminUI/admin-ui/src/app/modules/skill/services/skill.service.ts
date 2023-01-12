import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { HttpService } from 'src/app/shared/services/http.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SkillService {
  constructor(private http: HttpService, private router: Router) {}

  getAllSkill() {
    return this.http
      .get(environment.api, {
        url: 'Skill/GetAllSkill',
        version: '1.0',
      })
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  postSkill(model) {
    return this.http
      .post(
        environment.api,
        {
          url: 'Skill/PostSkill/',
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
  updateSkill(model) {
    return this.http
      .post(
        environment.api,
        {
          url: 'Skill/UpdateSkill/',
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
  deleteSkill(id) {
    return this.http
      .get(environment.api, {
        url: 'Skill/DeleteSkill/' + id,
        version: '1.0',
      })
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  getSkill(id: number) {
    return this.http
      .get(environment.api, {
        url: 'Skill/GetById/' + id,
        version: '1.0',
      })
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  uploadFile(data) {
    return this.http
      .post(environment.api, {
        url: 'Skill/UploadFile',
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
