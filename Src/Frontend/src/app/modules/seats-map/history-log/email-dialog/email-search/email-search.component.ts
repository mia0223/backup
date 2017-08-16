import {Component, Input} from '@angular/core';
import {EmailDialogService} from '../../email-dialog/email-dialog.service';
import {DialogService} from "../../../../../core/dialog/dialog.service";
import {EmployeesService} from "../../../../../core/web-dal/employees.service";
import {SearchBarComponent} from '../../../navbar/search-bar/search-bar.component';

@Component({
    selector: 'email-search-bar',
    templateUrl: 'email-search.component.html'
})
export class EmailSearchComponent extends SearchBarComponent {

    @Input()
    type: string;

    constructor(
        public employeesService: EmployeesService,
        public dialogService: DialogService,
        private emailDialogService: EmailDialogService
    ) {
        super(employeesService, dialogService);
    }

    ngOnInit() {
        super.ngOnInit();
        this.employeesService.getAllEmployees().subscribe(res => this.searchOptions = res);
    }

    onSelectionChange(event: any): void {
        if (event.source.selected) {
            this.emailDialogService.notifyEmailListChanged({
                type: this.type,
                email: event.source.value.email
            });
        }
        this.searchCtrl.reset();
    }
}
