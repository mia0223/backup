import {Injectable, OnInit} from '@angular/core';
import {Http, Response} from '@angular/http';
import {DataAccessService} from './data-access.service';
import {Observable} from 'rxjs/Observable';

export class SimpleObject {
  public Name: string;
  public Age: number;
  public Seat: number;
}

@Injectable()
export class SimpleObjectService {
  constructor(private http: Http, private dataAccess: DataAccessService) {
  }

  getSimpleObject(Name: string): Observable<SimpleObject> {
    return this.dataAccess.get()
      .map(objects => objects.find(object => object.Name === Name));
  }

  // createSimpleObject(name: string, age: number, seat: number): SimpleObject {
  //   return this.dataAccess.create(name, age, seat);
  // }


}
