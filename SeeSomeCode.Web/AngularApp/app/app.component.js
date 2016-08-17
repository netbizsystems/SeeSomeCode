"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var value_service_1 = require('./value.service');
var AppComponent = (function () {
    function AppComponent(ValueService) {
        this.ValueService = ValueService;
        //called first time before the ngOnInit()
    }
    AppComponent.prototype.ngOnInit = function () { };
    AppComponent.prototype.hello = function () {
        var _this = this;
        this.ValueService
            .getValues()
            .then(function (values) { return _this.values = values; })
            .catch(function (error) { return _this.error = error; });
        var rows = this.values;
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            template: "\n    <h1>SeeSomeCode -- Angular 2</h1>\n    <input (click)=\"hello()\" type=\"button\" value=\"Get All Values\">\n    <br><br>\n    <div *ngFor=\"let value of values\" class=\"\">\n      <li>{{value.resourceModelString}}</li>      \n    </div>",
            providers: [value_service_1.ValueService]
        }), 
        __metadata('design:paramtypes', [value_service_1.ValueService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map