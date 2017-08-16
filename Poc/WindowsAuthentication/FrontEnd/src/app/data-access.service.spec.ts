import {TestBed, inject, fakeAsync} from '@angular/core/testing';
import {DataAccessService} from './data-access.service';
import {
  BaseRequestOptions,
  ConnectionBackend,
  Http,
  HttpModule,
  RequestOptions,
  ResponseOptions,
  Response
} from '@angular/http';
import {MockBackend} from '@angular/http/testing';
import {SimpleObjectComponent} from './simple-object.component';

describe('DataAccessService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpModule],
      providers: [
        {provide: ConnectionBackend, useClass: MockBackend},
        {provide: RequestOptions, useClass: BaseRequestOptions},
        Http,
        DataAccessService
      ]
    });
  });

  it('should ...', fakeAsync(inject([DataAccessService, ConnectionBackend], (service: DataAccessService, be: MockBackend) => {
    const body = {body: [<SimpleObjectComponent>{Name: 'Ammar', Age: 22}]};
    be.connections.subscribe(connection => connection.mockRespond(
      new Response(
        new ResponseOptions(
          body))));


    let so: SimpleObjectComponent[];

    service.get().subscribe(data => so = data);
    expect(so.length).toBe(1);
    expect(service).toBeTruthy();
  })));

  it('equal result', fakeAsync(inject([DataAccessService, ConnectionBackend], (service: DataAccessService, backend: MockBackend) => {
    const body = {body: [<SimpleObjectComponent>{Name: 'Mia', Age: 22}]};
    backend.connections.subscribe(connection => connection.mockRespond(
      new Response(
        new ResponseOptions(body))
    ));

    const result: SimpleObjectComponent = {Name: 'Mia', Age: 22};
    let SO: SimpleObjectComponent[];
    service.get().subscribe(data => SO = data);
    const outcome = SO.pop();
    expect(outcome).toEqual(result);
    expect(service).toBeTruthy();
  })));
});
