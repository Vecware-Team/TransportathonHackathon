import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Paginate } from 'src/app/core/models/pagination/paginate';
import { GetByCompanyIdCommentRequest } from 'src/app/models/request-models/comments/getByCompanyIdCommentRequest';
import { GetByCompanyIdCommentResponse } from 'src/app/models/response-models/comments/getByCompanyIdCommentResponse';
import { GetListCommentResponse } from 'src/app/models/response-models/comments/getListCommentResponse';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { CommentService } from 'src/app/services/comment.service';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css'],
})
export class CommentsComponent implements OnInit {
  @Input() company: GetByIdCompanyResponse;
  comments: Paginate<GetByCompanyIdCommentResponse>;
  dataLoaded = false;

  constructor(private commentService: CommentService) {}

  ngOnInit(): void {
    this.getListByCompanyId();
  }

  getListByCompanyId() {
    this.dataLoaded = false;
    let request: GetByCompanyIdCommentRequest = {
      companyId: this.company.appUserId,
      pageRequest: {
        size: 10,
        index: 0,
      },
    };
    this.commentService.getListByCompanyId(request).subscribe((response) => {
      this.comments = response;
      this.dataLoaded = true;
    });
  }
}
