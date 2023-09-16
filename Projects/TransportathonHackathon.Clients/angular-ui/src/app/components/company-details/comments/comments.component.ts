import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  comments: GetListCommentResponse[];

  constructor(private commentService: CommentService) {}

  ngOnInit(): void {
    this.getListByCompanyId();
  }

  getListByCompanyId() {
    this.commentService.getList().subscribe((response) => {
      this.comments = response;
    });
  }
}
