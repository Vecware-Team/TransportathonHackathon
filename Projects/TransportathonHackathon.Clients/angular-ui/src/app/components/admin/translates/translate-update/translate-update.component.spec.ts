import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranslateUpdateComponent } from './translate-update.component';

describe('TranslateUpdateComponent', () => {
  let component: TranslateUpdateComponent;
  let fixture: ComponentFixture<TranslateUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TranslateUpdateComponent]
    });
    fixture = TestBed.createComponent(TranslateUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
