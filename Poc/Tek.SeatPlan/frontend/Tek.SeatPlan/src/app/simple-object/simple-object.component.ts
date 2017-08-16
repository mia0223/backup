import { Component, OnInit } from '@angular/core';
import {SimpleObject} from '../simple-object';
import {BackendAccessService} from '../backend-access.service';

@Component({
  selector: 'app-simple-object',
  templateUrl: './simple-object.component.html',
  styleUrls: ['./simple-object.component.css']
})
export class SimpleObjectComponent implements OnInit {

  data: SimpleObject[] = [];

  constructor(private backEnd: BackendAccessService) {
  }

  ngOnInit(): void {
    this.backEnd.get<SimpleObject[]>('api/SimpleObject').subscribe(d => this.data = d);
  }

}
