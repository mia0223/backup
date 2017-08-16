import { Component, OnInit } from '@angular/core';
import {ApplicationStateService} from '../application-state.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private appState: ApplicationStateService) { }

  ngOnInit() {
    this.appState.token = 'bearer <token>';
  }

}
