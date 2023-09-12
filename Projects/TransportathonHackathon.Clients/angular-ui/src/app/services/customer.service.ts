import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreatedCustomerResponse } from '../models/response-models/customers/createdCustomerResponse';
import { CreateCustomerRequest } from '../models/request-models/customers/createCustomerRequest';
import { Paginate } from '../core/models/pagination/paginate';
import { GetListCustomerResponse } from '../models/response-models/customers/getListCustomerResponse';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  apiUrl = environment.apiUrl + 'customers/';
  constructor(private httpClient: HttpClient) {}

  create(
    customerModel: CreateCustomerRequest
  ): Observable<CreatedCustomerResponse> {
    return this.httpClient.post<CreatedCustomerResponse>(
      this.apiUrl,
      customerModel
    );
  }

  getList(): Observable<Paginate<GetListCustomerResponse>> {
    return this.httpClient.get<Paginate<GetListCustomerResponse>>(
      this.apiUrl + 'getlist'
    );
  }
}
