
import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ValuesService {

  private webApiUrl = '/api/Values';  // see full url in app.module.ts
  constructor(private http: Http) {   }

	getValues() {
		return this.http.get(this.webApiUrl)
		  .toPromise()
		  .then(this.extractData)
		  .catch(this.handleError);
  }

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

@Injectable()
export class MembersService {

  private webApiUrl = '/api/Members';  // see full url in app.module.ts
  constructor(private http: Http) {   }

	getMembers() {
		return this.http.get(this.webApiUrl)
		  .toPromise()
		  .then(this.extractData)
		  .catch(this.handleError);
  }

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

 