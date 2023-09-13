import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PageRequest } from '../core/requests/pageRequest';
import { Observable } from 'rxjs';
import { Paginate } from '../core/models/pagination/paginate';
import { GetListCompanyResponse } from '../models/response-models/companies/getListCompanyResponse';
import { DynamicQuery } from '../models/domain-models/dynamicQuery';
import { GetListDynamicCompanyResponse } from '../models/response-models/companies/getListDynamicCompanyResponse';
import { GetByIdCompanyResponse } from '../models/response-models/companies/getByIdCompanyResponse';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  apiUrl = environment.apiUrl + 'companies/';
  constructor(private httpClient: HttpClient) {}

  getList(
    pageRequest: PageRequest
  ): Observable<Paginate<GetListCompanyResponse>> {
    return this.httpClient.get<Paginate<GetListCompanyResponse>>(
      this.apiUrl +
        'getList?PageRequest.Size=' +
        pageRequest.size +
        '&PageRequest.Index=' +
        pageRequest.index
    );
  }

  getById(id: string): Observable<GetByIdCompanyResponse> {
    return this.httpClient.get<GetByIdCompanyResponse>(
      this.apiUrl + 'getById/' + id
    );
  }

  getListDynamic(
    pageRequest: PageRequest,
    dynamicQuery: DynamicQuery
  ): Observable<Paginate<GetListDynamicCompanyResponse>> {
    return this.httpClient.post<Paginate<GetListDynamicCompanyResponse>>(
      this.apiUrl +
        'getList?PageRequest.Size=' +
        pageRequest.size +
        '&PageRequest.Index=' +
        pageRequest.index,
      dynamicQuery
    );
  }
}
