import {Component, OnInit} from '@angular/core';
import {MdDialogRef} from '@angular/material';
import {SeatsMapService} from '../../seats-map.service';
import {HistoryLogService} from '../history-log.service';
import {EmailDialogService} from './email-dialog.service';
import {SeatChangeLog} from '../../../../core/models/seatChangeLog';
import * as _ from 'lodash';
import {EmailTemplate} from "../../../../core/models/email-template.model";

@Component({
  selector: 'email-dialog',
  templateUrl: './email-dialog.component.html'
})

export class EmailDialogComponent implements OnInit{

    public selectedSeatLogList: SeatChangeLog[];
    public emailList;
    public receiverTypes: string[];
    public emailSendDate: string = '';
    public emailContentSection: EmailTemplate;

    constructor(
        public dialogRef: MdDialogRef<EmailDialogComponent>,
        private emailDialogService: EmailDialogService,
        private historyLogService: HistoryLogService,
        private seatsMapService: SeatsMapService
    ) {
      this.emailContentSection = new EmailTemplate();
    }

    ngOnInit() {
        this.selectedSeatLogList = _.values(this.historyLogService.selectedSeatLogList);
        _.remove(this.selectedSeatLogList, (item) => {
            return item.targetSeat.transit;
        });
         this.emailDialogService.getEmailSectionContent().subscribe((data) => {
           this.emailContentSection.contentSection1 = this.decode(data.contentSection1);
           this.emailContentSection.contentSection2 = this.decode(data.contentSection2);
        });
        this.emailDialogService.updateSeatLogSelection(this.selectedSeatLogList).subscribe();
        this.emailList = this.emailDialogService.initializeEmailList(this.selectedSeatLogList);
        this.receiverTypes = _.keys(this.emailList);

        this.emailDialogService.emailToListChangesObservable.subscribe((newItem: any) => {
            this.emailList[newItem.type].push({
                email: newItem.email,
                type: newItem.type
            });
        });
    }

    private decode(value: string): string {
      var elem = document.createElement('textarea');
      elem.innerHTML = value;
      return elem.value;
    }

    removeEmail(deleteEmail: any) {
        _.remove(this.emailList[deleteEmail.type], (item) => {
            return item.email === deleteEmail.email;
        });
    }

    sendEmail() {
        this.emailDialogService.sendEmail(this.emailList, this.selectedSeatLogList, this.emailSendDate, this.emailContentSection).
            subscribe(() => {
                this.seatsMapService.notifyHistoryLogChange();
                this.dialogRef.close();
            });
    }

    closeEmailDialog() {
        this.dialogRef.close();
    }
}
