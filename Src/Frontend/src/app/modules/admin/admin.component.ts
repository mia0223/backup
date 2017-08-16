import { Component, OnInit } from '@angular/core';
import {MdTabsModule} from '@angular/material';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.scss']
})
export class AdminComponent implements OnInit {
  public navLinks = ""
  constructor() { }

  ngOnInit() {
  }

}
