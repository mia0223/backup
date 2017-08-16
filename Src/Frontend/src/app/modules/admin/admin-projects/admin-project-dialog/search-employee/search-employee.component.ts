import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/map';
import {Employee} from 'app/core/models/employee';
import {DialogService} from '../../../../../core/dialog/dialog.service';
import {SearchBarComponent} from '../../../../seats-map/navbar/search-bar/search-bar.component';
import {EmployeesService} from '../../../../../core/web-dal/employees.service';

@Component({
  selector: 'search-employee',
  templateUrl: './search-employee.component.html',
  providers: [DialogService]
})

export class SearchEmployeeComponent extends SearchBarComponent {
  @Input() project: any;
  @Output() employeeChange = new EventEmitter();

  public selectedManager: Employee;

  constructor(employeesService: EmployeesService, dialogService: DialogService) {
    super(employeesService, dialogService);
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.employeesService.getAllEmployees().subscribe(res => {
      this.searchOptions = res;
      this.selectedManager = this.searchOptions.find(m => this.fullName(m) === this.project.technicalServiceManager) ||
        this.project.technicalServiceManager as Employee;
    });
  }

  changeManager(manager: any): void {
    if (manager.source.selected) {
      this.employeeChange.emit(manager);
    }
  }

  sendManager(){
    this.employeeChange.emit(this.selectedManager);
  }

}
