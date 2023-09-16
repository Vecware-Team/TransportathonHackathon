import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCommentComponent } from './update-comment.component';

describe('UpdateCommentComponent', () => {
  let component: UpdateCommentComponent;
  let fixture: ComponentFixture<UpdateCommentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateCommentComponent]
    });
    fixture = TestBed.createComponent(UpdateCommentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
