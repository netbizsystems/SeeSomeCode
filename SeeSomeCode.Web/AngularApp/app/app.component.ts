
import { Component, OnInit } from '@angular/core';
import { ValueService } from './value.service';
import { HttpHelperService } from './httpHelper.service';
import { Value } from './value';

@Component({
  selector: 'my-app',
  template: `
    <h1>SeeSomeCode -- Angular 2</h1>
    <input (click)="hello()" type="button" value="Get All Values">
    <br><br>
    <div *ngFor="let value of values" class="">
      <li>{{value.resourceModelString}}</li>      
    </div>`,
  providers: [ValueService, HttpHelperService]
})
export class AppComponent implements OnInit {

  values: Value[];
  error: any;  

  constructor( private ValueService: ValueService ) {
     //called first time before the ngOnInit()  
  }
  ngOnInit() {  }

  hello() {
    this.ValueService
      .getValues()
      .then( values => this.values = values )
      .catch( error => this.error = error );

    var rows = this.values;
  }
}