import { ProjectsService} from './projects.service';
import { ApiHttp } from 'app/core/api-http/api-http.service'
import { UrlHelper } from 'app/core/web-dal/url-helper.service'

describe('ProjectsService', () => {
  let service: ProjectsService;
  let http: ApiHttp;
  let urlHelper: UrlHelper

  beforeEach(() => {
    http = {} as ApiHttp;
    urlHelper = {} as UrlHelper;
    service = new ProjectsService(http, urlHelper);
  });

  it('should create subject for projects', () => {
    expect(service).toBeDefined();
  });

  it('should call http to get the list of projects by location', () => {
    // arrange
    var locationId = 22;
    var expectedValue = {};
    http.get = jasmine.createSpy("get").and.returnValue({map: () => {return {}}});
    urlHelper.getUrl = jasmine.createSpy("getUrl").and.returnValue(expectedValue);

    // act
    service.getByLocation(locationId);

    // assert
    expect(urlHelper.getUrl).toHaveBeenCalledWith('projectlocation', [{'key': 'id', 'value': locationId}]);
    expect(http.get).toHaveBeenCalledWith(expectedValue);

  });

  it('should map the result from http', () => {
    // arrange
    var expectedValue = {};
    var mapSpy = jasmine.createSpy("map").and.returnValue({});
    http.get = jasmine.createSpy("get").and.returnValue({map: mapSpy});
    urlHelper.getUrl = jasmine.createSpy("getUrl").and.returnValue(expectedValue);

    // act
    service.getByLocation(22);

    // assert
    expect(mapSpy).toHaveBeenCalled();

  });

});
