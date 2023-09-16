import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { CreateCommentRequest } from 'src/app/models/request-models/comments/createCommentRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { CommentService } from 'src/app/services/comment.service';
import { CommentStoreService } from 'src/app/services/store-services/comment-store.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-create-comment',
  templateUrl: './create-comment.component.html',
  styleUrls: ['./create-comment.component.css'],
})
export class CreateCommentComponent implements OnInit {
  createCommentForm: FormGroup;
  appUser: TokenUserDto;

  constructor(
    private formBuilder: FormBuilder,
    private commentService: CommentService,
    private tokenService: TokenService,
    private toastrService: ToastrService,
    private commentStoreService: CommentStoreService
  ) {}
  ngOnInit(): void {
    this.createCreateCommentForm();
    this.getAppUser();
  }

  getAppUser() {
    this.appUser = this.tokenService.getUserWithJWT()!;
  }

  createCreateCommentForm() {
    this.createCommentForm = this.formBuilder.group({
      description: ['', Validators.required],
      rating: ['', Validators.required],
    });
  }

  createComment() {
    this.commentStoreService.createCommentEventStore.subscribe((response) => {
      if (!this.createCommentForm.valid) {
        this.toastrService.error('Comment form invalid', 'Form error');
      }

      let createCommentRequest: CreateCommentRequest = Object.assign(
        {},
        this.createCommentForm.value
      );
      createCommentRequest.point = +this.createCommentForm.get('rating')?.value;
      createCommentRequest.title = this.appUser.userName;
      createCommentRequest.transportRequestId = response;

      this.commentService.create(createCommentRequest).subscribe((res) => {
        this.toastrService.success('Commented', 'Successful');
      });
    });
  }
}
