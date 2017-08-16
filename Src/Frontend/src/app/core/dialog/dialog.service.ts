import { Injectable } from '@angular/core';
import { EmployeeDialogComponent } from '../../modules/seats-map/employee-dialog/employee-dialog.component';
import { EmailDialogComponent } from '../../modules/seats-map/history-log/email-dialog/email-dialog.component';
import { MdDialog } from "@angular/material";
import { EmployeeDeleteConfirmationDialogComponent } from "../../modules/admin/admin-employees/employee-delete-confirmation-dialog/employee-delete-confirmation-dialog.component";
import {AdminProjectDialogComponent} from "../../modules/admin/admin-projects/admin-project-dialog/admin-project-dialog.component";
import { ProjectDeleteConfirmationDialogComponent } from "../../modules/admin/admin-projects/project-delete-confirmation-dialog/project-delete-confirmation-dialog.component";
import {AdminEmployeeDialogComponent} from "../../modules/admin/admin-employees/admin-employee-dialog/admin-employee-dialog.component";


@Injectable()
export class DialogService {

  constructor(public dialog: MdDialog) {
  }

  openEmployeeDialog(data: any) {
    this.dialog.open(EmployeeDialogComponent, {
      data: data
    });
  }

  openNewEmployeeDialog(data: any) {
    this.dialog.open(AdminEmployeeDialogComponent, {
      data: data
    });
  }

  openProjectDialog(data: any) {
    this.dialog.open(AdminProjectDialogComponent, {
      data: data
    });
  }

  openEmailDialog(config: any) {
    this.dialog.open(EmailDialogComponent, config);
  }

  openDeleteConfirmationDialog(data: any) {
    this.dialog.open(EmployeeDeleteConfirmationDialogComponent, {
      data: data
    });
  }

  openDeleteProjectConfirmationDialog(data: any) {
    this.dialog.open(ProjectDeleteConfirmationDialogComponent, {
      data: data
    });
  }

}
