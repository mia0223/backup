import {Injectable} from '@angular/core';
import {Headers, Http, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import {SimpleObject} from './simple-object.service';
import 'rxjs/add/operator/map';

@Injectable()
export class DataAccessService {
  private headers = new Headers({'Content-Type': 'application/json'});

  constructor(private http: Http) {
  }

  get(): Observable<SimpleObject[]> {
    return this.http.get('/backend/api/SimpleObject').map((res: Response) => res.json() as SimpleObject[]);
  }

  // create(name: string, age: number, seat: number): Observable<SimpleObject> {
  //   this.input.Name = name; this.input.Age = age; this.input.Seat = seat;
  //   return this.http.post('http://localhost:22879/api/SimpleObject', JSON.stringify(this.input))
  //     .map((res: Response) => res.json() as SimpleObject);
  // }

  create(name: string, age: number, seat: number): Observable<SimpleObject> {
    return this.http.post('http://localhost/backend/api/SimpleObject', JSON.stringify({
      Name: name,
      Age: age,
      Seat: seat
    }), {headers: this.headers})
      .map((res: Response) => res.json() as SimpleObject);
  }

  getBySeat(seat: number): Observable<SimpleObject> {
    return this.http.get(`${'http://localhost/backend/api/SimpleObject'}/${seat}`).map((res: Response) => res.json() as SimpleObject);
  }
}
