import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Rx';
import {Response} from '@angular/http';
import {ApiHttp} from 'app/core/api-http/api-http.service';
import {UrlHelper} from 'app/core/web-dal/url-helper.service';
import {Employee} from 'app/core/models/employee';
import {Project} from 'app/core/models/project';
import {Seat} from 'app/core/models/seat';


@Injectable()
export class AdminProjectDialogService {
  constructor(private http: ApiHttp, private urlHelper: UrlHelper) {
  }

  getAllProjects(): Observable<Project[]> {
    return this.http.get(this.urlHelper.getUrl('project'))
      .map(response => response.json() as Project[]);
  }

  createProject(project: Project): Observable<Response> {
    return this.http.post(this.urlHelper.getUrl('project'), JSON.stringify(project));
  }

  updateProject(project: Project): Observable<Response> {
    return this.http.put(this.urlHelper.getUrl('project'), JSON.stringify(project));
  }

  getProjectById(id: number): Observable<Project>{
    return this.http.get(this.urlHelper.getUrl('project', [{'key': 'id', 'value': id}])).map(res => res.json() as Project);
  }
}
