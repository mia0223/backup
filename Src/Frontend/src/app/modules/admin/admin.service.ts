import { Injectable } from '@angular/core';
import {Subject} from "rxjs/Subject";
import {Observable} from "rxjs/Observable";

@Injectable()
export class AdminService {
  private employeeChangesStream: Subject<number>;
  public employeeChangesObservable: Observable<number>;
  private projectChangesStream: Subject<any>;
  public projectChangesObservable: Observable<any>;

  constructor() {
    this.employeeChangesStream = new Subject<number>();
    this.employeeChangesObservable = this.employeeChangesStream.asObservable();
    this.projectChangesStream = new Subject<any>();
    this.projectChangesObservable = this.projectChangesStream.asObservable();
  }

  updateEmployees() {
    this.employeeChangesStream.next();
  }

  updateProjectList() {
    this.projectChangesStream.next();
  }

}
