import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './views/shared/shared.module';
import { ToastrModule } from 'ngx-toastr';
import { HttpService } from './services/http.service';
import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';
import { HttpInterceptadorService } from './services/http-interceptador.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 2000,
      positionClass: "toast-top-full-width",
      preventDuplicates: false,
      closeButton: true,
      enableHtml: true
    })
  ],
  providers: [
    HttpService,
    { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptadorService, multi: true },
    provideHttpClient()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
