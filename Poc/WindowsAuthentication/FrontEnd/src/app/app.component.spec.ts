import {TestBed, async, fakeAsync} from '@angular/core/testing';

import {AppComponent} from './app.component';
import {SimpleObjectComponent} from './simple-object.component';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import {DataAccessService} from './data-access.service';
import {SimpleObjectService} from "./simple-object.service";

describe('AppComponent', () => {
  /*const dataAccessServiceStub = {
   get(): Observable<SimpleObject[]> {
   return Observable.of([<SimpleObject>{Name: 'Ammar', Age: 23}]);
   }
   }*/

  //let fixture;
  const dataAccessServiceStub = jasmine.createSpyObj('DataAccessService', ['get']);

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent
      ],
      providers: [{provide: DataAccessService, useValue: dataAccessServiceStub}]
    });


    dataAccessServiceStub.get.and.returnValue(Observable.of([<SimpleObjectService> {Name: 'Miaaaa', Age: 23}]));
  }));

  it('should create the app', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));

  it(`should have as title 'app works!'`, async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('app works!');
  }));

  it('should render title in a h1 tag', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('app works!');
  }));

  it('should render a table', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    const rows = compiled.querySelectorAll('table > tbody > tr');
    expect(rows.length).toBe(2);
  }));

  // beforeEach(() => {
  //   fixture = TestBed.overrideComponent(AppComponent, {
  //     set: {template: '<span> Hello World </span>'}
  //   }).createComponent(AppComponent);
  // });

  // it('override template', async(() => {
  //
  //   fixture.detectChanges();
  //   //fixture.componentInstance.setMessage('Test message');
  //
  //   const compiled = fixture.debugElement.nativeElement;
  //   expect(compiled.querySelector('span').innerText).toEqual('Hello World');
  // }));
});
