import { TestBed, inject } from '@angular/core/testing';
import { SeatsService } from './seats.service';
import { ApiHttp } from "app/core/api-http/api-http.service";
import { UrlHelper } from "app/core/web-dal/url-helper.service";
import { URLSearchParams } from '@angular/http';

var mockHttpService = {
    get: () => {}
};

var mockUrlHelperService = {
    getUrl: () => {}
};

describe('SeatsService', () => {
    let seatsService: SeatsService;
    let http: ApiHttp;
    let urlHelper: UrlHelper;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                SeatsService,
                {
                    provide: UrlHelper,
                    useValue: mockUrlHelperService
                },
                {
                    provide: ApiHttp,
                    useValue: mockHttpService
                }
            ]});
            http = TestBed.get(ApiHttp);
            urlHelper = TestBed.get(UrlHelper);
            seatsService = TestBed.get(SeatsService);

            spyOn(urlHelper, 'getUrl').and.callFake(() => {
                return 'test';
            });

            spyOn(http, 'get').and.callFake(() => {
                return {
                    map: () => {}
                };
            });
    });

    it('should be created', () => {
        expect(seatsService).toBeTruthy();
    });

    it('should call http get with params', () => {
        seatsService.getSeatsData(1);
        expect(http.get).toHaveBeenCalledWith('test');
    })
});
