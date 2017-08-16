import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AdminProjectsComponent} from "./admin-projects/admin-projects.component";
import {AdminEmployeesComponent} from "./admin-employees/admin-employees.component";
import {AdminComponent} from "./admin.component";
import {RouterModule} from "@angular/router";
import {FlexLayoutModule} from "@angular/flex-layout";
import {MaterialModule, MdDialogModule} from "@angular/material";
import {EmployeeDeleteConfirmationDialogComponent} from "./admin-employees/employee-delete-confirmation-dialog/employee-delete-confirmation-dialog.component";
import {AdminService} from "./admin.service";
import { ProjectDeleteConfirmationDialogComponent } from './admin-projects/project-delete-confirmation-dialog/project-delete-confirmation-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FlexLayoutModule,
    MdDialogModule,
    MaterialModule,
  ],
  declarations: [
    AdminEmployeesComponent,
    AdminProjectsComponent,
    EmployeeDeleteConfirmationDialogComponent,
    AdminComponent,
    ProjectDeleteConfirmationDialogComponent
  ],
  providers: [AdminService],
  entryComponents: [
    EmployeeDeleteConfirmationDialogComponent,
    ProjectDeleteConfirmationDialogComponent]
})

export class AdminModule { }
