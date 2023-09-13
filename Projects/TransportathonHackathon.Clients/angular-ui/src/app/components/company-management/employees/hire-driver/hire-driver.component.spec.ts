import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HireDriverComponent } from './hire-driver.component';

describe('HireDriverComponent', () => {
  let component: HireDriverComponent;
  let fixture: ComponentFixture<HireDriverComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HireDriverComponent]
    });
    fixture = TestBed.createComponent(HireDriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
