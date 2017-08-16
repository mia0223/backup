import { Injectable } from '@angular/core';
import { SeatChangeLogGroup } from '../../../core/models/seatChangeLogGroup'
import { ApiHttp } from 'app/core/api-http/api-http.service';
import { UrlHelper } from "app/core/web-dal/url-helper.service";

@Injectable()
export class HistoryLogService {

    selectedSeatLogList: any;

    constructor(
        private http: ApiHttp,
        private urlHelper: UrlHelper
    ) {
        this.selectedSeatLogList = {};
    }

    getSeatChangeLog() {
        return this.http.get(this.urlHelper.getUrl('seatchangelog'))
            .map(res => res.json() as SeatChangeLogGroup[]);
    }

    updateSelectedSeatLog(moveAction) {
        if (moveAction.selected && !this.selectedSeatLogList[moveAction.id]) {
            this.selectedSeatLogList[moveAction.id] = moveAction;
        }
        if (!moveAction.selected && this.selectedSeatLogList[moveAction.id]) {
            delete this.selectedSeatLogList[moveAction.id];
        }
    }
}
