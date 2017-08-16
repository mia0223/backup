import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Rx';
import {Response} from '@angular/http';
import {ApiHttp} from 'app/core/api-http/api-http.service';
import {UrlHelper} from 'app/core/web-dal/url-helper.service';
import {Employee} from 'app/core/models/employee';
import {Project} from 'app/core/models/project';
import {Seat} from 'app/core/models/seat';
import {URLSearchParams} from "@angular/http";
import {Status} from "../../../core/models/status";

@Injectable()
export class EmployeeDialogService {
  constructor(private http: ApiHttp, private urlHelper: UrlHelper) {
  }

  getAllProjects(): Observable<Project[]> {
    return this.http.get(this.urlHelper.getUrl('project'))
      .map(response => response.json() as Project[]);
  }

  getSeatByEmployeeId(id: number): Observable<Seat> {
    return this.http.get(this.urlHelper.getUrl('employeeseat', [{'key': 'id', 'value': id}]))
      .map(response => response.json() as Seat);
  }

  getAllStatus(): Observable<Status[]> {
    return this.http.get(this.urlHelper.getUrl('employeestatus')).map(res => res.json() as Status[]);
  }

  tryUpdateEmployee(employee: Employee, seatNumber: number): Observable<Response> {
    const targetData = {
      EmployeeId: employee.id,
      ProjectId: employee.project.id,
      TargetSeatNumber: seatNumber,
      FirstTry: true,
    };
    return this.http.put(this.urlHelper.getUrl('employeeseat'), JSON.stringify(targetData));
  }

  updateEmployee(employee: Employee): Observable<Response> {
    return this.http.put(this.urlHelper.getUrl('employee'), JSON.stringify(employee));
  }

  tryCreateEmployee(employee: Employee): Observable<Response> {
    return this.http.post(this.urlHelper.getUrl('employee'), JSON.stringify(employee));
  }

  forceSaveChanges(employee: Employee, seatNumber: number): Observable<Response> {
    const targetData = {
      EmployeeId: employee.id,
      ProjectId: employee.project.id,
      TargetSeatNumber: seatNumber,
      FirstTry: false,
    };
    return this.http.put(this.urlHelper.getUrl('employeeseat'), JSON.stringify(targetData));
  }

}
