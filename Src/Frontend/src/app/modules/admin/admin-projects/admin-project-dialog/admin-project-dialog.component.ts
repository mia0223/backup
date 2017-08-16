import {Component, Inject, Input, OnInit} from '@angular/core';
import {MdDialogRef, MD_DIALOG_DATA} from '@angular/material';
import {Project} from '../../../../core/models/project';
import {AdminProjectDialogService} from './admin-project-dialog.service';
import {AdminService} from '../../admin.service';
import * as _ from 'lodash';

@Component({
  selector: 'dialog-create-project',
  templateUrl: './admin-project-dialog.html'
})

export class AdminProjectDialogComponent implements OnInit {
  public newProject;
  public projectList: Project[];
  public acronymChanged = false;
  public validAcronym = true;
  public ManagerChangedBySelect = false;
  public isEdit: boolean;
  public firstName: string;
  public lastName: string;

  constructor(@Inject(MD_DIALOG_DATA) public data: any,
              private dialogRef: MdDialogRef<AdminProjectDialogComponent>,
              private projectDialogService: AdminProjectDialogService,
              private adminService: AdminService) {
  }

  ngOnInit(): void {
    this.projectDialogService.getAllProjects().subscribe(res => {
      this.projectList = res
    });

    if (!this.data.isEdit) {
      this.newProject = new Project();
    }
    else {
      this.newProject = _.cloneDeep(this.data.project);
    }
  }

  acronymChange(): void {
    this.acronymChanged = true;
    this.validAcronym = !this.projectList.some(res => res.name.toLowerCase() === this.newProject.name.toLowerCase());
  }

  ManagerChange(data: any): void {
    if (data.source !== undefined) {
      this.ManagerChangedBySelect = true;
      this.firstName = data.source.value.firstName;
      this.lastName = data.source.value.lastName;
    } else {
      this.newProject.technicalServiceManager = data;
    }
  }

  save(): void {
    if (this.ManagerChangedBySelect)
      this.newProject.technicalServiceManager = this.lastName + ', ' + this.firstName;
    if (this.data.isEdit) {
      this.projectDialogService.updateProject(this.newProject).subscribe(res => {
        this.adminService.updateProjectList();
        this.dialogRef.close();
      });
    }
    else {
      this.projectDialogService.createProject(this.newProject).subscribe(res => {
        this.adminService.updateProjectList();
        this.dialogRef.close();
      });
    }
  }

}
