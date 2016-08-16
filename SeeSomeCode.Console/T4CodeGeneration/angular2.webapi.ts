
import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';

import { Hero } from '../models/hero';
@Injectable()
export class ValuesService {

  private heroesUrl = 'api/heroes';  // URL to web api
  constructor(private http: Http) {   }

  private extractData(res: Response) {
    let body = res.json();
    return body.data || { }; // remove .data when going at webapi
  }

  private handleError (error: any) {
    // In a real world app, we might use a remote logging infrastructure
    // We'd also dig deeper into the error to get a better message
    let errMsg = (error.message) ? error.message : error.status ? `${error.status} - ${error.statusText}` : 'Server error';
    console.error( errMsg ); // log to console instead
    return Observable.throw(errMsg);
  }

}
import { Hero } from '../models/hero';
@Injectable()
export class MembersService {

  private heroesUrl = 'api/heroes';  // URL to web api
  constructor(private http: Http) {   }

  private extractData(res: Response) {
    let body = res.json();
    return body.data || { }; // remove .data when going at webapi
  }

  private handleError (error: any) {
    // In a real world app, we might use a remote logging infrastructure
    // We'd also dig deeper into the error to get a better message
    let errMsg = (error.message) ? error.message : error.status ? `${error.status} - ${error.statusText}` : 'Server error';
    console.error( errMsg ); // log to console instead
    return Observable.throw(errMsg);
  }

}
 