import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';

import {AppComponent} from './app.component';
import {SimpleObjectComponent} from './simple-object/simple-object.component';
import {BackendAccessService} from './backend-access.service';

import {AppRoutingModule} from './app-routing/app-routing.module';
import {ApplicationStateService} from './application-state.service';
import {LogoutComponent} from './logout/logout.component';
import {LoginComponent} from './login/login.component';
import {AuthGuardService} from './auth-guard.service';

@NgModule({
  declarations: [
    AppComponent,
    SimpleObjectComponent,
    LoginComponent,
    LogoutComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
  ],
  providers: [BackendAccessService, ApplicationStateService, AuthGuardService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
