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

  getAllSkills(){
    return this.http
    .get(environment.api, {
      url: 'Skill/GetAllSkill',
      version: '1.0',
    },false)
    .pipe(
      map((data) => {
        return data;
      })
    );
  }
}
