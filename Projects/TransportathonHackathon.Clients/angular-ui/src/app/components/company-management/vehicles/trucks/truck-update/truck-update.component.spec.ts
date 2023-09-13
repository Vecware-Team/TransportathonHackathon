import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TruckUpdateComponent } from './truck-update.component';

describe('TruckUpdateComponent', () => {
  let component: TruckUpdateComponent;
  let fixture: ComponentFixture<TruckUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TruckUpdateComponent]
    });
    fixture = TestBed.createComponent(TruckUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
