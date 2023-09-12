import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranslateDeleteComponent } from './translate-delete.component';

describe('TranslateDeleteComponent', () => {
  let component: TranslateDeleteComponent;
  let fixture: ComponentFixture<TranslateDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TranslateDeleteComponent]
    });
    fixture = TestBed.createComponent(TranslateDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
