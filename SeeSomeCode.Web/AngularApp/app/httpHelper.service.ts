
import { Injectable } from '@angular/core';
import { Response } from '@angular/http';

import 'rxjs/add/operator/toPromise'; 

@Injectable()
export class HttpHelperService {

  constructor() { }

  extractData( res: Response ) {
    let body = res.json();
    return body || { }; // remove .data when going at webapi
  }

}