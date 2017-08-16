import {Component, OnInit} from '@angular/core';
import {EmployeesService} from "../../../core/web-dal/employees.service";
import {Employee} from "../../../core/models/employee";
import {SeatsMapService} from "../../seats-map/seats-map.service";
import {Router} from "@angular/router";
import {DialogService} from "../../../core/dialog/dialog.service";
import {AdminService} from "../admin.service";


@Component({
  selector: 'app-admin-employees',
  templateUrl: './admin-employees.component.html',
  styleUrls: ['../admin.scss']
})

export class AdminEmployeesComponent implements OnInit {

  public employees: Employee[];

  constructor(
      private employeesService: EmployeesService,
      private dialogService: DialogService,
      private adminService: AdminService
  ) {}

  ngOnInit() {
    this.adminService.employeeChangesObservable.subscribe(res => {
      this.employeesService.getAllEmployees().subscribe(employees => {
        this.employees = employees;
      });
    });
    this.adminService.updateEmployees();
  }

  deleteEmployee(employee: Employee) {
    const data = {employee: employee};
    this.dialogService.openDeleteConfirmationDialog(data);
  }

  onClickUpdate(event?: any, employee?: any): void {
    if (event.target.id === 'delete') {
      return;
    }

    const data = {
      employee: employee,
      isEdit: true
    };
    this.dialogService.openNewEmployeeDialog(data);
  }

  onClickAdd(): void {
    const data = {
      isEdit: false
    }
    this.dialogService.openNewEmployeeDialog(data);
  }


}
