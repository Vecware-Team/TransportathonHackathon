import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateCarrierRequest } from '../models/request-models/carriers/createCarrierRequest';
import { Observable } from 'rxjs';
import { CreatedCarrierResponse } from '../models/response-models/carriers/createdCarrierResponse';
import { DeleteCarrierRequest } from '../models/request-models/carriers/deleteCarrierRequest';
import { DeletedCarrierResponse } from '../models/response-models/carriers/deletedCarrierResponse';

@Injectable({
  providedIn: 'root',
})
export class CarrierService {
  apiUrl = environment.apiUrl + 'carriers/';
  constructor(private httpClient: HttpClient) {}

  create(
    carrierModel: CreateCarrierRequest
  ): Observable<CreatedCarrierResponse> {
    return this.httpClient.post<CreatedCarrierResponse>(
      this.apiUrl + 'add',
      carrierModel
    );
  }

  delete(
    carrierModel: DeleteCarrierRequest
  ): Observable<DeletedCarrierResponse> {
    return this.httpClient.delete<CreatedCarrierResponse>(
      this.apiUrl + 'delete?employeeId=' + carrierModel.employeeId
    );
  }
}
