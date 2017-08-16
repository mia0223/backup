import {Component, Inject, OnInit} from '@angular/core';
import {MD_DIALOG_DATA, MdDialogRef} from "@angular/material";
import { ProjectsService } from "app/core/web-dal/projects.service";
import { AdminService } from "app/modules/admin/admin.service";
import { Project } from "app/core/models/project";

@Component({
  selector: 'app-project-delete-confirmation-dialog',
  templateUrl: './project-delete-confirmation-dialog.component.html',
  styleUrls: ['./project-delete-confirmation-dialog.component.scss']
})
export class ProjectDeleteConfirmationDialogComponent implements OnInit {

  public itemToDelete: any;

  constructor( 
      @Inject(MD_DIALOG_DATA) public data: Project, 
      public dialogRef: MdDialogRef<ProjectDeleteConfirmationDialogComponent>,
      private projectsService: ProjectsService, 
      private adminService: AdminService) {
  }

  ngOnInit() {
    this.itemToDelete = this.data.description;
  }

  public confirmChanges(): void {
    this.projectsService.deleteProject(this.data.id).subscribe(res => {
      this.dialogRef.close();
      this.adminService.updateProjectList();
    });
  }

  public cancelConfirmation(): void {
    this.dialogRef.close();
  }

}
