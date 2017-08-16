import {EmployeeDialogBaseComponent} from '../../../seats-map/employee-dialog/employee-dialog.base.component';
import {MD_DIALOG_DATA, MdDialogRef} from '@angular/material';
import {Component, Inject, ViewChild} from '@angular/core';
import {EmployeeDialogService} from '../../../seats-map/employee-dialog/employee-dialog.service';
import {SeatsService} from '../../../seats-map/seats/seats.service';
import {Project} from '../../../../core/models/project';
import {Status} from '../../../../core/models/status';
import {Seat, TransitSeat} from '../../../../core/models/seat';
import {Employee} from '../../../../core/models/employee';
import {AdminService} from '../../admin.service';
import * as _ from 'lodash';
import {EmployeesService} from "../../../../core/web-dal/employees.service";
import {MoveSeatAction} from "../../../../core/models/moveSeatAction";
import {SeatsMapService} from "../../../seats-map/seats-map.service";

@Component({
  selector: 'new-dialog-search-result',
  templateUrl: './admin-employee-dialog.html',
})

export class AdminEmployeeDialogComponent extends EmployeeDialogBaseComponent {
  public status: Status[];
  public employeeList: Employee[];
  public validEmail = true;
  public newEmployee: Employee;
  public isEdit: boolean;
  public transitSeatNumber = 9000;

  constructor(@Inject(MD_DIALOG_DATA) data: any,
              dialogRef: MdDialogRef<EmployeeDialogBaseComponent>,
              employeeDialogService: EmployeeDialogService,
              seatsService: SeatsService,
              private adminService: AdminService,
              private employeesService: EmployeesService,
              private seatsMapService: SeatsMapService) {
    super(data, dialogRef, employeeDialogService, seatsService);
  }


  ngOnInit(): void {
    super.ngOnInit();
    this.currentState = this.state.main;
    this.employeesService.getAllEmployees().subscribe(res => this.employeeList = res);
    if (!this.data.isEdit) {
      const tempProject = new Project();
      const tempStatus = new Status();
      const tempSeat: Seat = {
        number: undefined,
        transit: false,
        description: '',
        employee: null,
        row: undefined,
        col: undefined,
        locationId: undefined
      };
      this.newEmployee = new Employee(tempProject, tempStatus, tempSeat);
    }
    else {
      this.newEmployee = _.cloneDeep(this.data.employee);
      this.targetSeatNumber = '' + this.newEmployee.seat.number;
    }


    this.employeeDialogService.getAllProjects().subscribe(res => {
      this.projects = res;
      if (this.data.isEdit) {
        this.newEmployee.project = this.projects.find(p => p.id === this.data.employee.project.id);
      }
    });

    this.employeeDialogService.getAllStatus().subscribe(res => {
      this.status = res;
      if (!this.data.isEdit) {
        this.newEmployee.status = this.status[0];
      }
      else {
        this.newEmployee.status = this.status.find(s => s.id === this.data.employee.status.id);
      }
    });
  }

  public childSeatChange(): void {
    super.seatChange();
    if (this.validSeat) {
      this.newEmployee.seat = this.allSeats.find(s => s.number === parseInt(this.targetSeatNumber, 10));
    }
  }


  public emailChange(): void {
    this.validEmail = !this.employeeList.find(e => e.email === this.newEmployee.email);
    if (!this.validEmail && this.data.employee.email === this.newEmployee.email)
      this.validEmail = true;
  }

  public createEmployee(): void {
    if (this.newEmployee.seat.employee != null) {
      this.currentState = this.state.confirmation;
      this.employeeToReplace = this.newEmployee.seat.employee.lastName + ', ' + this.newEmployee.seat.employee.firstName;
    } else {
      this.employeeDialogService.tryCreateEmployee(this.newEmployee).subscribe(res => {
        this.adminService.updateEmployees();
        this.dialogRef.close();
      });
    }
  }

  public saveEmployeeChange(): void {
    this.employeeDialogService.updateEmployee(this.newEmployee).subscribe(() => {
      this.adminService.updateEmployees();
      this.dialogRef.close();
    });
  }

  public updateEmployee(): void {
    if (this.seatChanged) {
      if (this.newEmployee.seat.transit) this.targetSeatNumber = '9000';
      this.employeeDialogService.tryUpdateEmployee(this.newEmployee, parseInt(this.targetSeatNumber, 10)).subscribe(res => {
        if (res.json().completed) {
          this.saveEmployeeChange();
        } else {
          this.employeeToReplace = (res.json().concurrentEmployeeName);
          this.currentState = this.state.confirmation;
        }
      });
    } else {
      this.saveEmployeeChange();
    }
  }

  public confirmChanges(): void {
    this.employeeDialogService.forceSaveChanges(this.newEmployee, parseInt(this.targetSeatNumber, 10)).subscribe(res => {
      this.saveEmployeeChange();
    });
  }

  public confirmCreation(): void {
    const moveSeatAction = new MoveSeatAction(parseInt(this.targetSeatNumber, 10), this.transitSeatNumber);
    this.seatsService.changeSeatsData(moveSeatAction).subscribe(res => {
      this.seatsMapService.notifySeatActionExecuted(moveSeatAction);
    });
    this.newEmployee.seat.employee = null;
    this.employeeDialogService.tryCreateEmployee(this.newEmployee).subscribe(res => {
      this.adminService.updateEmployees();
      this.dialogRef.close();
    });
  }

  public cancelConfirmation(): void {
    super.cancelConfirmation();
    if (this.data.isEdit) {
      this.targetSeatNumber = this.data.employee.seat.number;
      this.newEmployee.seat = this.data.employee.seat;
    } else {
      this.seatChanged = false;
      this.targetSeatNumber = undefined;
    }
  }


}
