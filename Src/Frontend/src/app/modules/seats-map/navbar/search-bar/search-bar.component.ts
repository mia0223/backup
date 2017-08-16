import {Component, OnInit} from '@angular/core';
import {FormControl} from '@angular/forms';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/map';
import {Employee} from 'app/core/models/employee';
import {EmployeesService} from "../../../../core/web-dal/employees.service";
import {DialogService} from "../../../../core/dialog/dialog.service";

@Component({
  selector: '.search-bar',
  templateUrl: 'search-bar.component.html',
  providers: [DialogService]
})

export class SearchBarComponent implements OnInit {

  public searchOptions: Employee[];
  public searchCtrl: FormControl;
  public optionCtrl: FormControl;
  public filteredOptions: any;

  constructor(public employeesService: EmployeesService, public dialogService: DialogService) {
  }

  ngOnInit(): void {
    this.searchCtrl = new FormControl();
    this.filteredOptions = this.searchCtrl.valueChanges
      .map(selected => {
        if (selected && typeof(selected) === 'object')
          return this.fullName(selected);
        else
          return selected;
      })
      .map(val => this.filterNames(val));
    this.employeesService.getAllEmployees().subscribe(res => {
      this.searchOptions = res;
    });
  }

  filterNames(val: string) {
    return val ? this.searchOptions.filter(s => this.fullName(s).toLowerCase().indexOf(val.toLowerCase()) !== -1)
      : this.searchOptions;
  }

  fullName(empl: Employee): string {
    if (empl && !empl.firstName) {
      return '' + empl;
    }
    return empl ? empl.lastName + ', ' + empl.firstName : '';
  }

  onSelectionChange(event: any): void {
    if (event.isUserInput) {
      const data = {
        id: event.source.value.id
      };
      this.dialogService.openEmployeeDialog(data);
    }
  }

}
