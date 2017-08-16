import { TestBed, ComponentFixture } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';

import { SeatComponent } from './seat.component';
import { SeatsMapService } from '../../../modules/seats-map/seats-map.service';
import {SeatsService} from '../../../modules/seats-map/seats/seats.service';
import {Seat, TransitSeat} from '../../models/seat';
import {Employee} from "../../models/employee";
import {DialogService} from "../../dialog/dialog.service";
import {HistoryLogService} from "../../../modules/seats-map/history-log/history-log.service";

var mockSeatsMapService = {};
var mockSeatsService = {};
var mockDialogService = {
  openEmployeeDialog: (inputs: any) =>{
  }
};
var mockHistoryLogService = {
  getSeatChangeLog: () => {
    return {
      subscribe: (cb: Function) => {
        cb([1, 2]);
      }
    };
  }
};

var seat: Seat;

describe('SeatComponent', () => {
    let fixture: ComponentFixture<SeatComponent>;
    let component: SeatComponent;
    let seatsMapService: SeatsMapService;
    let dialogService: DialogService;
    let historyLogService: HistoryLogService;


    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [{
                provide: SeatsMapService,
                useValue: mockSeatsMapService
              },
              {
                provide: DialogService,
                useValue: mockDialogService
              },
              {
                provide: SeatsService,
                useValue: mockSeatsService
              },
              {
                provide: HistoryLogService,
                useValue: mockHistoryLogService
              }],
            declarations: [SeatComponent],
            schemas: [NO_ERRORS_SCHEMA]
        });

        fixture = TestBed.createComponent(SeatComponent);
        component = fixture.componentInstance;
        seatsMapService = TestBed.get(SeatsMapService);
        dialogService = TestBed.get(DialogService);
        historyLogService = TestBed.get(HistoryLogService);
        this.seat = {} as Seat;
    });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });

  it('should assign top and left seat coordinates if not in-transit seat', () => {
    this.seat.transit = false;
    this.seat.row = '15px';
    this.seat.col = '15px';
    component.item = this.seat;
    component.ngOnInit();
    expect(component.top).toEqual('15px');
    expect(component.left).toEqual('15px');
  });

  it('should get correct color for project', () => {
    const expectedProject = {
      id: 1,
      name: '',
      description: '',
      active: true,
      internal: false,
      backgroundColor: '#E9E7E1',
      foregroundColor: ''
    };

    const employee = {
      project: expectedProject,
      id: 1,
      firstName: '',
      lastName: '',
      email: '',
      description: '',
    };
    this.seat.employee = employee;
    component.item = this.seat;
    const result = component.getProject();
    expect(result).toEqual(expectedProject);
  });

  it('should return empty seat if no employee', () => {
    this.seat.employee = null;
    component.item = this.seat;
    const result = component.isEmptySeat();
    expect(result).toBeTruthy();
  });

  it('should set top and left seat coordinates to auto if in-transit seat', () => {
    this.seat.row = 'auto';
    this.seat.col = 'auto';
    this.seat.transit = true;
    component.item = this.seat;
    component.ngOnInit();
    expect(component.top).toEqual('auto');
    expect(component.left).toEqual('auto');
  });

  it('should open dialog when dialogOpen is called', () => {
    var employee = {} as Employee;
    employee.id = 1;
    this.seat.employee = employee;
    component.item = this.seat;
    spyOn(dialogService, 'openEmployeeDialog').and.callThrough();
    component.openDialog(null);
    expect(dialogService.openEmployeeDialog).toHaveBeenCalled();
  });
});
