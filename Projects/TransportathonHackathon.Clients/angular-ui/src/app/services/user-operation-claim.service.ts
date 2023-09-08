import { UserOperationClaimDetailsDto } from './../models/dtos/userOperationClaimDetailsDto';
import { ListResponseModel } from './../core/models/responseModels/ListResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { UserOperationClaim } from './../models/entities/userOperationClaim';
import { Injectable } from '@angular/core';
import { ServiceRepositoryBase } from '../core/services/repositories/service.repository.base';

@Injectable({
  providedIn: 'root',
})
export class UserOperationClaimService extends ServiceRepositoryBase<UserOperationClaim> {
  override apiUrl: string = environment.apiUrl + 'useroperationclaims/';
  constructor(protected override httpClient: HttpClient) {
    super('useroperationclaims', httpClient);
  }

  getAllDetailsByUser(
    userId: number
  ): Observable<ListResponseModel<UserOperationClaimDetailsDto>> {
    return this.httpClient.get<ListResponseModel<UserOperationClaimDetailsDto>>(
      this.apiUrl + 'getalldetailsbyuser?userId=' + userId
    );
  }
}
