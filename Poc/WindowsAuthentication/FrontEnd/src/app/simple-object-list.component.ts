import {Component, OnInit} from '@angular/core';
import {SimpleObject} from './simple-object.service';
import 'rxjs/add/operator/map';
import {Observable} from 'rxjs/observable';
import {DataAccessService} from './data-access.service';

@Component({
  selector: 'app-simple-obj-lst',
  template: `<h3> My Objects </h3>
  <table>
    <tr>
      <th>Name</th>
    </tr>
    <tr *ngFor="let SO of SimpleObjList"> <!-- directive-->
      <td><a href="" [routerLink]="['/SimpleObject', SO.Name]">{{SO.Name}}</a></td>
    </tr>
  </table>
  `
})

export class SimpleObjectListComponent implements OnInit {
  SimpleObjList: SimpleObject[];

  constructor(private dataAccessService: DataAccessService) {
  }

  ngOnInit(): void {
    this.getSimpleObject();
  }

  private getSimpleObject() {
    this.dataAccessService.get().subscribe((data: SimpleObject[]) => this.SimpleObjList = data);
  }
}
