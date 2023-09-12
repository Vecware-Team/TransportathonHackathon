import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranslatesComponent } from './translates.component';

describe('TranslatesComponent', () => {
  let component: TranslatesComponent;
  let fixture: ComponentFixture<TranslatesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TranslatesComponent]
    });
    fixture = TestBed.createComponent(TranslatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
