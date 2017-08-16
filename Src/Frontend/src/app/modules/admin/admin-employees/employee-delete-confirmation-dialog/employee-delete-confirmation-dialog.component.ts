import {Component, Inject, OnInit} from '@angular/core';
import {MD_DIALOG_DATA, MdDialogRef} from "@angular/material";
import {EmployeesService} from "../../../../core/web-dal/employees.service";
import {AdminService} from "../../admin.service";

@Component({
  selector: 'app-employee-delete-confirmation-dialog',
  templateUrl: './employee-delete-confirmation-dialog.component.html',
  styleUrls: ['./employee-delete-confirmation-dialog.component.scss']
})

export class EmployeeDeleteConfirmationDialogComponent implements OnInit {

  public itemToDelete: any;
  constructor(@Inject(MD_DIALOG_DATA) public data: any, public dialogRef: MdDialogRef<EmployeeDeleteConfirmationDialogComponent>,
              private employeesService: EmployeesService, private adminService: AdminService) {
  }

  ngOnInit() {
    this.itemToDelete = this.data.employee.lastName + ', ' + this.data.employee.firstName;
  }

  public confirmChanges(): void {
    this.employeesService.deleteEmployee(this.data.employee.id).subscribe(res => {
      this.dialogRef.close();
      this.adminService.updateEmployees();
    });
  }

  public cancelConfirmation(): void {
    this.dialogRef.close();
  }

}
