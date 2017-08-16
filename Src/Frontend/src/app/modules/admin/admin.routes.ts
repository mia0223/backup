import {Routes} from "@angular/router";

import {AdminEmployeesComponent} from "./admin-employees/admin-employees.component";
import {AdminProjectsComponent} from "./admin-projects/admin-projects.component";
import {AdminEmployeeDialogComponent} from "./admin-employees/admin-employee-dialog/admin-employee-dialog.component";

export const adminRoutes: Routes = [
  {
    path: 'employees',
    component: AdminEmployeesComponent,
  },
  {
    path: 'projects',
    component: AdminProjectsComponent
  }
];
