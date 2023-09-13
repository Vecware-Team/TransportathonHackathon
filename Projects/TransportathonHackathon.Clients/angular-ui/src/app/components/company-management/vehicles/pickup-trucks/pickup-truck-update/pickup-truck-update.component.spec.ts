import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PickupTruckUpdateComponent } from './pickup-truck-update.component';

describe('PickupTruckUpdateComponent', () => {
  let component: PickupTruckUpdateComponent;
  let fixture: ComponentFixture<PickupTruckUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PickupTruckUpdateComponent]
    });
    fixture = TestBed.createComponent(PickupTruckUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
