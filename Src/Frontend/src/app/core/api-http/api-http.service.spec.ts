import {TestBed, async} from '@angular/core/testing';
import {ApiHttp} from '../api-http/api-http.service';
import {Http, HttpModule, Request, RequestMethod, Response, ResponseOptions} from '@angular/http';
import {Observable} from 'rxjs/Observable';

let mockHttp = {
  request: () => {
  }
};

describe('ApiHttp service', () => {
  let apiHttp: ApiHttp;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpModule],
      providers: [
        {provide: Http, useValue: mockHttp},
        ApiHttp,

      ]
    });
    mockHttp = TestBed.get(Http);
    apiHttp = TestBed.get(ApiHttp);
  });

  it('should be created', () => {
    expect(apiHttp).toBeTruthy();
  });

  it('should request with method get no options', async(() => {
    spyOn(mockHttp, 'request').and.callFake((req: Request) => {
      expect(req.method).toBe(RequestMethod.Get);
      expect(req.headers.get('Content-Type')).toMatch('application/json');
      expect(req.url).toBe('test');
      return Observable.of(new Response(
        new ResponseOptions(
          {body: {dataReturned: 'anyData'}})));
    });

    apiHttp.get('test').subscribe();

    expect(mockHttp.request).toHaveBeenCalled();
    expect(mockHttp.request).toHaveBeenCalledWith(jasmine.any(Request))
  }));

  it('should request with method get with options', async(() => {
    spyOn(mockHttp, 'request').and.callFake((req: Request) => {
      expect(req.method).toBe(RequestMethod.Get);
      expect(req.headers.get('Content-Type')).toBe('application/json');
      expect(req.withCredentials).toBe(true);
      expect(req.url).toBe('test?testparam=1232&testparam2=987');
      return Observable.of(new Response(
        new ResponseOptions(
          {body: {dataReturned: 'anyData'}})));
    });

    apiHttp.get('test', {withCredentials: true, params: {'testparam': '1232', 'testparam2': '987'}}).subscribe();

    expect(mockHttp.request).toHaveBeenCalled();
    expect(mockHttp.request).toHaveBeenCalledWith(jasmine.any(Request))
  }));

  it('should request with method post no options', async(() => {
    spyOn(mockHttp, 'request').and.callFake((req: Request) => {
      expect(req.method).toBe(RequestMethod.Post);
      expect(req.headers.get('Content-Type')).toMatch('application/json');
      expect(req.url).toBe('test');
      expect(req.getBody()).toBe('This is the message body')
      return Observable.of(new Response(
        new ResponseOptions(
          {body: {dataReturned: 'anyData'}})));
    });

    apiHttp.post('test', 'This is the message body').subscribe();

    expect(mockHttp.request).toHaveBeenCalled();
    expect(mockHttp.request).toHaveBeenCalledWith(jasmine.any(Request))
  }));

  it('should request with method post with options', async(() => {
    spyOn(mockHttp, 'request').and.callFake((req: Request) => {
      expect(req.method).toBe(RequestMethod.Post);
      expect(req.headers.get('Content-Type')).toBe('application/json');
      expect(req.withCredentials).toBe(true);
      expect(req.url).toBe('test?testparam=1232&testparam2=987');
      expect(req.getBody()).toBe('This is the message body')
      return Observable.of(new Response(
        new ResponseOptions(
          {body: {dataReturned: 'anyData'}})));
    });

    apiHttp.post('test', 'This is the message body', {
      withCredentials: true,
      params: {'testparam': '1232', 'testparam2': '987'}
    }).subscribe();

    expect(mockHttp.request).toHaveBeenCalled();
    expect(mockHttp.request).toHaveBeenCalledWith(jasmine.any(Request))
  }));

  it('should request with method put no options', async(() => {
    spyOn(mockHttp, 'request').and.callFake((req: Request) => {
      expect(req.method).toBe(RequestMethod.Put);
      expect(req.headers.get('Content-Type')).toMatch('application/json');
      expect(req.url).toBe('test');
      expect(req.getBody()).toBe('This is the message body')
      return Observable.of(new Response(
        new ResponseOptions(
          {body: {dataReturned: 'anyData'}})));
    });

    apiHttp.put('test', 'This is the message body').subscribe();

    expect(mockHttp.request).toHaveBeenCalled();
    expect(mockHttp.request).toHaveBeenCalledWith(jasmine.any(Request))
  }));

  it('should request with method put with options', async(() => {
    spyOn(mockHttp, 'request').and.callFake((req: Request) => {
      expect(req.method).toBe(RequestMethod.Put);
      expect(req.headers.get('Content-Type')).toBe('application/json');
      expect(req.withCredentials).toBe(true);
      expect(req.url).toBe('test?testparam=1232&testparam2=987');
      expect(req.getBody()).toBe('This is the message body')
      return Observable.of(new Response(
        new ResponseOptions(
          {body: {dataReturned: 'anyData'}})));
    });

    apiHttp.put('test', 'This is the message body', {
      withCredentials: true,
      params: {'testparam': '1232', 'testparam2': '987'}
    }).subscribe();

    expect(mockHttp.request).toHaveBeenCalled();
    expect(mockHttp.request).toHaveBeenCalledWith(jasmine.any(Request))
  }));

})
;
