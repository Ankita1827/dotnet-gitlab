import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSolderingComponent } from './view-soldering.component';

describe('ViewSolderingComponent', () => {
  let component: ViewSolderingComponent;
  let fixture: ComponentFixture<ViewSolderingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewSolderingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewSolderingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
