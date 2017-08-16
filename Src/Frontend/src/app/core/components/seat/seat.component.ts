import {Component, Input, OnInit, OnDestroy} from '@angular/core';
import {SeatsService} from '../../../modules/seats-map/seats/seats.service';
import * as _ from 'lodash';
import {MoveSeatAction} from "../../models/moveSeatAction";
import {SeatsMapService} from "../../../modules/seats-map/seats-map.service";
import {Seat} from "../../models/seat";
import {Utils} from "../../utils/utils";
import {DialogService} from "../../dialog/dialog.service";

@Component({
    selector: 'app-seat',
    templateUrl: './seat.component.html'
})
export class SeatComponent implements OnInit, OnDestroy {
  @Input() item: Seat;
  top: string;
  left: string;
  private changeSeatsDataSubscription;

  constructor(
      private seatsService: SeatsService,
      private seatsMapService: SeatsMapService,
      private dialogService: DialogService
  ) { }

  ngOnInit() {
    this.setSeatCoordinates()
  }

  ngOnDestroy(): void {
    Utils.unsubscribeFromObservable(this.changeSeatsDataSubscription);
  }

  setSeatCoordinates() {
      this.top = this.item.col;
      this.left = this.item.row;
  }

  getProject() {
    return this.item.employee.project;
  }

  isEmptySeat() {
    return _.isNull(this.item.employee);
  }

  onDropSuccess(event) {
    if (event.dragData.number !== this.item.number) {
      let moveSeatAction = new MoveSeatAction(event.dragData.number, this.item.number);
      this.changeSeatsDataSubscription = this.seatsService.changeSeatsData(moveSeatAction).subscribe(() => {
        this.seatsMapService.notifySeatActionExecuted(moveSeatAction);
      });
      if (event.dragData.transit) {
        this.seatsMapService.notifyLocationIdChanged(this.item.locationId);
      }
    }
  }

  openDialog(event: any): void {
    const id = this.item.employee.id;
    if (id) {
      const data = {
        id: id
      };
      this.dialogService.openEmployeeDialog(data);
    }
  }

}
