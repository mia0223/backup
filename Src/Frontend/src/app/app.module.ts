import { NgModule,  APP_INITIALIZER } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

import { MaterialModule } from '@angular/material';

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { ConfigManagerService } from "./core/config-management/config-manager.service";
import {AdminModule} from "./modules/admin/admin.module";

export function startupServiceFactory(startupService: ConfigManagerService): Function {
  return () => startupService.load();
}

@NgModule({
    declarations: [AppComponent],
    imports: [
        CommonModule,
        BrowserModule,
        AppRoutingModule,
        CoreModule,
        AdminModule,
        MaterialModule
    ],
    providers: [
      ConfigManagerService,
      {
        provide: APP_INITIALIZER,
        useFactory: startupServiceFactory,
        deps: [ConfigManagerService],
        multi: true
      },
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
