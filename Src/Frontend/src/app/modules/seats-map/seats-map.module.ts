import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';
import {
  MaterialModule, MdDialogModule, MdSidenavModule, MdChipsModule, MdCheckboxModule, MdIconModule,
} from '@angular/material';
import {FlexLayoutModule} from '@angular/flex-layout';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {DndModule} from 'ng2-dnd';
import {CoreModule} from 'app/core/core.module';

import {SeatsService} from './seats/seats.service';
import {SeatsMapService} from './seats-map.service';

import {LocationsComponent} from './navbar/locations/locations.component';
import {ProjectsComponent} from './navbar/projects/projects.component';
import {SearchBarComponent} from './navbar/search-bar/search-bar.component';
import {EmployeeDialogComponent} from './employee-dialog/employee-dialog.component';
import {EmailDialogComponent} from './history-log/email-dialog/email-dialog.component';
import {SeatsMapComponent} from './seats-map.component';
import {SeatsComponent} from './seats/seats.component';
import {HistoryLogComponent} from './history-log/history-log.component';
import {EmployeeDialogService} from './employee-dialog/employee-dialog.service';
import {AdminDropdownComponent} from "./navbar/admin-dropdown/admin-dropdown.component";
import {EmailDialogService} from './history-log/email-dialog/email-dialog.service';
import {HistoryLogService} from './history-log/history-log.service';
import {EmailSearchComponent} from './history-log/email-dialog/email-search/email-search.component';
import {AdminProjectDialogComponent} from '../admin/admin-projects/admin-project-dialog/admin-project-dialog.component';
import {AdminEmployeeDialogComponent} from '../admin/admin-employees/admin-employee-dialog/admin-employee-dialog.component';
import {AdminProjectDialogService} from '../admin/admin-projects/admin-project-dialog/admin-project-dialog.service';
import {SearchEmployeeComponent} from '../admin/admin-projects/admin-project-dialog/search-employee/search-employee.component';
import {AdminService} from "../admin/admin.service";
import { TinymceModule } from 'angular2-tinymce';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    MaterialModule,
    MdIconModule,
    MdDialogModule,
    MdSidenavModule,
    MdCheckboxModule,
    BrowserAnimationsModule,
    CoreModule,
    FlexLayoutModule,
    DndModule.forRoot(),
    TinymceModule.withConfig({
      menubar: false,
      statusbar: false,
      content_style: "body { padding-bottom: 0px !important; overflow-y: scroll !important; height:200px; " +
      "margin-right: 0; margin-top: 0; margin-bottom: 0; }",
      toolbar: 'undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | ' +
      'bullist numlist outdent indent | link'
    })
  ],
  declarations: [
    SeatsMapComponent,
    SearchBarComponent,
    EmployeeDialogComponent,
    EmailDialogComponent,
    EmailSearchComponent,
    AdminEmployeeDialogComponent,
    AdminProjectDialogComponent,
    LocationsComponent,
    ProjectsComponent,
    SeatsComponent,
    HistoryLogComponent,
    AdminDropdownComponent,
    SearchEmployeeComponent
  ],
  entryComponents: [
    EmployeeDialogComponent,
    EmailDialogComponent,
    AdminEmployeeDialogComponent,
    AdminProjectDialogComponent
  ],
  providers: [
    SeatsService,
    SeatsMapService,
    HistoryLogService,
    EmployeeDialogService,
    EmailDialogService,
    AdminProjectDialogService,
    AdminService
  ],
})
export class SeatsMapModule {
}
