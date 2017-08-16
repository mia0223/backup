import { Injectable } from '@angular/core'
import { Observable } from "rxjs/Rx";
import { ApiHttp } from 'app/core/api-http/api-http.service'
import { UrlHelper } from 'app/core/web-dal/url-helper.service'

@Injectable()
export class VersionService {
    constructor(private http: ApiHttp, private urlHelper: UrlHelper) { }

    getVersion(): Observable<any> {
        return this.http.get(this.urlHelper.getUrl('version'));
    }
}
