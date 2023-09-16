import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreatedPaymentRequestResponse } from '../models/response-models/payment-request/createdPaymentRequestResponse';
import { CreatePaymentRequestRequest } from '../models/request-models/payment-request/createPaymentRequestRequest';
import { DeletePaymentRequestRequest } from '../models/request-models/payment-request/deletePaymentRequestRequest';
import { DeletedPaymentRequestResponse } from '../models/response-models/payment-request/deletedPaymentRequestResponse';
import { UpdatePaymentRequestRequest } from '../models/request-models/payment-request/updatePaymentRequestRequest';
import { UpdatedPaymentRequestResponse } from '../models/response-models/payment-request/updatedPaymentRequestResponse';
import { PayPaymentRequestRequest } from '../models/request-models/payment-request/payPaymentRequestRequest';
import { PaidPaymentRequestResponse } from '../models/response-models/payment-request/paidPaymentRequestResponse';
import { GetByCustomerIdPaymentRequestRequest } from '../models/request-models/payment-request/getByCustomerIdPaymentRequestRequest';
import { GetByCustomerIdPaymentRequestResponse } from '../models/response-models/payment-request/getByCustomerIdPaymentRequestResponse';
import { Paginate } from '../core/models/pagination/paginate';
import { GetByIdPaymentRequestRequest } from '../models/request-models/payment-request/getByIdPaymentRequestRequest';
import { GetByIdPaymentRequestResponse } from '../models/response-models/payment-request/getByIdPaymentRequestResponse';
import { ApproveAndPayTransportRequestRequest } from '../models/request-models/transport-requests/approveAndPayTransportRequestRequest';
import { ApproveAndPayTransportRequestResponse } from '../models/response-models/transport-requests/approveAndPayTransportRequestResponse';

@Injectable({
  providedIn: 'root',
})
export class PaymentRequestService {
  apiUrl = environment.apiUrl + 'paymentRequests/';
  constructor(private httpClient: HttpClient) {}

  create(
    paymentRequestModel: CreatePaymentRequestRequest
  ): Observable<CreatedPaymentRequestResponse> {
    return this.httpClient.post<CreatedPaymentRequestResponse>(
      this.apiUrl + 'create',
      paymentRequestModel
    );
  }

  update(
    paymentRequestModel: UpdatePaymentRequestRequest
  ): Observable<UpdatedPaymentRequestResponse> {
    return this.httpClient.put<UpdatedPaymentRequestResponse>(
      this.apiUrl + 'update',
      paymentRequestModel
    );
  }

  delete(
    paymentRequestModel: DeletePaymentRequestRequest
  ): Observable<DeletedPaymentRequestResponse> {
    return this.httpClient.delete<DeletedPaymentRequestResponse>(
      this.apiUrl + 'delete?Id=' + paymentRequestModel.transportRequestId
    );
  }

  pay(
    paymentRequestModel: PayPaymentRequestRequest
  ): Observable<PaidPaymentRequestResponse> {
    return this.httpClient.post<PaidPaymentRequestResponse>(
      this.apiUrl + 'pay',
      paymentRequestModel
    );
  }

  approveAndPay(
    paymentRequestModel: ApproveAndPayTransportRequestRequest
  ): Observable<ApproveAndPayTransportRequestResponse> {
    return this.httpClient.post<ApproveAndPayTransportRequestResponse>(
      this.apiUrl + 'pay',
      paymentRequestModel
    );
  }

  getById(
    request: GetByIdPaymentRequestRequest
  ): Observable<GetByIdPaymentRequestResponse> {
    return this.httpClient.get<GetByIdPaymentRequestResponse>(
      this.apiUrl + 'getById/' + request.transportRequestId
    );
  }

  getListByCustomerId(
    request: GetByCustomerIdPaymentRequestRequest
  ): Observable<Paginate<GetByCustomerIdPaymentRequestResponse>> {
    return this.httpClient.get<Paginate<GetByCustomerIdPaymentRequestResponse>>(
      this.apiUrl + 'getByCustomerId/' + request.customerId
    );
  }
}
