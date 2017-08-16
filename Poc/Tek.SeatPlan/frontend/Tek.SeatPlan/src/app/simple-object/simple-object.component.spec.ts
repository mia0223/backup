import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SimpleObjectComponent } from './simple-object.component';

describe('SimpleObjectComponent', () => {
  let component: SimpleObjectComponent;
  let fixture: ComponentFixture<SimpleObjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SimpleObjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SimpleObjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
