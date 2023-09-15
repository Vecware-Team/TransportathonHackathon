import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RejectTransportRequestComponent } from './reject-transport-request.component';

describe('RejectTransportRequestComponent', () => {
  let component: RejectTransportRequestComponent;
  let fixture: ComponentFixture<RejectTransportRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RejectTransportRequestComponent]
    });
    fixture = TestBed.createComponent(RejectTransportRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
