import {ComponentFixture, TestBed} from "@angular/core/testing";
import {AdminProjectDialogComponent} from "./admin-project-dialog.component";
import {Project} from "../../../../core/models/project";
import {MD_DIALOG_DATA, MdDialogModule, MdDialogRef} from "@angular/material";
import {AdminProjectDialogService} from "./admin-project-dialog.service";
import {AdminService} from "../../admin.service";
import {BrowserModule} from "@angular/platform-browser";
import {CommonModule} from "@angular/common";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NO_ERRORS_SCHEMA} from "@angular/core";
import {Employee} from "../../../../core/models/employee";

let mockMdDialogRef = {
  close() {
  }
};

let mockAdminProjectDialogService = {
  updateProject: () => {},
  createProject: () => {}
};

let mockAdminService = {};

describe('AdminProjectDialogComponent', () => {
  let fixture: ComponentFixture<AdminProjectDialogComponent>;
  let component: AdminProjectDialogComponent;
  let data = {
    project: new Project(),
    isEdit: true
  };
  let mdDialogRef: MdDialogRef<AdminProjectDialogComponent>;
  let adminProjectDialogService: AdminProjectDialogService;
  let adminService: AdminService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [MdDialogModule, BrowserModule, CommonModule, FormsModule, ReactiveFormsModule],
      providers: [
        {
          provide: MdDialogRef,
          useValue: mockMdDialogRef
        },
        {
          provide: AdminProjectDialogService,
          useValue: mockAdminProjectDialogService
        },
        {
          provide: AdminService,
          useValue: mockAdminService
        },
        {
          provide: MD_DIALOG_DATA,
          useValue: data
        }
      ],
      declarations: [AdminProjectDialogComponent],
      schemas: [NO_ERRORS_SCHEMA]
    });

    fixture = TestBed.createComponent(AdminProjectDialogComponent);
    component = fixture.componentInstance;
    mdDialogRef = TestBed.get(MdDialogRef);
    adminProjectDialogService = TestBed.get(AdminProjectDialogService);
    adminService = TestBed.get(AdminService);
    data = TestBed.get(MD_DIALOG_DATA);
  });

  it('should be initialized', () => {
    expect(component).toBeTruthy();
  });

  it('should call createProject of ProjectDialogService and updateProjectList of adminService when save Called in not edit mod',
    () => {
      data.isEdit = false;
      const project = new Project();
      project.technicalServiceManager = 'test, test';
      component.newProject = project;
      spyOn(adminProjectDialogService, 'createProject').and.returnValue({
        subscribe: () => {}
      });
      component.save();
      expect(adminProjectDialogService.createProject).toHaveBeenCalledWith(component.newProject);
    }
  );

  it('should call updateProject of ProjectDialogService and updateProjectList of adminService when save Called in edit mod',
    () => {
      data.isEdit = true;
      const project = new Project();
      project.technicalServiceManager = 'test, test';
      component.newProject = project;
      spyOn(adminProjectDialogService, 'updateProject').and.returnValue({
        subscribe: () => {}
      });
      component.save();
      expect(adminProjectDialogService.updateProject).toHaveBeenCalledWith(component.newProject);
    }
  );
});
