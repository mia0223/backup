import {Component, OnInit} from '@angular/core';
import {ApplicationStateService} from '../application-state.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private appState: ApplicationStateService) {
  }

  ngOnInit() {
    this.appState.token = null;
  }

}
