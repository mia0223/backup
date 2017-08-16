import {Employee} from './employee';

export class Seat {
  number: number;
  transit: boolean;
  description: string;
  row: string;
  col: string;
  employee: Employee;
  locationId: number;

  constructor(number: number, transit: boolean, description: string, employee: Employee, row: string, col: string, locationId: number) {
    this.number = number;
    this.transit = transit;
    this.description = description;
    this.employee = employee;
    this.row = row;
    this.col = col;
    this.locationId = locationId;
  }
}

export class TransitSeat extends Seat {
  constructor(seat: Seat) {
    super(seat.number, seat.transit, seat.description, seat.employee, 'auto', 'auto', 1);
  }
}

export class OfficeSeat extends Seat {
  constructor(seat: Seat) {
    super(seat.number, seat.transit, seat.description, seat.employee, seat.row + 'px', seat.col + 'px', seat.locationId);
  }
}
