import { Injectable } from '@angular/core';
import { ApiHttp } from 'app/core/api-http/api-http.service';
import { UrlHelper } from 'app/core/web-dal/url-helper.service';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { HistoryLogConstant } from '../history-log.constant';
import { SeatChangeLog } from '../../../../core/models/seatChangeLog';
import { ConfigManagerService } from '../../../../core/config-management/config-manager.service';
import * as _ from 'lodash';
import {EmailTemplate} from "../../../../core/models/email-template.model";

@Injectable()
export class EmailDialogService {
    private emailToListChangesStream: Subject<any>;
    public emailToListChangesObservable: Observable<any>;

    constructor(
        private http: ApiHttp,
        private urlHelper: UrlHelper,
        private configManagerService: ConfigManagerService
    ) {
        this.emailToListChangesStream = new Subject<any>();
        this.emailToListChangesObservable = this.emailToListChangesStream.asObservable();
    }

    initializeEmailList(selectedSeatLogList: SeatChangeLog[]) {
        let emailList = _.cloneDeep(this.configManagerService.getConfigValue('defaultemailreceiver'));
        _.forEach(selectedSeatLogList, (item) => {
            emailList.to.push({
                email: item.employee.email,
                type: HistoryLogConstant.RECEIVER_TYPE.TO
            });
        });
        return emailList;
    }

    updateSeatLogSelection(updatedSeatLogSelection) {
        return this.http.put(this.urlHelper.getUrl('email'), updatedSeatLogSelection);
    }

    sendEmail(emailList, selectedSeatLogList, emailSendDate, emailContentSection: EmailTemplate) {
        let requestBody = this.getReqeustBody(emailList, selectedSeatLogList, emailSendDate, emailContentSection);
        return this.http.post(this.urlHelper.getUrl('email'), JSON.stringify(requestBody));
    }

    notifyEmailListChanged(newItem) {
        this.emailToListChangesStream.next(newItem);
    }

    getEmailSectionContent() {
      return this.http.get(this.urlHelper.getUrl('emailtemplate'))
        .map(res => res.json() as EmailTemplate);
    }

    private getReqeustBody(emailList, selectedSeatLogList, emailSendDate, emailContentSection: EmailTemplate) {
        return {
            to: this.generateToListString(emailList.to),
            cc: this.generateCcListString(emailList.cc),
            moveDate: emailSendDate,
            contentSection1: emailContentSection.contentSection1,
            contentSection2: emailContentSection.contentSection2,
            seatChangeLog: selectedSeatLogList
        };
    }

    private generateToListString(to) {
        return this.convertListToString(to);
    }

    private generateCcListString(cc) {
        return this.convertListToString(cc);
    }

    private convertListToString(list) {
        let result = '';
        _.forEach(list, (item) => {
            result += item.email + ';';
        });
        return result.replace(/;\s*$/, "");
    }
}
