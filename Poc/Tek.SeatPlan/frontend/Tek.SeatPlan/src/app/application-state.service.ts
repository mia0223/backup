import {Injectable} from '@angular/core';

@Injectable()
export class ApplicationStateService {

  private _token: string;

  public get token(): string {
    return this._token;
  }

  public set token(value: string) {
    this._token = value;
  }

  constructor() {
    this._token = '';
    console.log('New state has been built');
  }

  public get isLoggedIn(): boolean {
    return !!this._token;
  }
}
