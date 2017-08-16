import {Injectable} from '@angular/core';


@Injectable()
export class WindowRef {
  public getWindow(): any {
    return window;
  }
}
