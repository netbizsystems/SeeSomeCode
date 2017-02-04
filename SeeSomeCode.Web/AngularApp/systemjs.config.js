
(function (global) {
    System.config({
        paths: {
            // paths serve as alias
            'npm:': 'node_modules/',
            'npmcdn:': 'https://unpkg.com/',
        },
        // map tells the System loader where to look for things
        map: {
            //
            'moment': 'npmcdn:moment@2.14.1/moment.js',

            //
            '@ng-bootstrap/ng-bootstrap': 'npmcdn:@ng-bootstrap/ng-bootstrap@1.0.0-alpha.13/bundles/ng-bootstrap.js',

            // our app is within the app folder
            'app': '/angularapp/app',

            // angular bundles
            '@angular/core': 'npmcdn:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npmcdn:@angular/common/bundles/common.umd.js',
            '@angular/compiler': 'npmcdn:@angular/compiler/bundles/compiler.umd.js',
            '@angular/platform-browser': 'npmcdn:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser-dynamic': 'npmcdn:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/http': 'npmcdn:@angular/http/bundles/http.umd.js',
            '@angular/router': 'npmcdn:@angular/router/bundles/router.umd.js',
            '@angular/forms': 'npmcdn:@angular/forms/bundles/forms.umd.js',

            // other libraries
            'rxjs': 'npmcdn:rxjs',
            'angular2-in-memory-web-api': 'npmcdn:angular2-in-memory-web-api'
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            app: { main: './main.js', defaultExtension: 'js' },
            rxjs: { defaultExtension: 'js' },
            'angular2-in-memory-web-api': { main: './index.js', defaultExtension: 'js' }
        }
    });
})(this);