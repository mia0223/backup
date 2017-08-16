import { Injectable } from '@angular/core';
import { URLSearchParams } from '@angular/http';
import { Subject } from 'rxjs/Subject';
import { ApiHttp } from 'app/core/api-http/api-http.service';
import { Seat } from 'app/core/models/seat';
import { UrlHelper } from "app/core/web-dal/url-helper.service";

@Injectable()
export class SeatsService {

    constructor(
        private http: ApiHttp,
        private urlHelper: UrlHelper
    ) {}

    getSeatsData(locationId) {
        return this.http.get(this.urlHelper.getUrl('seatlocation', [{'key': 'id', 'value': locationId}]))
            .map(res => res.json() as Seat[]);
    }

    changeSeatsData(changedSeats) {
        return this.http.post(this.urlHelper.getUrl('seat'), changedSeats);
    }
}
