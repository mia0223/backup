import {Employee} from './employee';
import {Seat} from './seat';

export class SeatChangeLog {
    employee: Employee;
    selected: boolean;
    sourceSeat: Seat;
    targetSeat: Seat;
}
