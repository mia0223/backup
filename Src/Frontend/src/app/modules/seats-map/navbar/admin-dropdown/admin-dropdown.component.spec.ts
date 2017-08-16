import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminDropdownComponent } from './admin-dropdown.component';
import {MaterialModule} from "@angular/material";

describe('AdminDropdownComponent', () => {
  let component: AdminDropdownComponent;
  let fixture: ComponentFixture<AdminDropdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminDropdownComponent ],
      imports: [MaterialModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
