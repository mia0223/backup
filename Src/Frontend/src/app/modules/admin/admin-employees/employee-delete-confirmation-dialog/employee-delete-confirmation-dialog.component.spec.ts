import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeDeleteConfirmationDialogComponent } from './employee-delete-confirmation-dialog.component';
import {MD_DIALOG_DATA, MdDialogRef} from "@angular/material";
import {AdminService} from "../../admin.service";
import {EmployeesService} from "../../../../core/web-dal/employees.service";
import {NO_ERRORS_SCHEMA} from "@angular/core";
import {Employee} from "../../../../core/models/employee";

let mockAdminService = {

};

let mockEmployeesService = {

};

let mockMdDialogRef = {

};

describe('EmployeeDeleteConfirmationDialogComponent', () => {
  let component: EmployeeDeleteConfirmationDialogComponent;
  let fixture: ComponentFixture<EmployeeDeleteConfirmationDialogComponent>;

  const data = {
    employee: {
      firstName: 'Test',
      lastName: 'Employee'
    } as Employee
  };

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeDeleteConfirmationDialogComponent ],
      providers: [
        {
          provide: AdminService,
          useValue: mockAdminService
        },
        {
          provide: EmployeesService,
          useValue: mockEmployeesService
        },
        {
          provide: MdDialogRef,
          useValue: mockMdDialogRef
        },
        {
          provide: MD_DIALOG_DATA,
          useValue: data
        }
      ],
      schemas: [NO_ERRORS_SCHEMA]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeDeleteConfirmationDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
