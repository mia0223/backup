import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AdminEmployeeDialogComponent} from './admin-employee-dialog.component';
import {Project} from '../../../../core/models/project';
import {Status} from '../../../../core/models/status';
import {Employee} from '../../../../core/models/employee';
import {MD_DIALOG_DATA, MdDialogModule, MdDialogRef} from '@angular/material';
import {EmployeeDialogService} from '../../../seats-map/employee-dialog/employee-dialog.service';
import {SeatsService} from '../../../seats-map/seats/seats.service';
import {AdminService} from '../../admin.service';
import {EmployeesService} from '../../../../core/web-dal/employees.service';
import {BrowserModule} from '@angular/platform-browser';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {NO_ERRORS_SCHEMA} from '@angular/core';
import {Seat} from '../../../../core/models/seat';
import {MoveSeatAction} from "../../../../core/models/moveSeatAction";
import {SeatsMapService} from "../../../seats-map/seats-map.service";

let mockMdDialogRef = {
  close() {
  }
};

let mockEmployeeDialogService = {
  tryCreateEmployee: () => {
  },
  updateEmployee() {
  }
};

let mockSeatsService = {};

let mockAdminService = {
  updateEmployee() {
  }
};

let mockEmployeesService = {
  getAllEmployees() {
  }
};

let mockSeatsMapService = {
  notifySeatActionExecuted(moveSeatAction: MoveSeatAction) {
  }
};

describe('AdminEmployeeDialogComponent', () => {
  let fixture: ComponentFixture<AdminEmployeeDialogComponent>;
  let component: AdminEmployeeDialogComponent;
  const tempProject = new Project();
  const tempStatus = new Status();

  const data = {
    employee: new Employee(tempProject, tempStatus, null),
    isEdit: true
  };
  let mdDialogRef: MdDialogRef<AdminEmployeeDialogComponent>;
  let employeeDialogService: EmployeeDialogService;
  let seatsService: SeatsService;
  let adminService: AdminService;
  let employeesService: EmployeesService;
  let seatsMapService: SeatsMapService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [MdDialogModule, BrowserModule, CommonModule, FormsModule, ReactiveFormsModule],
      providers: [
        {
          provide: MdDialogRef,
          useValue: mockMdDialogRef
        },
        {
          provide: EmployeeDialogService,
          useValue: mockEmployeeDialogService
        },
        {
          provide: SeatsService,
          useValue: mockSeatsService
        },
        {
          provide: AdminService,
          useVlaue: mockAdminService
        },
        {
          provide: EmployeesService,
          useValue: mockEmployeesService
        },
        {
          provide: MD_DIALOG_DATA,
          useValue: data
        },
        {
          provide: SeatsMapService,
          value: mockSeatsMapService
        }
      ],
      declarations: [AdminEmployeeDialogComponent],
      schemas: [NO_ERRORS_SCHEMA]
    });

    fixture = TestBed.createComponent(AdminEmployeeDialogComponent);
    component = fixture.componentInstance;
    mdDialogRef = TestBed.get(MdDialogRef);
    employeeDialogService = TestBed.get(EmployeeDialogService);
    seatsService = TestBed.get(SeatsService);
    adminService = TestBed.get(AdminService);
    employeesService = TestBed.get(EmployeesService);
    seatsMapService = TestBed.get(SeatsMapService);
  });

  it('should be initialized', () => {
    expect(component).toBeTruthy();
  });

  it('should call tryCreateEmployee of employeeDialogService with correct parameter when createEmployee Called and the target seat is empty',
    () => {
      const seat = {} as Seat;
      seat.employee = null;
      seat.number = 1;
      const employee = {seat: seat} as Employee;
      component.targetSeatNumber = '1';
      component.newEmployee = employee;
      spyOn(employeeDialogService, 'tryCreateEmployee').and.returnValue({
        subscribe: () => {
        }
      });
      component.createEmployee();
      expect(employeeDialogService.tryCreateEmployee).toHaveBeenCalledWith(component.newEmployee);
    });

  it('should call updateEmployee of employeeDialogService with correct parameter when updateEmployee Called and the target seat is empty',
    () => {
      const seat = {} as Seat;
      seat.employee = null;
      seat.number = 1;
      const employee = {seat: seat} as Employee;
      component.targetSeatNumber = '1';
      component.newEmployee = employee;
      spyOn(employeeDialogService, 'updateEmployee').and.returnValue({
        subscribe: () => {
        }
      });
      component.updateEmployee();
      expect(employeeDialogService.updateEmployee).toHaveBeenCalledWith(component.newEmployee);
    });

  it('should change dialog state to confirmation and assign employeeToReplace when createEmployee Called and the target seat is not empty',
    () => {
      const seat = {} as Seat;
      const tempEmployee = {firstName: 'test', lastName: 'test'} as Employee;
      seat.employee = tempEmployee;
      seat.number = 1;
      const employee = {seat: seat} as Employee;
      component.targetSeatNumber = '1';
      component.newEmployee = employee;
      component.createEmployee();
      expect(component.currentState).toEqual(component.state.confirmation);
      expect(component.employeeToReplace).toEqual('test, test');
    });
});
