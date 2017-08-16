import {Component, OnInit, OnDestroy, Input} from '@angular/core';
import {MdSidenav} from '@angular/material';
import {SeatChangeLogGroup} from '../../../core/models/seatChangeLogGroup';
import {DialogService} from '../../../core/dialog/dialog.service';
import {HistoryLogService} from './history-log.service';
import {SeatsMapService} from '../seats-map.service';
import {HistoryLogConstant} from './history-log.constant';
import {Utils} from '../../../core/utils/utils';
import * as _ from 'lodash';

@Component({
    selector: 'history-log',
    templateUrl: 'history-log.component.html'
})

export class HistoryLogComponent implements OnInit {

    private seatChangeLogSubscription;
    public isSelectAll: boolean;

    @Input()
    historyPanel: MdSidenav;
    seatChangelogData: SeatChangeLogGroup[];
    constructor(
        private historyLogService: HistoryLogService,
        private seatsMapService: SeatsMapService,
        private dialogService: DialogService
    ) {}

    ngOnInit() {
        this.loadSeatChangeLog();
        this.seatChangeLogSubscription = this.seatsMapService.seatActionsObservable.subscribe(() => {
            this.loadSeatChangeLog();
            this.historyLogService.selectedSeatLogList = {};
            this.isSelectAll = false;
        });
        this.seatsMapService.historyLogChangesObservable.subscribe(() => {
            this.loadSeatChangeLog();
        });
        this.isSelectAll = false;
    }

    ngOnDestroy(): void {
      Utils.unsubscribeFromObservable(this.seatChangeLogSubscription);
    }

    loadSeatChangeLog() {
        this.historyLogService.getSeatChangeLog().subscribe((data) => {
            this.seatChangelogData = _.reverse(data);
        });
    }

    closeHistoryPanel() {
        this.historyPanel.close();
    }

    onSeatLogSelect(moveAction) {
        this.historyLogService.updateSelectedSeatLog(moveAction);
    }

    toggleAll() {
        let isSelectAll = this.isSelectAll;
        _.forEach(this.seatChangelogData, (seatChangeLogGroup) => {
            _.forEach(seatChangeLogGroup.seatChangeLog, (seatChangeItem) => {
                seatChangeItem.selected = isSelectAll;
                this.historyLogService.updateSelectedSeatLog(seatChangeItem);
            });
        });
    }

    openEmailDialog() {
        let config = HistoryLogConstant.EMAIL_DIALOG_CONFIG;
        this.dialogService.openEmailDialog(config);
    }
}
