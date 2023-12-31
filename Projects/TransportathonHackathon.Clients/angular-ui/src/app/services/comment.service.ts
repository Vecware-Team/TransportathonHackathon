import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateCommentRequest } from '../models/request-models/comments/createCommentRequest';
import { CreatedCommentResponse } from '../models/response-models/comments/createdCommentResponse';
import { Observable } from 'rxjs';
import { UpdatedCommentResponse } from '../models/response-models/comments/updatedCommentResponse';
import { UpdateCommentRequest } from '../models/request-models/comments/updateCommentRequest';
import { DeletedCommentResponse } from '../models/response-models/comments/deletedCommentResponse';
import { DeleteCommentRequest } from '../models/request-models/comments/deleteCommentRequest';
import { GetListCommentRequest } from '../models/request-models/comments/getListCommentRequest';
import { GetListCommentResponse } from '../models/response-models/comments/getListCommentResponse';
import { Paginate } from '../core/models/pagination/paginate';
import { GetByCompanyIdCommentRequest } from '../models/request-models/comments/getByCompanyIdCommentRequest';
import { GetByCompanyIdCommentResponse } from '../models/response-models/comments/getByCompanyIdCommentResponse';

@Injectable({
  providedIn: 'root',
})
export class CommentService {
  apiUrl = environment.apiUrl + 'comments/';
  constructor(private httpClient: HttpClient) {}

  create(
    commentModel: CreateCommentRequest
  ): Observable<CreatedCommentResponse> {
    return this.httpClient.post<CreatedCommentResponse>(
      this.apiUrl + 'create',
      commentModel
    );
  }

  update(
    commentModel: UpdateCommentRequest
  ): Observable<UpdatedCommentResponse> {
    return this.httpClient.put<UpdatedCommentResponse>(
      this.apiUrl + 'update',
      commentModel
    );
  }

  delete(
    commentModel: DeleteCommentRequest
  ): Observable<DeletedCommentResponse> {
    return this.httpClient.delete<DeletedCommentResponse>(
      this.apiUrl + 'delete?Id=' + commentModel.transportRequestId
    );
  }

  getList(): Observable<Paginate<GetListCommentResponse>> {
    return this.httpClient.get<Paginate<GetListCommentResponse>>(
      this.apiUrl + 'getlist'
    );
  }

  getListByCompanyId(
    request: GetByCompanyIdCommentRequest
  ): Observable<Paginate<GetByCompanyIdCommentResponse>> {
    return this.httpClient.get<Paginate<GetByCompanyIdCommentResponse>>(
      this.apiUrl +
        'getByCompanyId?CompanyId=' +
        request.companyId +
        '&PageRequest.Size=' +
        request.pageRequest.size +
        '&PageRequest.Index=' +
        request.pageRequest.index
    );
  }
}
