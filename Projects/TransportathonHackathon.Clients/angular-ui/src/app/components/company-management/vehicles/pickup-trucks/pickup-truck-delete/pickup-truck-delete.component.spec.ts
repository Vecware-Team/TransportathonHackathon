import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PickupTruckDeleteComponent } from './pickup-truck-delete.component';

describe('PickupTruckDeleteComponent', () => {
  let component: PickupTruckDeleteComponent;
  let fixture: ComponentFixture<PickupTruckDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PickupTruckDeleteComponent]
    });
    fixture = TestBed.createComponent(PickupTruckDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
