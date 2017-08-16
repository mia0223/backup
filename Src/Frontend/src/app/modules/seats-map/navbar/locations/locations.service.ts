import { Injectable } from '@angular/core'
import { Observable } from "rxjs/Rx"
import { Location } from 'app/core/models/location'
import { ApiHttp } from 'app/core/api-http/api-http.service'
import { UrlHelper } from "app/core/web-dal/url-helper.service"

@Injectable()
export class LocationsService {
    constructor(private http: ApiHttp, private urlHelper: UrlHelper) { }

    getLocations(): Observable<Location[]> {
        return this.http.get(this.urlHelper.getUrl('location'))
          .map(response => response.json() as Location[]);
    }
}
