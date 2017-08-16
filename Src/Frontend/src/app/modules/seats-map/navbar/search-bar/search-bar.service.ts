import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Rx';
import {ApiHttp} from 'app/core/api-http/api-http.service';
import {UrlHelper} from 'app/core/web-dal/url-helper.service';

import {Employee} from 'app/core/models/employee';
import {Subject} from 'rxjs/Subject';

@Injectable()
export class SearchBarService {
  // should be inside employee service
  private employeeListStream: Subject<Employee>;
  public employeeListObservable: Observable<Employee>;

  constructor(private http: ApiHttp, private urlHelper: UrlHelper) {
    this.employeeListStream = new Subject<Employee>();
    this.employeeListObservable = this.employeeListStream.asObservable();
  }


  getEmployees(): Observable<Employee[]> {
    return this.http.get(this.urlHelper.getUrl('employee'))
      .map(response => response.json() as Employee[]);
  }

  // should be in employee service
  notifyEmployeeListChanged(employee: Employee) {
    this.employeeListStream.next(employee);
  }
}
