import {TestBed, inject, async, fakeAsync, tick} from '@angular/core/testing';
import {UrlHelper} from 'app/core/web-dal/url-helper.service';
import {ConfigManagerService} from 'app/core/config-management/config-manager.service';
import {WindowRef} from '../window-reference.service';
import {ApiHttp} from '../api-http/api-http.service';
import {Observable} from 'rxjs/Observable';
import {Response, ResponseOptions} from '@angular/http';

let mockApiHttp = {
  get: (v) => {
    return Observable.of(new Response(new ResponseOptions({
      body: [{'key': 'key1', 'value': 'value1'}, {'key': 'key2', 'value': 2}]
    })));
  }
};

describe('ConfigManagerService', () => {
  let configManagerService: ConfigManagerService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        ConfigManagerService,
        {
          provide: ApiHttp,
          useValue: mockApiHttp
        }
      ]
    });
    mockApiHttp = TestBed.get(ApiHttp);
    configManagerService = TestBed.get(ConfigManagerService);
  });

  it('should be created', () => {
    expect(configManagerService).toBeTruthy();
    expect(configManagerService.isLoaded()).toBe(false);
  });

  it('should have loaded the configuration', fakeAsync(() => {
    configManagerService.load();
    tick();
    expect(configManagerService.isLoaded()).toBe(true);
  }));

  it('should retrieve value by keys', fakeAsync(() => {
    configManagerService.load();
    tick();
    let value1 = configManagerService.getConfigValue('key1');
    let value2 = configManagerService.getConfigValue('key2');
    expect(value1).toBe('value1');
    expect(value2).toBe(2);
  }));

  it('should return an empty string if the key does not exist', fakeAsync(() => {
    configManagerService.load();
    tick();
    let value = configManagerService.getConfigValue('nonexistentkey');
    expect(value).toBe('');
  }));

});
