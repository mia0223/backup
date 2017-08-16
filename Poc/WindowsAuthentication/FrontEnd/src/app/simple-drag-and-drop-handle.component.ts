/**
 * Created by chewang on 5/29/2017.
 */
import {Component, OnInit} from '@angular/core';
import {SimpleObject} from './simple-object.service';
import {DataAccessService} from './data-access.service';

@Component({
  selector: 'app-simple-dnd-handle',
  template: `
    <h4>Simple Drag-and-Drop with handle</h4>
    <div class="row">
      <div class="col-sm-3">
        <div class="panel panel-success">
          <div class="panel-heading">Available to drag</div>
          <div class="panel-body">
            <div *ngFor="let SO of simpleDrop" class="panel panel-default" dnd-draggable
                 [dragEnabled]="true" [dragData]="SO">
              <div class="panel-body">
                <div>Name: {{SO.Name}}<br>
                  Seat: {{SO.Seat}}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-sm-3">
        <div dnd-droppable class="panel panel-info" (onDropSuccess)="receivedSimpleObject($event)">
          <div class="panel-heading">Place to drop</div>
          <div class="panel-body">
            <div *ngFor="let obj of received" class="panel panel-default">
              <div class="panel-body">
                Name: {{obj.Name}}<br>
                Seat: {{obj.Seat}}<br>
                Age: {{obj.Age}}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  `
})

export class SimpleDndHandleComponent implements OnInit {
  simpleDrop: SimpleObject[];
  received: Array<SimpleObject> = [];

  constructor(private DataAccess: DataAccessService) {
  }

  ngOnInit(): void {
    this.getSimpleObjectList();
  }

  getSimpleObjectList(): void {
    this.DataAccess.get().subscribe((data: SimpleObject[]) => this.simpleDrop = data);
  }

  receivedSimpleObject($event: any) {
    const obj: SimpleObject = $event.dragData;
    // console.log(obj);
    // console.log(this.received.length);
    this.received.push(obj);
  }
}
