import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HireCarrierComponent } from './hire-carrier.component';

describe('HireCarrierComponent', () => {
  let component: HireCarrierComponent;
  let fixture: ComponentFixture<HireCarrierComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HireCarrierComponent]
    });
    fixture = TestBed.createComponent(HireCarrierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
