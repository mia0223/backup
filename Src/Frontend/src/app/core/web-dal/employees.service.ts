import { Injectable } from '@angular/core';
import {ApiHttp} from '../api-http/api-http.service';
import {UrlHelper} from './url-helper.service';
import {Observable} from 'rxjs/Observable';
import {Employee} from '../models/Employee';
import {Subject} from "rxjs/Subject";

@Injectable()
export class EmployeesService {

  constructor(private http: ApiHttp, private urlHelper: UrlHelper) {}

  getAllEmployees(): Observable<Employee[]> {
    return this.http.get(this.urlHelper.getUrl('employee'))
      .map(response => response.json() as Employee[]);
  }

  deleteEmployee(employeeId: number): Observable<Employee[]> {
    return this.http.delete(this.urlHelper.getUrl('employee', [{'key': 'id', 'value': employeeId}]))
      .map(response => response.json() as Employee[]);
  }

}
