import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { UpdatedTranslateResponse } from '../models/response-models/translates/updatedTranslateResponse';
import { CreatedTranslateResponse } from '../models/response-models/translates/createdTranslateResponse';
import { DeletedTranslateResponse } from '../models/response-models/translates/deletedTranslateResponse';
import { GetListTranslateResponse } from '../models/response-models/translates/getListTranslateResponse';
import { CreateTranslateRequest } from '../models/request-models/translates/createTranslateRequest';
import { UpdateTranslateRequest } from '../models/request-models/translates/updateTranslateRequest';
import { DeleteTranslateRequest } from '../models/request-models/translates/deleteTranslateRequest';
import { GetListByCodeTranslateResponse } from '../models/response-models/translates/getListByCodeTranslateResponse';

@Injectable({
  providedIn: 'root',
})
export class TranslationService {
  apiUrl = environment.apiUrl + 'translates/';
  constructor(private httpClient: HttpClient) {}

  create(
    translateModel: CreateTranslateRequest
  ): Observable<CreatedTranslateResponse> {
    return this.httpClient.post<CreatedTranslateResponse>(
      this.apiUrl + 'create',
      translateModel
    );
  }

  update(
    translateModel: UpdateTranslateRequest
  ): Observable<UpdatedTranslateResponse> {
    return this.httpClient.post<UpdatedTranslateResponse>(
      this.apiUrl + 'update',
      translateModel
    );
  }

  delete(
    translateModel: DeleteTranslateRequest
  ): Observable<DeletedTranslateResponse> {
    return this.httpClient.post<DeletedTranslateResponse>(
      this.apiUrl + 'delete',
      translateModel
    );
  }

  getList(): Observable<GetListTranslateResponse[]> {
    return this.httpClient.get<GetListTranslateResponse[]>(
      this.apiUrl + 'getlist'
    );
  }

  getListByCode(): Observable<GetListByCodeTranslateResponse[]> {
    return this.httpClient.get<GetListByCodeTranslateResponse[]>(
      this.apiUrl + 'GetByLanguageCodeTranslate'
    );
  }
}
