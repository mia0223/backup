import {Component, OnInit, Inject} from '@angular/core'
import {EmployeeDialogBaseComponent} from './employee-dialog.base.component';
import {MD_DIALOG_DATA, MdDialogRef} from '@angular/material';
import {EmployeeDialogService} from './employee-dialog.service';
import {SeatsMapService} from '../seats-map.service';
import {SeatsService} from '../seats/seats.service';
import {Observable} from 'rxjs/Observable';
import {UpdateSeatAction} from '../../../core/models/updateSeatAction';


@Component({
  selector: 'dialog-search-result',
  templateUrl: './employee-dialog.html',
})

export class EmployeeDialogComponent extends EmployeeDialogBaseComponent {
  public seatChanged = false;

  constructor(@Inject(MD_DIALOG_DATA) data: any,
              dialogRef: MdDialogRef<EmployeeDialogBaseComponent>,
              employeeDialogService: EmployeeDialogService,
              private seatsMapService: SeatsMapService,
              seatsService: SeatsService) {
    super(data, dialogRef, employeeDialogService, seatsService);
  }


  ngOnInit(): void {
    super.ngOnInit();

    Observable.forkJoin(
      this.employeeDialogService.getAllProjects(),
      this.employeeDialogService.getSeatByEmployeeId(this.data.id)
    )
      .subscribe(res => {
        this.projects = res[0];
        this.seat = res[1];
        this.targetSeatNumber = String(this.seat.number);
        this.seat.employee.project = this.projects.find(p => p.id === this.seat.employee.project.id);
        this.updateLocation();
      });
  }


  public updateEmployee(): void {
    if (this.seat.transit) this.targetSeatNumber = '9000';
    this.employeeDialogService.tryUpdateEmployee(this.seat.employee, parseInt(this.targetSeatNumber, 10)).subscribe(res => {
      if (res.json().completed) {
        this.updateMap();
        this.dialogRef.close();
        this.updateLocation();
      }else {
        this.employeeToReplace = (res.json().concurrentEmployeeName);
        this.currentState = this.state.confirmation;
      }
    });
  }

  public confirmChanges(): void {
    this.employeeDialogService.forceSaveChanges(this.seat.employee, parseInt(this.targetSeatNumber, 10)).subscribe(res => {
      this.updateMap();
      this.updateLocation();
      this.dialogRef.close();
    });
  }

  public updateMap() {
    const notification = new UpdateSeatAction();
    this.seatsMapService.notifySeatActionExecuted(notification);
  }

  public updateLocation() {
    if (!this.seat.transit) {
      this.seatsMapService.notifyLocationIdChanged(this.seat.locationId);
    }
  }


}
