import { TestBed, inject } from '@angular/core/testing';

import { YmapsService } from './ymaps.service';

describe('YmapsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [YmapsService]
    });
  });

  it('should be created', inject([YmapsService], (service: YmapsService) => {
    expect(service).toBeTruthy();
  }));
});
