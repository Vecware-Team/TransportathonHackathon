import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HireOutDriverComponent } from './hire-out-driver.component';

describe('HireOutDriverComponent', () => {
  let component: HireOutDriverComponent;
  let fixture: ComponentFixture<HireOutDriverComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HireOutDriverComponent]
    });
    fixture = TestBed.createComponent(HireOutDriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
