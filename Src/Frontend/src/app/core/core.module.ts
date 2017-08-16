import {NgModule, ErrorHandler} from '@angular/core';
import {HttpModule} from '@angular/http';
import {ApiHttp} from './api-http/api-http.service';
import {AppErrorHandler} from './app-error-handler/app-error-handler.service';
import {ConfigManagerService} from './config-management/config-manager.service';
import {UrlHelper} from './web-dal/url-helper.service';
import {VersionComponent} from './components/version/version.component';
import {SeatComponent} from './components/seat/seat.component';
import {CommonModule} from '@angular/common';
import {BrowserModule} from '@angular/platform-browser';
import {DndModule} from 'ng2-dnd';
import {ToasterModule} from 'angular2-toaster';
import {DialogService} from './dialog/dialog.service';
import {WindowRef} from 'app/core/window-reference.service';
import {ProjectsService} from './web-dal/projects.service';
import {EmployeesService} from './web-dal/employees.service';


@NgModule({
  imports: [
    HttpModule,
    CommonModule,
    BrowserModule,
    ToasterModule,
    DndModule.forRoot()
  ],
  declarations: [
    VersionComponent,
    SeatComponent
],
  exports: [
    VersionComponent,
    SeatComponent,
    ToasterModule
  ],
  providers: [
    ApiHttp,
    WindowRef,
    ConfigManagerService,
    DialogService,
    ProjectsService,
    EmployeesService,
    UrlHelper,
    {
      provide: ErrorHandler,
      useClass: AppErrorHandler
    }
  ]
})

export class CoreModule {
}
