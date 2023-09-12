import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranslateCreateComponent } from './translate-create.component';

describe('TranslateCreateComponent', () => {
  let component: TranslateCreateComponent;
  let fixture: ComponentFixture<TranslateCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TranslateCreateComponent]
    });
    fixture = TestBed.createComponent(TranslateCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
