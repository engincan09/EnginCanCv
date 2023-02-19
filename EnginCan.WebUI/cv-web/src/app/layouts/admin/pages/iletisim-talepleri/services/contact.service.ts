import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { HttpService } from 'src/app/shared/services/http.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  constructor(private http: HttpService, private router: Router) {}

  getAllContact() {
    return this.http
      .get(
        environment.api,
        {
          url: 'Contact/GetAllContact',
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

  postContact(model) {
    return this.http
      .post(
        environment.api,
        {
          url: 'Contact/PostContact/',
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

  updateContact(model) {
    return this.http
      .post(
        environment.api,
        {
          url: 'Contact/UpdateContact/',
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

  deleteContact(id) {
    return this.http
      .get(
        environment.api,
        {
          url: 'Contact/DeleteContact/' + id,
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

  getContact(id: number) {
    return this.http
      .get(
        environment.api,
        {
          url: 'Contact/GetById/' + id,
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

  postResponse(model) {
    return this.http
      .post(
        environment.api,
        {
          url: 'Contact/PostResponse/',
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
}
