import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';

import { HistoryLogComponent } from './history-log.component';
import { HistoryLogService } from './history-log.service';
import { SeatsMapService } from '../seats-map.service';
import { DialogService } from '../../../core/dialog/dialog.service';
import { SeatChangeLogGroup } from "../../../core/models/seatChangeLogGroup";

var mockHistoryLogService = {
    getSeatChangeLog: () => {
        return {
            subscribe: (cb: Function) => {
                cb([1, 2]);
            }
        };
    }
};

var mockSeatsMapService = {
    seatActionsObservable: {
        subscribe: (cb: Function) => {
            cb();
        }
    },
    historyLogChangesObservable: {
        subscribe: (cb: Function) => {
            cb();
        }
    }
};

var mockialogService = {};

describe('HistoryLogComponent', () => {
    let fixture: ComponentFixture<HistoryLogComponent>;
    let component: HistoryLogComponent;
    let historyLogService: HistoryLogService;
    let seatsMapService: SeatsMapService;
    let dialogService: DialogService;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [HistoryLogComponent],
            schemas: [NO_ERRORS_SCHEMA]
        });

        TestBed.overrideComponent(HistoryLogComponent, {
            set: {
                providers: [{
                    provide: HistoryLogService,
                    useValue: mockHistoryLogService
                }, {
                    provide: SeatsMapService,
                    useValue: mockSeatsMapService
                }, {
                    provide: DialogService,
                    useValue: mockialogService
                }]
            }
        });

        TestBed.compileComponents().then(() => {
            fixture = TestBed.createComponent(HistoryLogComponent);
            component = fixture.componentInstance;
        });
    }));

    it('should be defined', () => {
        expect(component).toBeTruthy();
    });

    it('should load seat change log data on init', () => {
        component.ngOnInit();
        expect(component.seatChangelogData).toEqual([2, 1]);
    });

    it('should load seat change log data', () => {
        component.loadSeatChangeLog();
        expect(component.seatChangelogData).toEqual([2, 1]);
    });
});
