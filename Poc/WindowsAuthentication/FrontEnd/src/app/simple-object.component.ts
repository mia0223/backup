import {Component, OnInit, Input} from '@angular/core';
import {ActivatedRoute, Router, Params} from '@angular/router';
import {Location} from '@angular/common';
import {SimpleObject, SimpleObjectService} from './simple-object.service';
import {Observable} from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';

@Component({
  moduleId: module.id,
  selector: 'app-simple-obj',
  template: `
    <div *ngIf="obj">
      <p>Name: {{obj.Name}}</p>
      <p>Age: {{obj.Age}}</p>
    </div>
    <br>
    <button (click)="goBack()">Back</button>
  `
})
/*No longer receive the hero in a parent component property binding. Take parameter
 * from the params Observable in the ActivatedRoute service and use the ComponentService to fetch*/
export class SimpleObjectComponent implements OnInit {
  obj: SimpleObject;

  private name: string;

  constructor(private SimpleObjSer: SimpleObjectService,
              private route: ActivatedRoute,
              // private router: Router,
              private location: Location) {
  }

  ngOnInit(): void {
    this.route.params
      .map(params => params['name'])
      .subscribe(name => {
        this.name = name;
        this.getData();
      });
    // .switchMap((params: Params) => this.SimpleObjSer.getSimpleObject(params['name']))
    // .subscribe(so => this.obj = so);
    // if (!this.obj) {
    //   this.route.params.map((params: Params) => params['name'])
    //     .do(name => this.obj.Name = name)
    //     .subscribe(so => this.obj = so);
    // }
  }

  // how to call backend from angular

  private getData() {
    // service.getdata(this.name);
    this.SimpleObjSer.getSimpleObject(this.name).subscribe(so => this.obj = so);
    // this.obj = this.SimpleObjSer.getSimpleObject(this.name);
  }

  goBack(): void {
    this.location.back();
  }


}
