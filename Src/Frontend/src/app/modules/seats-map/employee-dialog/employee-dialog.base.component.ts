import {Project} from 'app/core/models/project';
import {Seat} from 'app/core/models/seat';
import {MdDialogRef} from '@angular/material';
import {EmployeeDialogComponent} from './employee-dialog.component';
import {EmployeeDialogService} from './employee-dialog.service';
import {SeatsService} from '../seats/seats.service';
import {OnInit} from "@angular/core";
import {Employee} from "../../../core/models/employee";
import {UpdateSeatAction} from "../../../core/models/updateSeatAction";
import {SeatsMapService} from "../seats-map.service";
export enum State {
  main,
  confirmation,
}
export class EmployeeDialogBaseComponent implements OnInit {

  public projects: Project[];
  public seat: Seat;
  public projectChanged = false;
  public seatChanged = false;
  public employeeToReplace: string;
  public targetSeatNumber: string;
  public validSeat = true;
  public state = State;
  public currentState: any;
  public allSeats: Seat[];
  public data: any;
  public dialogRef: MdDialogRef<EmployeeDialogBaseComponent>;
  public employeeDialogService: EmployeeDialogService;
  public seatsService: SeatsService;


  constructor(data: any,
              dialogRef: MdDialogRef<EmployeeDialogBaseComponent>,
              employeeDialogService: EmployeeDialogService,
              seatsService: SeatsService) {
    this.data = data;
    this.dialogRef = dialogRef;
    this.employeeDialogService = employeeDialogService;
    this.seatsService = seatsService;
  }

  ngOnInit(): void {
    this.currentState = this.state.main;
    this.seatsService.getSeatsData(0).subscribe(res => {
      this.allSeats = res.filter(seat => !seat.transit)
    });
  }

  public projectChange(): void {
    this.projectChanged = true;
  }

  public seatChange(): void {
    this.seatChanged = true;
    this.validSeat = this.allSeats.some(res => res.number === parseInt(this.targetSeatNumber, 10));
  }

  public selectTransit(seat: Seat): void {
    if (parseInt(this.targetSeatNumber, 10) >= 9000) {
      seat.number = undefined;
      this.targetSeatNumber = undefined;
    }
    this.seatChange();
    if (seat.transit)
      this.validSeat = true;
  }


  public confirmChanges(employee: Employee): void {
    this.employeeDialogService.forceSaveChanges(employee, parseInt(this.targetSeatNumber, 10)).subscribe(res => {
      this.dialogRef.close();
    });
  }

  public InputBoxUnderlineColor(): string {
    return this.validSeat ? 'primary' : 'warn';
  }

  public cancelConfirmation(): void {
    this.currentState = this.state.main;
  }
}
