import {Component, ViewChild} from '@angular/core';
import {MdSidenav} from '@angular/material';

@Component({
    templateUrl: 'seats-map.component.html'
})

export class SeatsMapComponent {
    @ViewChild('historyPanel')
    sidenav: MdSidenav;
}
