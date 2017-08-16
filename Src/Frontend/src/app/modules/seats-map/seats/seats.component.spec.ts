import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';

import { SeatsComponent } from './seats.component';
import { SeatsMapService } from '../seats-map.service';
import { SeatsService } from './seats.service';
import {LAYOUTSETTINGS} from './seats.constant';
import {Subscription} from 'rxjs/Subscription';
import {Seat} from "../../../core/models/seat";
import {SeatAction} from "../../../core/models/seatAction";
import {MoveSeatAction} from "../../../core/models/moveSeatAction";
import {Observable} from "rxjs/Observable";

var mockSeatsMapService = {
  locationIdChangesObservable: {
      subscribe: (cb: Function) => {
        cb(1);
    }
  },
  seatActionsObservable: {
    subscribe: (cb: Function) => {
      cb(1);
    }
  },
  notifySeatActionExecuted() {
  },
  notifyLocationIdChanged() {
  }
};

var mockSeatsService = {
  getSeatsData: () => {
  },
  changeSeatsData: () => {

  },
  refreshSeatsData: () => {
  },
  seatsDataSubject: {
    subscribe: () => {}
  }
};

describe('SeatsComponent', () => {
    let fixture: ComponentFixture<SeatsComponent>;
    let component: SeatsComponent;
    let seatsMapService: SeatsMapService;
    let seatsService: SeatsService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [{
                provide: SeatsMapService,
                useValue: mockSeatsMapService
            }, {
                provide: SeatsService,
                useValue: mockSeatsService
            }],
            declarations: [SeatsComponent],
            schemas: [NO_ERRORS_SCHEMA]
        });

        fixture = TestBed.createComponent(SeatsComponent);
        component = fixture.componentInstance;
        seatsMapService = TestBed.get(SeatsMapService);
        seatsService = TestBed.get(SeatsService);

        spyOn(seatsService, 'getSeatsData').and.callFake(() => {
            return {
                subscribe: (cb: Function) => {
                    cb('test');
                }
            };
        });
    });

    it('should be defined', () => {
        expect(component).toBeTruthy();
    });

  it('should set transitseatsdata and seatsdata correctly', async(() => {
    let data = [{transit : false}, {transit: true, employee: {status: {id: 2}}}];
    component.fillSeats(data);
    expect(component.transitSeatsData.length).toEqual(1);
    expect(component.seatsData.length).toEqual(1);
  }));

  it('should have correct value for inTransitOccupied', async(() => {
    let data = [{transit: true, employee: {status: {id: 2}}}, {transit: true, employee: null}];
    component.fillSeats(data);
    expect(component.inTransitOccupied).toEqual(1);
  }));

  it('should initialize with in transit area collapsed', async(() => {

    spyOn(seatsMapService.locationIdChangesObservable, 'subscribe').and.callFake((cb: Function) => {  });
    spyOn(seatsMapService.seatActionsObservable, 'subscribe').and.callFake((cb: Function) => {  });

    component.ngOnInit();
    expect(component.layoutSetting).toEqual(LAYOUTSETTINGS[1]);
    expect(component.currentStateIndex).toEqual(1);
  }));

  it('should toggle layoutSetting and transit area should show when toggleInTransitView called once', async(() => {

    spyOn(seatsMapService.locationIdChangesObservable, 'subscribe').and.callFake((cb: Function) => {  });
    spyOn(seatsMapService.seatActionsObservable, 'subscribe').and.callFake((cb: Function) => {  });

    component.ngOnInit();
    component.toggleInTransitView();
    expect(component.layoutSetting).toEqual(LAYOUTSETTINGS[0]);
    expect(component.currentStateIndex).toEqual(0);
  }));

  it('should load seats when locationId changes', async(() => {
    // arrange
    let selectedLocationId = 55;
    spyOn(component, 'loadSeats').and.callFake(()=>{});
    spyOn(seatsMapService.locationIdChangesObservable, 'subscribe').and.callFake((cb: Function) => { cb(selectedLocationId) });
    spyOn(seatsMapService.seatActionsObservable, 'subscribe').and.callFake((cb: Function) => {  });

    // act
    component.ngOnInit();

    // assert
    expect(component.loadSeats).toHaveBeenCalledWith(selectedLocationId);
  }));

  it('should reload seats when seatAction executed', async(() => {
    // arrange
    let executedSeatAction = new SeatAction();
    spyOn(component, 'reloadSeats').and.callFake(()=>{});
    spyOn(seatsMapService.locationIdChangesObservable, 'subscribe').and.callFake((cb: Function) => {  });
    spyOn(seatsMapService.seatActionsObservable, 'subscribe').and.callFake((cb: Function) => { cb(executedSeatAction) });

    // act
    component.ngOnInit();

    // assert
    expect(component.reloadSeats).toHaveBeenCalled();
  }));

  it('should reload seats for current location when seatAction executed', async(() => {
    // arrange
    let executedSeatAction = new SeatAction();
    component['currentLocationId'] = 55;
    spyOn(component, 'loadSeats').and.callFake(()=>{});
    spyOn(seatsMapService.locationIdChangesObservable, 'subscribe').and.callFake((cb: Function) => {  });
    spyOn(seatsMapService.seatActionsObservable, 'subscribe').and.callFake((cb: Function) => { cb(executedSeatAction) });

    // act
    component.ngOnInit();

    // assert
    expect(component.loadSeats).toHaveBeenCalledWith(component['currentLocationId']);
  }));

  it('should call method changeSeatsData of seatsService with correct params when onTransitDropSuccess executed', async(() => {
    // arrange
    let testEvent = {
      dragData: {number: 1}
    };

    spyOn(seatsService, 'changeSeatsData').and.returnValue({
      subscribe: () => {
        return {}
      }
    });
    spyOn(seatsMapService, 'notifySeatActionExecuted').and.callThrough();
    const expectedMoveSeatAction = new MoveSeatAction(testEvent.dragData.number, component.transitSeatNumber);

    // act
    component.onTransitDropSuccess(testEvent);

    // assert
    expect(seatsService.changeSeatsData).toHaveBeenCalledWith(expectedMoveSeatAction);
  }));



});
