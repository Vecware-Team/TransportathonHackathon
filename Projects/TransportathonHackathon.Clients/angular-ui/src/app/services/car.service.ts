import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateCarRequest } from '../models/request-models/cars/createCarRequest';
import { Observable } from 'rxjs';
import { CreatedCarResponse } from '../models/response-models/cars/createdCarResponse';
import { UpdateCarRequest } from '../models/request-models/cars/updateCarRequest';
import { UpdatedCarResponse } from '../models/response-models/cars/updatedCarResponse';
import { DeleteCarRequest } from '../models/request-models/cars/deleteCarRequest';
import { DeletedCarResponse } from '../models/response-models/cars/deletedCarResponse';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  apiUrl = environment.apiUrl + 'cars/';
  constructor(private httpClient: HttpClient) {}

  create(request: CreateCarRequest): Observable<CreatedCarResponse> {
    return this.httpClient.post<CreatedCarResponse>(
      this.apiUrl + 'create',
      request
    );
  }

  update(request: UpdateCarRequest): Observable<UpdatedCarResponse> {
    return this.httpClient.put<UpdatedCarResponse>(
      this.apiUrl + 'update',
      request
    );
  }

  delete(request: DeleteCarRequest): Observable<DeletedCarResponse> {
    return this.httpClient.delete<DeletedCarResponse>(
      this.apiUrl + 'delete?VehicleId=' + request.vehicleId
    );
  }
}
