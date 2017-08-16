import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {SeatsMapComponent} from './modules/seats-map/seats-map.component';
import {SeatsMapModule} from './modules/seats-map/seats-map.module';
import {adminRoutes} from './modules/admin/admin.routes';
import {AdminComponent} from "./modules/admin/admin.component";

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'seats-map'
  },
  {
    path: 'seats-map',
    component: SeatsMapComponent
  },
  {
    path: 'admin',
    component: AdminComponent,
    children: adminRoutes
  }
  ];

@NgModule({
  imports: [
    SeatsMapModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
