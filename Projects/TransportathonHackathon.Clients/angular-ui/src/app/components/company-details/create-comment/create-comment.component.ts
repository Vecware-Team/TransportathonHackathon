import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { CreateCommentRequest } from 'src/app/models/request-models/comments/createCommentRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyAndCustomerTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCompanyAndCustomerTransportRequestResponse';
import { GetByCustomerIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCustomerIdTransportRequestResponse';
import { CommentService } from 'src/app/services/comment.service';
import { CommentStoreService } from 'src/app/services/store-services/comment-store.service';
import { TokenService } from 'src/app/services/token.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';

@Component({
  selector: 'app-create-comment',
  templateUrl: './create-comment.component.html',
  styleUrls: ['./create-comment.component.css'],
})
export class CreateCommentComponent implements OnInit {
  @Input() company: GetByIdCompanyResponse;
  createCommentForm: FormGroup;
  appUser: TokenUserDto;
  transportRequests: GetByCompanyAndCustomerTransportRequestResponse[];

  constructor(
    private formBuilder: FormBuilder,
    private commentService: CommentService,
    private tokenService: TokenService,
    private toastrService: ToastrService,
    private transportRequestService: TransportRequestService
  ) {}
  
  ngOnInit(): void {
    this.getAppUser();
    this.createCreateCommentForm();
    this.getTransportRequests();
  }

  getTransportRequests() {
    this.transportRequestService
      .getListByCompanyAndCustomerId({
        companyId: this.company.appUserId,
        customerId: this.appUser.id,
      })
      .subscribe((response) => {
        this.transportRequests = response;
      });
  }

  getAppUser() {
    this.appUser = this.tokenService.getUserWithJWT()!;
  }

  createCreateCommentForm() {
    this.createCommentForm = this.formBuilder.group({
      description: ['', Validators.required],
      point: ['', Validators.required],
      transportRequestId: ['', Validators.required],
    });
  }

  createComment() {
    if (
      !this.createCommentForm.valid &&
      this.createCommentForm.get('rating')?.value === null
    ) {
      this.toastrService.error('Comment form invalid', 'Form error');
      return;
    }

    let createCommentRequest: CreateCommentRequest = Object.assign(
      {},
      this.createCommentForm.value
    );
    createCommentRequest.title = this.appUser.userName;

    this.commentService.create(createCommentRequest).subscribe((res) => {
      this.toastrService.success('Commented', 'Successful');
    });
  }
}
