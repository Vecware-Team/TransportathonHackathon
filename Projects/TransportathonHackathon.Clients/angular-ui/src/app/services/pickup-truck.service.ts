import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreatePickupTruckRequest } from '../models/request-models/pickup-trucks/createPickupTruckRequest';
import { UpdatePickupTruckRequest } from '../models/request-models/pickup-trucks/updatePickupTruckRequest';
import { DeletePickupTruckRequest } from '../models/request-models/pickup-trucks/deletePickupTruckRequest';
import { CreatedPickupTruckResponse } from '../models/response-models/pickup-trucks/createdPickupTruckResponse';
import { UpdatedPickupTruckResponse } from '../models/response-models/pickup-trucks/updatedPickupTruckResponse';
import { DeletedPickupTruckResponse } from '../models/response-models/pickup-trucks/deletedPickupTruckResponse';

@Injectable({
  providedIn: 'root',
})
export class PickupTruckService {
  apiUrl = environment.apiUrl + 'pickupTrucks/';

  constructor(private httpClient: HttpClient) {}

  create(
    request: CreatePickupTruckRequest
  ): Observable<CreatedPickupTruckResponse> {
    return this.httpClient.post<CreatedPickupTruckResponse>(
      this.apiUrl + 'create',
      request
    );
  }

  update(
    request: UpdatePickupTruckRequest
  ): Observable<UpdatedPickupTruckResponse> {
    return this.httpClient.put<UpdatedPickupTruckResponse>(
      this.apiUrl + 'update',
      request
    );
  }

  delete(
    request: DeletePickupTruckRequest
  ): Observable<DeletedPickupTruckResponse> {
    return this.httpClient.delete<DeletedPickupTruckResponse>(
      this.apiUrl + 'delete?VehicleId=' + request.vehicleId
    );
  }
}
