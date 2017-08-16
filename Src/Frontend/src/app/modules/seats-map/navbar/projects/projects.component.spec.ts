import {TestBed, async, ComponentFixture} from '@angular/core/testing';

import { ProjectsComponent } from './projects.component';

import { SeatsMapService } from "../../seats-map.service";
import {ProjectsService} from "../../../../core/web-dal/projects.service";

describe('ProjectsComponent', () => {
  let fixture: ComponentFixture<ProjectsComponent>;
  let component: ProjectsComponent;

  let mockSeatsMapService = {
    getLocationId: () => {
      return {
        subscribe: (callback: Function) => {
          return false;
        }
      };
    }
  };

  let mockProjectService = {
    getByLocation: (id: number) => {
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
        ProjectsComponent
      ]
    });

    TestBed.overrideComponent(ProjectsComponent,
      {set: {
        template: '<div>ProjectsComponent</div>',
        providers: [
          {
            provide: ProjectsService,
            useValue: mockProjectService
          },
          {
            provide: SeatsMapService,
            useValue: mockSeatsMapService
          }
        ]
      }
    });

    TestBed.compileComponents().then(() => {
      fixture = TestBed.createComponent(ProjectsComponent);
      component = fixture.componentInstance;
    });
  }));

  it('should be initialized', async(() => {
    expect(component).toBeTruthy();
  }));



//   it('should get the list of locations on init', async(() => {
//     // arrange
//     spyOn(component['locationsService'], 'getLocations').and.callThrough();

//     // act
//     component.ngOnInit();

//     // assert
//     expect(component['locationsService'].getLocations).toHaveBeenCalled();
//   }));

//   it('should select first location from the list by default', async(() => {
//     // arrange
//     let locations = getLocationList();
//     spyOn(component['locationsService'], 'getLocations').and.callFake(()=>{
//       return {
//         subscribe: (callback: Function) => {
//           callback(locations)
//         }
//       }
//     });

//     // act
//     component.ngOnInit();

//     // assert
//     expect(component.selectedLocation).toEqual(locations[0]);
//   }));

//   it('should not select default location when the location list is empty', async(() => {
//     // arrange
//     let locations = undefined;
//     spyOn(component['locationsService'], 'getLocations').and.callFake(()=>{
//       return {
//         subscribe: (callback: Function) => {
//           callback(locations)
//         }
//       }
//     });

//     // act
//     component.ngOnInit();

//     // assert
//     expect(component.selectedLocation).toBeUndefined();
//   }));

//   it('should set the locationId to the first location from the list by default', async(() => {
//     // arrange
//     let locations = getLocationList();
//     spyOn(component['locationsService'], 'getLocations').and.callFake(()=>{
//       return {
//         subscribe: (callback: Function) => {
//           callback(locations)
//         }
//       }
//     });
//     spyOn(component['seatsMapService'], 'setLocationId').and.callThrough();

//     // act
//     component.ngOnInit();

//     // assert
//     expect(component.selectedLocation).toEqual(locations[0]);
//     expect(component['seatsMapService'].setLocationId).toHaveBeenCalledWith(locations[0].id);
//   }));

//   it('should initialize the location list', async(() => {
//     // arrange
//     let locations = getLocationList();
//     spyOn(component['locationsService'], 'getLocations').and.callFake(()=>{
//       return {
//         subscribe: (callback: Function) => {
//           callback(locations)
//         }
//       }
//     });

//     // act
//     component.ngOnInit();

//     // assert
//     expect(component.locations).toEqual(locations);
//   }));

//   it('should set locationId onLocationChange', async(() => {
//     // arrange
//     let newLocation = new Location();
//     newLocation.id = 5;
//     component.selectedLocation = newLocation;
//     spyOn(component['seatsMapService'], 'setLocationId').and.callThrough();

//     // act
//     component.onLocationChange();

//     // assert
//     expect(component['seatsMapService'].setLocationId).toHaveBeenCalledWith(newLocation.id);
//   }));
});
