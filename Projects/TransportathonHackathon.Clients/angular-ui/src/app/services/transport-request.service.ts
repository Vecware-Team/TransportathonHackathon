import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { GetByCompanyIdTransportRequestRequest } from '../models/request-models/transport-requests/getByCompanyIdTransportRequestRequest';
import { Observable } from 'rxjs';
import { GetByCompanyIdTransportRequestResponse } from '../models/response-models/transport-requests/getByCompanyIdTransportRequestResponse';
import { ApproveTransportRequestResponse } from '../models/response-models/transport-requests/approveTransportRequestResponse';
import { ApproveTransportRequestRequest } from '../models/request-models/transport-requests/approveTransportRequestRequest';
import { GetByCustomerIdTransportRequestRequest } from '../models/request-models/transport-requests/getByCustomerIdTransportRequestRequest';
import { GetByCustomerIdTransportRequestResponse } from '../models/response-models/transport-requests/getByCustomerIdTransportRequestResponse';
import { CreateTransportRequestRequest } from '../models/request-models/transport-requests/createTransportRequestRequest';
import { CreatedTransportRequestResponse } from '../models/response-models/transport-requests/createdTransportRequestResponse';
import { GetByIdTransportRequestRequest } from '../models/request-models/transport-requests/getByIdTransportRequestRequest';
import { GetByIdTransportRequestResponse } from '../models/response-models/transport-requests/getByIdTransportRequestResponse';
import { FinishTransportRequestRequest } from '../models/request-models/transport-requests/finishTransportRequestRequest';
import { FinishedTransportRequestResponse } from '../models/response-models/transport-requests/finishedTransportRequestResponse';
import { ApproveAndPayTransportRequestRequest } from '../models/request-models/transport-requests/approveAndPayTransportRequestRequest';
import { ApproveAndPayTransportRequestResponse } from '../models/response-models/transport-requests/approveAndPayTransportRequestResponse';
import { GetByCompanyAndCustomerTransportRequestRequest } from '../models/request-models/transport-requests/getByCompanyAndCustomerTransportRequestRequest';
import { GetByCompanyAndCustomerTransportRequestResponse } from '../models/response-models/transport-requests/getByCompanyAndCustomerTransportRequestResponse';

@Injectable({
  providedIn: 'root',
})
export class TransportRequestService {
  apiUrl = environment.apiUrl + 'transportRequests/';
  constructor(private httpClient: HttpClient) {}

  create(
    request: CreateTransportRequestRequest
  ): Observable<CreatedTransportRequestResponse> {
    return this.httpClient.post<CreatedTransportRequestResponse>(
      this.apiUrl + 'create',
      request
    );
  }

  getListByCompanyId(
    request: GetByCompanyIdTransportRequestRequest
  ): Observable<GetByCompanyIdTransportRequestResponse[]> {
    return this.httpClient.get<GetByCompanyIdTransportRequestResponse[]>(
      this.apiUrl + 'getListByCompanyId/' + request.companyId
    );
  }

  getListByCustomerId(
    request: GetByCustomerIdTransportRequestRequest
  ): Observable<GetByCustomerIdTransportRequestResponse[]> {
    return this.httpClient.get<GetByCustomerIdTransportRequestResponse[]>(
      this.apiUrl + 'getListByCustomerId/' + request.customerId
    );
  }

  getListByCompanyAndCustomerId(
    request: GetByCompanyAndCustomerTransportRequestRequest
  ): Observable<GetByCompanyAndCustomerTransportRequestResponse[]> {
    return this.httpClient.get<
      GetByCompanyAndCustomerTransportRequestResponse[]
    >(
      this.apiUrl +
        'getListByCompanyIdAndCustomerId/' +
        request.companyId +
        '/' +
        request.customerId
    );
  }

  getById(
    request: GetByIdTransportRequestRequest
  ): Observable<GetByIdTransportRequestResponse> {
    return this.httpClient.get<GetByIdTransportRequestResponse>(
      this.apiUrl + 'getById/' + request.id
    );
  }

  approveTransportRequest(
    request: ApproveTransportRequestRequest
  ): Observable<ApproveTransportRequestResponse> {
    return this.httpClient.post<ApproveTransportRequestResponse>(
      this.apiUrl + 'approve',
      request
    );
  }

  approveAndPayTransportRequest(
    request: ApproveAndPayTransportRequestRequest
  ): Observable<ApproveAndPayTransportRequestResponse> {
    return this.httpClient.post<ApproveAndPayTransportRequestResponse>(
      this.apiUrl + 'approveAndPay',
      request
    );
  }

  finishTransportRequest(
    request: FinishTransportRequestRequest
  ): Observable<FinishedTransportRequestResponse> {
    return this.httpClient.post<FinishedTransportRequestResponse>(
      this.apiUrl + 'finish',
      request
    );
  }
}
