import { TestBed } from '@angular/core/testing';

import { OrderstagesService } from './orderstages.service';

describe('OrderstagesService', () => {
  let service: OrderstagesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrderstagesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
