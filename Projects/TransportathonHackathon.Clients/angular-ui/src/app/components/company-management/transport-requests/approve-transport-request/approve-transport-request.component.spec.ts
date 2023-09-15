import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproveTransportRequestComponent } from './approve-transport-request.component';

describe('ApproveTransportRequestComponent', () => {
  let component: ApproveTransportRequestComponent;
  let fixture: ComponentFixture<ApproveTransportRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ApproveTransportRequestComponent]
    });
    fixture = TestBed.createComponent(ApproveTransportRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
