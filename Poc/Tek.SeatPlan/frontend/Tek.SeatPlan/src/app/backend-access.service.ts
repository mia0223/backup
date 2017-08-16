import {Injectable} from '@angular/core';
import {Http, RequestOptionsArgs, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import {environment} from '../environments/environment';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class BackendAccessService {

  private options: RequestOptionsArgs = {withCredentials: true};

  constructor(private http: Http) {
  }

  public get<T>(apiUrl: string): Observable<T> {
    const fullUrl = environment.baseUrl + apiUrl;
    return this.http.get(fullUrl, this.options).map(this.convertResponse).catch(this.handleError);
  }

  public post<T>(apiUrl: string, body: any): Observable<T> {
    const fullUrl = environment.baseUrl + apiUrl;
    return this.http.post(fullUrl, body.stringify(), this.options).map(this.convertResponse).catch(this.handleError);
  }

  public put<T>(apiUrl: string, body: any): Observable<T> {
    const fullUrl = environment.baseUrl + apiUrl;
    return this.http.put(fullUrl, body.stringify(), this.options).map(this.convertResponse).catch(this.handleError);
  }

  public delete<T>(apiUrl: string): Observable<T> {
    const fullUrl = environment.baseUrl + apiUrl;
    return this.http.delete(fullUrl, this.options).map(this.convertResponse).catch(this.handleError);
  }

  private convertResponse<T>(res: Response): T {
    const body = res.json();
    return body || {};
  }

  private handleError(error: Response | any) {
    // In a real world app, you might use a remote logging infrastructure
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }
}
