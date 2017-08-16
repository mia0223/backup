import { TestBed, inject } from '@angular/core/testing';
import {MdDialog} from "@angular/material";
import { DialogService } from './dialog.service';

var mockMdDialog = {
  open: (dialogComponent: any, inputs: any) =>
  {
  }
};

describe('DialogService', () => {
  let mdDialog: MdDialog;
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        DialogService,
        {
          provide: MdDialog,
          useValue: mockMdDialog
        },
      ]
    });
    mdDialog = TestBed.get(MdDialog);
  });

  it('should be created', inject([DialogService], (service: DialogService) => {
    expect(service).toBeTruthy();
  }));

  it('should open dialog when openEmployeeDialog called', inject([DialogService], (service: DialogService) => {
    spyOn(mdDialog, 'open').and.callThrough();
    service.openEmployeeDialog(null);
    expect(mdDialog.open).toHaveBeenCalled();
  }));
});
