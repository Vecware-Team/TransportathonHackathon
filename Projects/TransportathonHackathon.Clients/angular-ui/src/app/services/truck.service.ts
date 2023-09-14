import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateTruckRequest } from '../models/request-models/trucks/createTruckRequest';
import { UpdateTruckRequest } from '../models/request-models/trucks/updateTruckRequest';
import { DeleteTruckRequest } from '../models/request-models/trucks/deleteTruckRequest';
import { CreatedTruckResponse } from '../models/response-models/trucks/createdTruckResponse';
import { Observable } from 'rxjs';
import { UpdatedTruckResponse } from '../models/response-models/trucks/updatedTruckResponse';
import { DeletedTruckResponse } from '../models/response-models/trucks/deletedTruckResponse';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TruckService {
  apiUrl = environment.apiUrl + 'trucks/';
  
  constructor(private httpClient: HttpClient) {}

  create(request: CreateTruckRequest): Observable<CreatedTruckResponse> {
    return this.httpClient.post<CreatedTruckResponse>(
      this.apiUrl + 'create',
      request
    );
  }

  update(request: UpdateTruckRequest): Observable<UpdatedTruckResponse> {
    return this.httpClient.put<UpdatedTruckResponse>(
      this.apiUrl + 'update',
      request
    );
  }

  delete(request: DeleteTruckRequest): Observable<DeletedTruckResponse> {
    return this.httpClient.delete<DeletedTruckResponse>(
      this.apiUrl + 'delete?VehicleId=' + request.vehicleId
    );
  }
}
