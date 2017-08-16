import {TestBed, async, ComponentFixture} from '@angular/core/testing';

import {LocationsComponent} from './locations.component';
import {LocationsService} from './locations.service';
import {SeatsMapService} from '../../seats-map.service';
import {Location} from '../../../../core/models/location';
import {Observable} from 'rxjs/Observable';

describe('LocationsComponent', () => {
  let fixture: ComponentFixture<LocationsComponent>;
  let component: LocationsComponent;

  var getLocationList = function () {
    let location1 = new Location();
    location1.id = 1;
    let location2 = new Location();
    location2.id = 2;
    return [location1, location2];
  };

  let mockSeatsMapService = {
    notifyLocationIdChanged: (id) => {
      return {
        subscribe: (callback: Function) => {
          return false;
        }
      };
    },
    locationIdChangesObservable: Observable.of(getLocationList()[0].id)
  };
  let mockLocationsService = {
    getLocations: () => {
      return {
        subscribe: (callback: Function) => {
          return;
        }
      };
    }
  };


  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        LocationsComponent
      ]
    });


    TestBed.overrideComponent(LocationsComponent,
      {
        set: {
          template: '<div>LocationsComponent</div>',
          providers: [
            {
              provide: LocationsService,
              useValue: mockLocationsService
            },
            {
              provide: SeatsMapService,
              useValue: mockSeatsMapService
            }
          ]
        }
      });
    TestBed.compileComponents().then(() => {
      fixture = TestBed.createComponent(LocationsComponent);
      component = fixture.componentInstance;
    });
  }));

  it('should be initialized', async(() => {
    expect(component).toBeTruthy();
  }));

  it('should get the list of locations on init', async(() => {
    // arrange
    spyOn(component['locationsService'], 'getLocations').and.callThrough();

    // act
    component.ngOnInit();

    // assert
    expect(component['locationsService'].getLocations).toHaveBeenCalled();
  }));

  it('should select first location from the list by default', async(() => {
    // arrange
    let locations = getLocationList();
    spyOn(component['locationsService'], 'getLocations').and.callFake(() => {
      return {
        subscribe: (callback: Function) => {
          callback(locations)
        }
      }
    });

    // act
    component.ngOnInit();

    // assert
    expect(component.selectedLocation).toEqual(locations[0]);
  }));

  it('should not select default location when the location list is empty', async(() => {
    // arrange
    let locations = undefined;
    spyOn(component['locationsService'], 'getLocations').and.callFake(() => {
      return {
        subscribe: (callback: Function) => {
          callback(locations)
        }
      }
    });

    // act
    component.ngOnInit();

    // assert
    expect(component.selectedLocation).toBeUndefined();
  }));

  it('should set the locationId to the first location from the list by default', async(() => {
    // arrange
    let locations = getLocationList();
    spyOn(component['locationsService'], 'getLocations').and.callFake(() => {
      return {
        subscribe: (callback: Function) => {
          callback(locations)
        }
      }
    });
    spyOn(component['seatsMapService'], 'notifyLocationIdChanged').and.callThrough();

    // act
    component.ngOnInit();

    // assert
    expect(component.selectedLocation).toEqual(locations[0]);
    expect(component['seatsMapService'].notifyLocationIdChanged).toHaveBeenCalledWith(locations[0].id);
  }));

  it('should initialize the location list', async(() => {
    // arrange
    let locations = getLocationList();
    spyOn(component['locationsService'], 'getLocations').and.callFake(() => {
      return {
        subscribe: (callback: Function) => {
          callback(locations)
        }
      }
    });

    // act
    component.ngOnInit();

    // assert
    expect(component.locations).toEqual(locations);
  }));

  it('should set locationId onLocationChange', async(() => {
    // arrange
    let newLocation = new Location();
    newLocation.id = 5;
    component.selectedLocation = newLocation;
    spyOn(component['seatsMapService'], 'notifyLocationIdChanged').and.callThrough();

    // act
    component.onLocationChange();

    // assert
    expect(component['seatsMapService'].notifyLocationIdChanged).toHaveBeenCalledWith(newLocation.id);
  }));

//   it(`should have as title 'app works!'`, async(() => {
//     const fixture = TestBed.createComponent(AppComponent);
//     const app = fixture.debugElement.componentInstance;
//     expect(app.title).toEqual('app works!');
//   }));

//   it('should render title in a h1 tag', async(() => {
//     const fixture = TestBed.createComponent(AppComponent);
//     fixture.detectChanges();
//     const compiled = fixture.debugElement.nativeElement;
//     expect(compiled.querySelector('h1').textContent).toContain('app works!');
//   }));
});
