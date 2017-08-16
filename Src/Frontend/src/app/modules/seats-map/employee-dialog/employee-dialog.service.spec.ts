import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { Response } from '@angular/http';
import { ApiHttp } from 'app/core/api-http/api-http.service';
import { UrlHelper } from 'app/core/web-dal/url-helper.service';
import { Employee } from 'app/core/models/employee';
import { Project } from 'app/core/models/project';
import { Seat } from 'app/core/models/seat';
import { URLSearchParams} from "@angular/http";
import {MdDialog} from "@angular/material";
import {EmployeeDialogService} from "./employee-dialog.service";
import {TestBed} from "@angular/core/testing";

var mockHttpService = {
  get: () => {},
  put: () => {}
};

var mockUrlHelperService = {
  getUrl: () => {}
};

describe('SeatsService', () => {
  let employeeDialogService: EmployeeDialogService;
  let http: ApiHttp;
  let urlHelper: UrlHelper;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        EmployeeDialogService,
        {
          provide: UrlHelper,
          useValue: mockUrlHelperService
        },
        {
          provide: ApiHttp,
          useValue: mockHttpService
        },
      ]});
    http = TestBed.get(ApiHttp);
    urlHelper = TestBed.get(UrlHelper);
    employeeDialogService = TestBed.get(EmployeeDialogService);

    spyOn(urlHelper, 'getUrl').and.callFake(() => {
      return 'test';
    });
    spyOn(http, 'get').and.callFake(() => {
      return {
        map: () => {}
      };
    });

  });

  it('should be created', () => {
    expect(employeeDialogService).toBeTruthy();
  });

  it('should call http get with correct params when method getAllEmployees called', () => {
    employeeDialogService.getAllProjects();
    expect(http.get).toHaveBeenCalledWith('test');
  });

  it('should call http get with correct params when method getSeatByEmployeeId called', () => {
    employeeDialogService.getSeatByEmployeeId(1);
    expect(urlHelper.getUrl).toHaveBeenCalledWith('employeeseat', [{'key': 'id', 'value': 1}]);
    expect(http.get).toHaveBeenCalledWith('test');
  });

  it('should call http put with correct params when method trySaveChanges called', () => {
    const testEmployee = {} as Employee;
    const testProject = {} as Project;
    const testTargetSeat = 1;
    testEmployee.id = 2;
    testProject.id = 3;
    testEmployee.project = testProject;

    const expectedParams = {
      EmployeeId: 2,
      ProjectId: 3,
      TargetSeatNumber: 1,
      FirstTry: true,
    };

    spyOn(http, 'put').and.callThrough();
    employeeDialogService.tryUpdateEmployee(testEmployee, testTargetSeat);
    expect(http.put).toHaveBeenCalledWith('test', JSON.stringify(expectedParams));
  });

  it('should call http put with correct params when method forceSaveChanges called', () => {
    const testEmployee = {} as Employee;
    const testProject = {} as Project;
    const testTargetSeat = 1;
    testEmployee.id = 2;
    testProject.id = 3;
    testEmployee.project = testProject;

    const expectedParams = {
      EmployeeId: 2,
      ProjectId: 3,
      TargetSeatNumber: 1,
      FirstTry: false,
    };

    spyOn(http, 'put').and.callThrough();
    employeeDialogService.forceSaveChanges(testEmployee, testTargetSeat);
    expect(http.put).toHaveBeenCalledWith('test', JSON.stringify(expectedParams));
  });

});


