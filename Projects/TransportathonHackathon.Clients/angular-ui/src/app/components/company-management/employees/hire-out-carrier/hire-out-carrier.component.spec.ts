import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HireOutCarrierComponent } from './hire-out-carrier.component';

describe('HireOutCarrierComponent', () => {
  let component: HireOutCarrierComponent;
  let fixture: ComponentFixture<HireOutCarrierComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HireOutCarrierComponent]
    });
    fixture = TestBed.createComponent(HireOutCarrierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
