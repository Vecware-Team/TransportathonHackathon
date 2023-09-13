import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PickupTruckAddComponent } from './pickup-truck-add.component';

describe('PickupTruckAddComponent', () => {
  let component: PickupTruckAddComponent;
  let fixture: ComponentFixture<PickupTruckAddComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PickupTruckAddComponent]
    });
    fixture = TestBed.createComponent(PickupTruckAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
