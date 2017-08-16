import {Component, Input, OnInit} from '@angular/core';
import {SimpleObject, SimpleObjectService} from './simple-object.service';
import {DataAccessService} from './data-access.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-add-simple-object',
  template: `
    <h3 *ngIf="soName.value && soSeat.value">My New Simple Object Name Is --- {{soName.value}} With Seat Number --- {{soSeat.value}}</h3>
    <br>
    <label>Name: </label>
    <input #soName/>
    <br>
    <label>Age: </label>
    <input #soAge/>
    <br>
    <label>Seat: </label>
    <input #soSeat/>
    <br>
    <button (click)="save(soName.value, soAge.value, soSeat.value)" href="/SimpleObjectList" (click)="refresh(soSeat.value)">Save</button>
  `
})

export class AddSimpleObjectComponent implements OnInit {
  SO: SimpleObject;

  constructor(private route: ActivatedRoute,
              private SimpleObjectService: SimpleObjectService,
              private DataAccessService: DataAccessService) {
  }

  ngOnInit(): void {
  }

  save(name: string, age: number, seat: number): void {
    name = name.trim(); // remove white space from both sides of a string
    if (!name || age < 0 || seat < 0) {
      return;
    }
    // console.log(name)
    this.DataAccessService.create(name, age, seat).subscribe((data: SimpleObject) => this.SO = data);
  }

  // refresh(seat: number): void {
  //   this.DataAccessService.getBySeat(seat).subscribe((data: SimpleObject) => this.SO = data);
  // }
}

