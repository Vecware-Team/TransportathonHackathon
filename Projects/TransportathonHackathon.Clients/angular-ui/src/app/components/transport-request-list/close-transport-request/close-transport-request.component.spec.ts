import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CloseTransportRequestComponent } from './close-transport-request.component';

describe('CloseTransportRequestComponent', () => {
  let component: CloseTransportRequestComponent;
  let fixture: ComponentFixture<CloseTransportRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CloseTransportRequestComponent]
    });
    fixture = TestBed.createComponent(CloseTransportRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
