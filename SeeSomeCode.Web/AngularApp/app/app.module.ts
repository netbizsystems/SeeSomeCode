
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { BaseRequestOptions, RequestOptions, RequestOptionsArgs} from '@angular/http';

//import { HttpHelperService } from './httpHelper.service';
import { AppComponent }  from './app.component';

class CustomRequestOptions extends BaseRequestOptions {
    merge(options?:RequestOptionsArgs):RequestOptions {
        options.url = 'http://localhost:9000' + options.url;
        var result = super.merge(options);
        result.merge = this.merge;
        return result;
    }
}

@NgModule({
  imports:      [ BrowserModule, HttpModule ],
  declarations: [ AppComponent ],
  bootstrap:    [ AppComponent ], 
  providers:    [ { provide: RequestOptions, useClass: CustomRequestOptions  } ]    
})
export class AppModule { }