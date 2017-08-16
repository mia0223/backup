export class Project {
  id: number;
  name: string;
  description: string;
  active: boolean;
  internal: boolean;
  backgroundColor: string;
  foregroundColor: string;
  technicalServiceManager: string;

  constructor() {
    this.id = undefined;
    this.name = '';
    this.description = '';
    this.active = false;
    this.internal = false;
    this.backgroundColor = '';
    this.foregroundColor = '';
    this.technicalServiceManager = '';
  }
}
