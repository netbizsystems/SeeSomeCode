
import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';

import 'rxjs/add/operator/toPromise'; 

import { Value } from './value';

@Injectable()
export class ValueService {

  private webApiUrl = '/api/values';  // see full url in app.module.ts

  constructor(private http: Http) { }

  getValues() {
    return this.http.get(this.webApiUrl)
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  private extractData( res: Response ) {
    let body = res.json();
    return body || { }; // remove .data when going at webapi
  }

  private handleError(error: any) {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}