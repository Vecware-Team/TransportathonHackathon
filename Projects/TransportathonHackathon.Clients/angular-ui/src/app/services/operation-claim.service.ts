import { OperationClaim } from './../models/entities/operationClaim';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServiceRepositoryBase } from '../core/services/repositories/service.repository.base';

@Injectable({
  providedIn: 'root',
})
export class OperationClaimService extends ServiceRepositoryBase<OperationClaim> {
  override apiUrl = environment.apiUrl + 'operationclaims/';
  constructor(protected override httpClient: HttpClient) {
    super('operationclaims', httpClient);
  }
}
