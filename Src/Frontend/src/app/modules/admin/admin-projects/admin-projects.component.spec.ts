import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminProjectsComponent } from './admin-projects.component';
import {ProjectsService} from "../../../core/web-dal/projects.service";
import {DialogService} from "../../../core/dialog/dialog.service";
import {AdminService} from '../admin.service';

let mockProjectsService = {
  getAllProjects(){}
};

let mockAdminService = {
    projectChangesObservable: { subscribe() {} },
    updateProjectList: () => {}
};

describe('AdminProjectsComponent', () => {
  let component: AdminProjectsComponent;
  let fixture: ComponentFixture<AdminProjectsComponent>;
  let projectsService: ProjectsService;
  let adminService: AdminService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminProjectsComponent ],
      providers: [
        {
          provide: ProjectsService,
          useValue: mockProjectsService
        },
        {
          provide: DialogService
        },
        {
          provide: AdminService,
          useValue: mockAdminService
        }],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminProjectsComponent);
    component = fixture.componentInstance;
    projectsService = TestBed.get(ProjectsService);
    adminService = TestBed.get(AdminService);

    spyOn(projectsService, 'getAllProjects').and.callFake(() => {
      return {
        subscribe: (cb: Function) => {
          cb(['test']);
        }
      };
    });
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
