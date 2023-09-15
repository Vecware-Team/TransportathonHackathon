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
}
