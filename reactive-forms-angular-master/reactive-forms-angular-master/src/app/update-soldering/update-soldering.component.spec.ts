import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateSolderingComponent } from './update-soldering.component';

describe('UpdateSolderingComponent', () => {
  let component: UpdateSolderingComponent;
  let fixture: ComponentFixture<UpdateSolderingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateSolderingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateSolderingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
