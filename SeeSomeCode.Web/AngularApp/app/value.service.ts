
import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';

import 'rxjs/add/operator/toPromise'; 

import { Value } from './value';
import { HttpHelperService } from './httpHelper.service';

@Injectable()
export class ValueService {

  private webApiUrl = '/api/values';  // see full url in app.module.ts

  constructor(private http: Http, private httpHelper: HttpHelperService) { }

  getValues() {
    return this.http.get(this.webApiUrl)
      .toPromise()
      .then(this.httpHelper.extractData)
      .catch(this.handleError);
  }

  private handleError(error: any) {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}