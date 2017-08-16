import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {Subject} from 'rxjs/Subject';
import {SeatAction} from '../../core/models/seatAction';
import {Employee} from "../../core/models/employee";

@Injectable()
export class SeatsMapService {
  private locationIdChangesStream: Subject<number>;
  public locationIdChangesObservable: Observable<number>;
  private seatActionsStream: Subject<SeatAction>;
  public seatActionsObservable: Observable<SeatAction>;
  private historyLogChangesStream: Subject<any>;
  public historyLogChangesObservable: Observable<any>;

  private currentLocationId;

  constructor() {
    this.locationIdChangesStream = new Subject<number>();
    this.locationIdChangesObservable = this.locationIdChangesStream.asObservable();
    this.seatActionsStream = new Subject<SeatAction>();
    this.seatActionsObservable = this.seatActionsStream.asObservable();
    this.historyLogChangesStream = new Subject<any>();
    this.historyLogChangesObservable = this.historyLogChangesStream.asObservable();
  }

  notifySeatActionExecuted(seatAction: SeatAction) {
    this.seatActionsStream.next(seatAction);
  }

  notifyLocationIdChanged(id: number) {
    this.currentLocationId = id;
    this.locationIdChangesStream.next(id);
  }

  notifyHistoryLogChange() {
    this.historyLogChangesStream.next();
  }

  loadMostRecentLocation() {
    if (this.currentLocationId) {
      this.locationIdChangesStream.next(this.currentLocationId);
    }
  }
}
