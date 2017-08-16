import {Component, OnInit, OnDestroy} from '@angular/core';
import {SeatsService} from './seats.service';
import {LAYOUTSETTINGS} from './seats.constant';
import {OfficeSeat, TransitSeat} from "../../../core/models/seat";
import {SeatsMapService} from "../seats-map.service";
import {Utils} from "../../../core/utils/utils";
import {MoveSeatAction} from "../../../core/models/moveSeatAction";

@Component({
  selector: 'app-seats',
  templateUrl: 'seats.component.html'
})
export class SeatsComponent implements  OnInit, OnDestroy {

  seatsData: any;
  transitSeatsData: any;
  inTransitOccupied: number;
  currentStateIndex: number;
  layoutSetting: any;
  private currentLocationId;
  private locationIdChangesStreamubscription;
  private seatActionsStreamSubscription;
  private seatsDataSubscription;
  private changeSeatsDataSubscription;
  public transitSeatNumber = 9000;

  constructor(private seatsService: SeatsService, private seatsMapService: SeatsMapService) {
  }

  ngOnInit() {
    this.currentStateIndex = 1;
    this.layoutSetting = LAYOUTSETTINGS[this.currentStateIndex];
    this.locationIdChangesStreamubscription = this.seatsMapService.locationIdChangesObservable.subscribe(id => {
      this.loadSeats(id);
    });
    this.seatActionsStreamSubscription = this.seatsMapService.seatActionsObservable.subscribe(seatAction => {
      this.reloadSeats();
    });
  }

  ngOnDestroy(): void {
    Utils.unsubscribeFromObservable(this.locationIdChangesStreamubscription);
    Utils.unsubscribeFromObservable(this.seatActionsStreamSubscription);
    Utils.unsubscribeFromObservable(this.seatsDataSubscription);
  }

  fillSeats(seats: any) {
    this.seatsData = seats.filter(seat => !seat.transit).map(seat => seat = new OfficeSeat(seat));
    this.transitSeatsData = seats.filter(seat => (seat.transit && seat.employee != null && seat.employee.status.id !== 3))
      .map(seat => seat = new TransitSeat(seat));
    this.inTransitOccupied = this.transitSeatsData.filter(seat => seat.employee != null).length;
  }

  toggleInTransitView() {
    this.layoutSetting = LAYOUTSETTINGS[1 - this.currentStateIndex];
    this.currentStateIndex = 1 - this.currentStateIndex;
  }

  loadSeats(locationId) {
    this.currentLocationId = locationId;
    this.seatsDataSubscription = this.seatsService.getSeatsData(locationId).subscribe(data => {
      this.fillSeats(data);
    })
  }

  reloadSeats() {
    this.loadSeats(this.currentLocationId);
  }

  onTransitDropSuccess(event) {
    if (event.dragData.transit) {
      return;
    }
    const moveSeatAction = new MoveSeatAction(event.dragData.number, this.transitSeatNumber);
    this.changeSeatsDataSubscription = this.seatsService.changeSeatsData(moveSeatAction).subscribe(() => {
      this.seatsMapService.notifySeatActionExecuted(moveSeatAction);
    });
    this.seatsMapService.notifyLocationIdChanged(event.dragData.locationId);
  }
}
