import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { GetByCompanyIdEmployeeResponse } from '../models/response-models/employees/getByCompanyIdEmployeeResponse';
import { GetByCompanyIdEmployeeRequest } from '../models/request-models/employees/getByCompanyIdEmployeeRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  apiUrl = environment.apiUrl + 'employees/';
  constructor(private httpClient: HttpClient) {}

  getListByCompanyId(
    employeeRequest: GetByCompanyIdEmployeeRequest
  ): Observable<GetByCompanyIdEmployeeResponse[]> {
    return this.httpClient.get<GetByCompanyIdEmployeeResponse[]>(
      this.apiUrl + 'getByCompanyId/' + employeeRequest.companyId
    );
  }
}
