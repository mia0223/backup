import {Project} from './project';
import {Status} from './status';
import {Seat} from './seat';

export class Employee {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  description: string;
  project: Project;
  status: Status;
  seat: Seat;

  constructor(project: Project, status: Status, seat: Seat) {
    this.id = undefined;
    this.firstName = '';
    this.lastName = '';
    this.email = '';
    this.description = '';
    this.project = project;
    this.status = status;
    this.seat = seat;
  }
}
