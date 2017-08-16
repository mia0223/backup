import {Component, OnInit} from '@angular/core';
import {ProjectsService} from '../../../core/web-dal/projects.service';
import {Project} from '../../../core/models/project';
import {DialogService} from '../../../core/dialog/dialog.service';
import {AdminService} from '../admin.service';
import {Employee} from '../../../core/models/employee';


@Component({
  selector: 'app-admin-projects',
  templateUrl: './admin-projects.component.html',
  styleUrls: ['../admin.scss']
})
export class AdminProjectsComponent implements OnInit {
  public projects: Project[];
  public employeList: Employee[];

  constructor(private projectsService: ProjectsService,
              private dialogService: DialogService,
              private adminService: AdminService) {
  }

  ngOnInit() {
    this.adminService.projectChangesObservable.subscribe(res => {
      this.projectsService.getAllProjects().subscribe(projects => {
        this.projects = projects;
      });
    });
    this.adminService.updateProjectList();
  }

  deleteProject(event: Event, project: Project) {
    if (project.description === 'Bench') {
      return;
    }
    event.preventDefault();
    event.stopPropagation();
    this.dialogService.openDeleteProjectConfirmationDialog(project);
  }


  onClickUpdate(event?: any, project?: any): void {

    if (event.target.id === 'delete') {
      return;
    }
    const data = {
      project: project,
      isEdit: true
    };
    this.dialogService.openProjectDialog(data);
  }

  onClickAdd(): void {
    const data = {
      isEdit: false
    }
    this.dialogService.openProjectDialog(data);
  }
}
