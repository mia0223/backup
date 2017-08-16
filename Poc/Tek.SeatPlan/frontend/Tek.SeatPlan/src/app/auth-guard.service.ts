import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs/Observable';
import {ApplicationStateService} from './application-state.service';

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(private appState: ApplicationStateService) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.appState.isLoggedIn;
  }

}
