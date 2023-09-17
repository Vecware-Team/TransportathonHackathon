import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { GetByCompanyIdDriverRequest } from '../models/request-models/drivers/getByCompanyIdDriverRequest';
import { Observable } from 'rxjs';
import { GetByCompanyIdDriverResponse } from '../models/response-models/drivers/getByCompanyIdDriverResponse';
import { DeleteDriverRequest } from '../models/request-models/drivers/deleteDriverRequest';
import { DeletedDriverResponse } from '../models/response-models/drivers/deletedDriverResponse';

@Injectable({
  providedIn: 'root',
})
export class DriverService {
  apiUrl = environment.apiUrl + 'drivers/';
  constructor(private httpClient: HttpClient) {}

  getListByCompanyId(
    request: GetByCompanyIdDriverRequest
  ): Observable<GetByCompanyIdDriverResponse[]> {
    return this.httpClient.get<GetByCompanyIdDriverResponse[]>(
      this.apiUrl + 'getByCompanyId/' + request.companyId
    );
  }

  delete(
    driverModel: DeleteDriverRequest
  ): Observable<DeletedDriverResponse> {
    return this.httpClient.delete<DeletedDriverResponse>(
      this.apiUrl + 'delete?employeeId=' + driverModel.employeeId
    );
  }
}
