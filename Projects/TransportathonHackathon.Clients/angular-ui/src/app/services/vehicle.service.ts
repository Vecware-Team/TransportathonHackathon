import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { GetByCompanyIdVehicleRequest } from '../models/request-models/vehicles/getByCompanyIdVehicleRequest';
import { Observable } from 'rxjs';
import { GetByCompanyIdVehicleResponse } from '../models/response-models/vehicles/getByCompanyIdVehicleResponse';

@Injectable({
  providedIn: 'root',
})
export class VehicleService {
  apiUrl = environment.apiUrl + 'vehicles/';
  constructor(private httpClient: HttpClient) {}

  getListByCompanyId(
    request: GetByCompanyIdVehicleRequest
  ): Observable<GetByCompanyIdVehicleResponse[]> {
    return this.httpClient.get<GetByCompanyIdVehicleResponse[]>(
      this.apiUrl + 'getByCompanyId/' + request.companyId
    );
  }
}
