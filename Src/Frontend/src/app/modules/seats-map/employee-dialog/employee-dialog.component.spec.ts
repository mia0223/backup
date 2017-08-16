import {TestBed, async, ComponentFixture, inject} from '@angular/core/testing';
import {EmployeeDialogComponent} from './employee-dialog.component';
import {SeatsService} from '../seats/seats.service';
import {SeatsMapService} from '../seats-map.service';
import {EmployeeDialogService} from './employee-dialog.service';
import {MD_DIALOG_DATA, MdDialogModule, MdDialogRef} from '@angular/material';
import {Observable} from 'rxjs/Observable';
import {BrowserModule} from '@angular/platform-browser';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {NO_ERRORS_SCHEMA} from '@angular/core';
import {Seat} from '../../../core/models/seat';
import {Employee} from '../../../core/models/employee';

let mockSeatsService = {
  getSeatsData() {
  }
};

let mockSeatsMapService = {
  notifySeatActionExecuted() {
  },
  notifyLocationIdChanged() {
  }
};

let mockEmployeeDialogService = {
  tryUpdateEmployee() {
  },
  forceSaveChanges() {
  },
};

let mockMdDialogRef = {
  close() {
  }
};

describe('EmployeeDialogComponent', () => {
  let fixture: ComponentFixture<EmployeeDialogComponent>;
  let component: EmployeeDialogComponent;
  const data = {
    id: ''
  };
  let seatsService: SeatsService;
  let seatsMapService: SeatsMapService;
  let employeeDialogService: EmployeeDialogService;
  let mdDialogRef: MdDialogRef<EmployeeDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [MdDialogModule, BrowserModule, CommonModule, FormsModule, ReactiveFormsModule],
      providers: [
        {
          provide: SeatsService,
          useValue: mockSeatsService
        },
        {
          provide: SeatsMapService,
          useValue: mockSeatsMapService
        },
        {
          provide: EmployeeDialogService,
          useValue: mockEmployeeDialogService
        },
        {
          provide: MdDialogRef,
          useValue: mockMdDialogRef
        },
        {
          provide: MD_DIALOG_DATA,
          useValue: data
        },
      ],
      declarations: [EmployeeDialogComponent],
      schemas: [NO_ERRORS_SCHEMA]
    });

    fixture = TestBed.createComponent(EmployeeDialogComponent);
    component = fixture.componentInstance;
    seatsMapService = TestBed.get(SeatsMapService);
    seatsService = TestBed.get(SeatsService);
    employeeDialogService = TestBed.get(EmployeeDialogService);
    mdDialogRef = TestBed.get(MdDialogRef);
  });

  it('should be initialized', () => {
    expect(component).toBeTruthy();
  });

  it('should set projectChange to true when projectChange called', () => {
    component.projectChange();
    expect(component.projectChanged).toBeTruthy();
  });

  it('should set seatChange to true when seatChange called', () => {
    component.allSeats = [];
    component.seatChange();
    expect(component.seatChanged).toBeTruthy();
  });

  it('should set validSeat to true when seatChange called and seat exists', async(() => {
    const seat = {} as Seat;
    seat.number = 1;
    component.targetSeatNumber = '1';
    component.allSeats = [];
    component.allSeats.push(seat);
    component.seatChange();
    expect(component.validSeat).toBeTruthy();
  }));

  it('should set validSeat to false when seatChange called and seat does not exist', async(() => {
    const seat = {} as Seat;
    seat.number = 1;
    component.targetSeatNumber = '2';
    component.allSeats = [];
    component.allSeats.push(seat);
    component.seatChange();
    expect(component.validSeat).toBeFalsy();
  }));

  it('should call trySaveChanges method of employeeDialogService with correct parameters when tryUpdateEmployee Called', async(() => {
    const seat = {} as Seat;
    seat.employee = {} as Employee;
    component.seat = seat;
    component.targetSeatNumber = '1';
    const a = new Observable<any>();
    spyOn(employeeDialogService, 'tryUpdateEmployee').and.returnValue({
      subscribe: () => {
        return {}
      }
    });
    component.updateEmployee();
    expect(employeeDialogService.tryUpdateEmployee).toHaveBeenCalledWith(component.seat.employee, parseInt(component.targetSeatNumber, 10));
  }));

  it('should change dialog state to confirmation when tryUpdateEmployee Called and there is employee in target seat', async(() => {
    const seat = {} as Seat;
    seat.employee = {} as Employee;
    component.seat = seat;
    component.targetSeatNumber = '1';

    const returnValue = Observable.of({
      json() {
        const completed = false;
        return {completed}
      }
    });
    spyOn(employeeDialogService, 'tryUpdateEmployee').and.returnValue(returnValue);
    component.updateEmployee();
    expect(component.currentState).toEqual(component.state.confirmation);
  }));

  it('should call updateMap and close dialog when SaveChanges Called and there is no employee in target seat', async(() => {
    const seat = {} as Seat;
    seat.employee = {} as Employee;
    component.seat = seat;
    component.targetSeatNumber = '1';

    const returnValue = Observable.of({
      json() {
        const completed = true;
        return {completed}
      }
    });
    spyOn(employeeDialogService, 'tryUpdateEmployee').and.returnValue(returnValue);
    spyOn(component, 'updateMap').and.callFake(() => {
    });
    spyOn(seatsMapService, 'notifyLocationIdChanged').and.callThrough();
    spyOn(mdDialogRef, 'close').and.callThrough();
    component.updateEmployee();
    expect(component.updateMap).toHaveBeenCalled();
    expect(mdDialogRef.close).toHaveBeenCalled();
  }));

  it('should change dialog state to main when CancelConfirmation Called', async(() => {
    component.cancelConfirmation();
    expect(component.currentState).toEqual(component.state.main);
  }));

  it('should call forceSaveChanges method of employeeDialogService when ConfirmChanges Called', async(() => {
    const seat = {} as Seat;
    seat.employee = {} as Employee;
    component.seat = seat;
    component.targetSeatNumber = '1';
    spyOn(employeeDialogService, 'forceSaveChanges').and.returnValue({
      subscribe: () => {
        return {}
      }
    });
    component.confirmChanges();
    expect(employeeDialogService.forceSaveChanges).toHaveBeenCalledWith(component.seat.employee, parseInt(component.targetSeatNumber, 10));
  }));

  it('should call updateMap and close dialog when ConfirmChanges Called', async(() => {
    const seat = {} as Seat;
    seat.employee = {} as Employee;
    component.seat = seat;
    component.targetSeatNumber = '1';

    const returnValue = Observable.of({
      json() {
        const completed = true;
        return {completed}
      }
    });
    spyOn(employeeDialogService, 'forceSaveChanges').and.returnValue(returnValue);
    spyOn(component, 'updateMap').and.callFake(() => {
    });
    spyOn(seatsMapService, 'notifyLocationIdChanged').and.callThrough();
    spyOn(mdDialogRef, 'close').and.callThrough();
    component.confirmChanges();
    expect(component.updateMap).toHaveBeenCalled();
    expect(mdDialogRef.close).toHaveBeenCalled();
  }));


  it('should call notifySeatActionExecuted method of seatsMapService when updateMap Called', async(() => {
    spyOn(seatsMapService, 'notifySeatActionExecuted').and.callThrough();
    component.updateMap();
    expect(seatsMapService.notifySeatActionExecuted).toHaveBeenCalled();
  }));

});
