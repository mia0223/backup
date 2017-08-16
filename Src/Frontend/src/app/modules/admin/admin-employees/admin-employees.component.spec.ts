import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminEmployeesComponent } from './admin-employees.component';
import {EmployeesService} from "../../../core/web-dal/employees.service";
import {Observable} from "rxjs/Observable";
import {DialogService} from "../../../core/dialog/dialog.service";
import {AdminService} from "../admin.service";


let mockEmployeesService = {
  getAllEmployees(): Observable<any> {
    const a = new Observable<any>();
    return a;
  }
};

let mockDialogService = {};
let mockAdminService = {
  updateEmployees(): Observable<any> {
    const a = new Observable<any>();
    return a;
  },
  employeeChangesObservable: { subscribe() {} }
};


describe('AdminEmployeesComponent', () => {
  let component: AdminEmployeesComponent;
  let fixture: ComponentFixture<AdminEmployeesComponent>;
  let employeesService: EmployeesService;
  let dialogService: DialogService;
  let adminService: AdminService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminEmployeesComponent ],
      providers: [
        {
          provide: EmployeesService,
          useValue: mockEmployeesService
        },
        {
          provide: DialogService,
          useValue: mockDialogService
        },
        {
          provide: AdminService,
          useValue: mockAdminService

        }]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminEmployeesComponent);
    component = fixture.componentInstance;

    employeesService = TestBed.get(EmployeesService);
    dialogService = TestBed.get(DialogService);
    adminService = TestBed.get(AdminService);

    spyOn(employeesService, 'getAllEmployees').and.callFake(() => {
      return {
        subscribe: (cb: Function) => {
          cb(['test']);
        }
      };
    });
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
