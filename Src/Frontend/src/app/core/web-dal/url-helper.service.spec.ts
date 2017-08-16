import {TestBed, inject} from '@angular/core/testing';
import {UrlHelper} from 'app/core/web-dal/url-helper.service';
import {ConfigManagerService} from 'app/core/config-management/config-manager.service';
import {WindowRef} from '../window-reference.service';

let mockConfigManagerService = {
  getConfigValue: (v) => {
    if (v === 'test1') {
      return 'http://test1';
    }
    if (v === 'test2') {
      return '%%PROTOCOL%%//test2';
    }
    if (v === 'test3') {
      return 'http://%%DOMAIN%%';
    }
    if (v === 'test4') {
      return '%%PROTOCOL%%//%%DOMAIN%%';
    }
    return '';
  }
};

let mockWindowRef = {
  getWindow: () => {
    return {location: {host: 'hostname', protocol: 'protocol:'}}
  }
};

describe('UrlHelper', () => {
  let urlHelper: UrlHelper;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        UrlHelper,
        {
          provide: ConfigManagerService,
          useValue: mockConfigManagerService
        },
        {
          provide: WindowRef,
          useValue: mockWindowRef
        }
      ]
    });
    mockConfigManagerService = TestBed.get(ConfigManagerService);
    urlHelper = TestBed.get(UrlHelper);
  });

  it('should be created', () => {
    expect(urlHelper).toBeTruthy();
  });

  it('should get simple Url without parameters', () => {
    const returnedUrl = urlHelper.getUrl('test1');
    expect(returnedUrl).toBe('http://test1');
  });

  it('should get simple Url with only one parameter', () => {
    const returnedUrl = urlHelper.getUrl('test1', [{'key': 'id', 'value': 2}]);
    expect(returnedUrl).toBe('http://test1/2');
  });

  it('should get simple Url with more than one parameter', () => {
    const returnedUrl = urlHelper.getUrl('test1', [{'key': 'key1', 'value': 'value1'}, {'key': 'key2', 'value': 2}]);
    expect(returnedUrl).toBe('http://test1?key1=value1&key2=2');
  });

  it('should return Url with substitution for DOMAIN', () => {
    const returnedUrl = urlHelper.getUrl('test2');
    expect(returnedUrl).toBe('protocol://test2');
  });

  it('should return Url with substitution for PROTOCOL', () => {
    const returnedUrl = urlHelper.getUrl('test3');
    expect(returnedUrl).toBe('http://hostname');
  });

  it('should return Url with substitution for PROTOCOL and DOMAIN', () => {
    const returnedUrl = urlHelper.getUrl('test4');
    expect(returnedUrl).toBe('protocol://hostname');
  });

  it('should return Url with substitution for PROTOCOL and DOMAIN and more than one parameter', () => {
    const returnedUrl = urlHelper.getUrl('test4', [{'key': 'key1', 'value': 'value1'}, {'key': 'key2', 'value': 2}]);
    expect(returnedUrl).toBe('protocol://hostname?key1=value1&key2=2');
  });


});
