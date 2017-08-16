import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PageNotFoundComponent } from './../page-not-found/page-not-found.component';
import {RouterModule} from '@angular/router';
import {routes} from './app-routes';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  declarations: [PageNotFoundComponent],
})
export class AppRoutingModule { }
