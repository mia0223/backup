import { Injectable } from '@angular/core';
import {ApiHttp} from '../api-http/api-http.service';
import {UrlHelper} from './url-helper.service';
import {Observable} from 'rxjs/Observable';
import {Project} from "../models/project";

@Injectable()
export class ProjectsService {

  constructor(private http: ApiHttp, private urlHelper: UrlHelper) { }

  getAllProjects(): Observable<Project[]> {
    return this.http.get(this.urlHelper.getUrl('project'))
      .map(response => response.json() as Project[]);
  }

  getByLocation(id: number): Observable<Project[]> {
    return this.http.get(this.urlHelper.getUrl('projectlocation', [{'key': 'id', 'value': id}]))
      .map(response => response.json() as Project[]);
  }

  deleteProject(id: number): Observable<any> {
    return this.http.delete(this.urlHelper.getUrl('project', [{'key': 'id', 'value': id}]));
  }
}
