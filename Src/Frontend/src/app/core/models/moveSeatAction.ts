import {SeatAction} from "./seatAction";
export class MoveSeatAction extends SeatAction{
  sourceSeatNumber: number;
  targetSeatNumber: number;

  constructor(sourceSeatNumber, targetSeatNumber){
    super();
    this.sourceSeatNumber = sourceSeatNumber;
    this.targetSeatNumber = targetSeatNumber;
  }
}
