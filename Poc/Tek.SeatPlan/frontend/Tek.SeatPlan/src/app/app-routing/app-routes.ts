import {Routes} from '@angular/router';
import {PageNotFoundComponent} from '../page-not-found/page-not-found.component';
import {SimpleObjectComponent} from '../simple-object/simple-object.component';
import {AuthGuardService} from '../auth-guard.service';
import {LoginComponent} from '../login/login.component';
import {LogoutComponent} from '../logout/logout.component';

export const routes: Routes = [
  {path: '', component: SimpleObjectComponent, canActivate: [AuthGuardService]},
  {path: 'login', component: LoginComponent},
  {path: 'logout', component: LogoutComponent},
  {path: '**', component: PageNotFoundComponent}
];


