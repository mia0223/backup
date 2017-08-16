import { TestBed, inject } from '@angular/core/testing';

import { BackendAccessService } from './backend-access.service';

describe('BackendAccessService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BackendAccessService]
    });
  });

  it('should ...', inject([BackendAccessService], (service: BackendAccessService) => {
    expect(service).toBeTruthy();
  }));
});
