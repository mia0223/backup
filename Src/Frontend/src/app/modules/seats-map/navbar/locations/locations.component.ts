import {Component, OnDestroy, OnInit} from '@angular/core';

import {LocationsService} from './locations.service';
import {Location} from 'app/core/models/location';
import {SeatsMapService} from '../../seats-map.service';
import {Utils} from '../../../../core/utils/utils';
import {Subscription} from 'rxjs/Subscription';

@Component({
  selector: '.locations',
  templateUrl: './locations.component.html',
  providers: [LocationsService]
})

export class LocationsComponent implements OnInit, OnDestroy {
  public locations: Location[];
  public selectedLocation: Location;
  private locationIdChanges: Subscription;

  constructor(private locationsService: LocationsService,
              private seatsMapService: SeatsMapService) {
  }

  ngOnInit(): void {
    this.locationsService.getLocations().subscribe(res => {
      //for now we set first item as default
      //TODO: refact this when the logic will be in place.
      if (!!res) {
        this.selectedLocation = res[0];
        this.seatsMapService.notifyLocationIdChanged(this.selectedLocation.id);
      }
      this.locations = res;
      this.locationIdChanges = this.seatsMapService.locationIdChangesObservable.subscribe(id => {
        if (this.locations) {
          this.selectedLocation = this.locations.find(loc => loc.id === id);
        }
      });
    });
  }

  ngOnDestroy(): void {
    Utils.unsubscribeFromObservable(this.locationIdChanges);
  }

  onLocationChange(): void {
    this.seatsMapService.notifyLocationIdChanged(this.selectedLocation.id);
  }
}
