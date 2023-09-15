import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateTransportTypeRequest } from '../models/request-models/transport-types/createTransportTypeRequest';
import { UpdateTransportTypeRequest } from '../models/request-models/transport-types/updateTransportTypeRequest';
import { DeleteTransportTypeRequest } from '../models/request-models/transport-types/deleteTransportTypeReques';
import { CreatedTransportTypeResponse } from '../models/response-models/transport-types/createdTransportTypeResponse';
import { UpdatedTransportTypeResponse } from '../models/response-models/transport-types/updatedTransportTypeResponse';
import { DeletedTransportTypeResponse } from '../models/response-models/transport-types/deletedTransportTypeResponse';
import { Observable } from 'rxjs';
import { GetListTransportTypeResponse } from '../models/response-models/transport-types/getListTransportTypeResponse';

@Injectable({
  providedIn: 'root',
})
export class TransportTypeService {
  apiUrl = environment.apiUrl + 'transportTypes/';

  constructor(private httpClient: HttpClient) {}

  create(
    transportTypeModel: CreateTransportTypeRequest
  ): Observable<CreatedTransportTypeResponse> {
    return this.httpClient.post<CreatedTransportTypeResponse>(
      this.apiUrl + 'create',
      transportTypeModel
    );
  }

  update(
    transportTypeModel: UpdateTransportTypeRequest
  ): Observable<UpdatedTransportTypeResponse> {
    return this.httpClient.put<UpdatedTransportTypeResponse>(
      this.apiUrl + 'update',
      transportTypeModel
    );
  }

  delete(
    transportTypeModel: DeleteTransportTypeRequest
  ): Observable<DeletedTransportTypeResponse> {
    return this.httpClient.delete<DeletedTransportTypeResponse>(
      this.apiUrl + 'delete?Id=' + transportTypeModel.id
    );
  }

  getList(): Observable<GetListTransportTypeResponse[]> {
    return this.httpClient.get<GetListTransportTypeResponse[]>(
      this.apiUrl + 'getlist'
    );
  }
}
