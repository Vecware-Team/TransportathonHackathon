import { HttpClient, HttpHeaders } from '@angular/common/http';
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
import { TranslateLoader } from '@ngx-translate/core';
import { GetJsonTranslateResponse } from '../models/response-models/translates/getJsonTranslateResponse';

@Injectable({
  providedIn: 'root',
})
export class TranslationService implements TranslateLoader {
  apiUrl = environment.apiUrl + 'translates/';
  constructor(private httpClient: HttpClient) {}

  getTranslation(code: string): Observable<any> {
    return this.httpClient.get<GetJsonTranslateResponse>(
      this.apiUrl + 'GetByLanguageCodeAsString/' + code
    );
  }

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
    return this.httpClient.put<UpdatedTranslateResponse>(
      this.apiUrl + 'update',
      translateModel
    );
  }

  delete(
    translateModel: DeleteTranslateRequest
  ): Observable<DeletedTranslateResponse> {
    return this.httpClient.delete<DeletedTranslateResponse>(
      this.apiUrl + 'delete?id=' + translateModel.id
    );
  }

  getList(): Observable<GetListTranslateResponse[]> {
    return this.httpClient.get<GetListTranslateResponse[]>(
      this.apiUrl + 'getlist'
    );
  }

  getListByCode(code: string): Observable<GetListByCodeTranslateResponse[]> {
    return this.httpClient.get<GetListByCodeTranslateResponse[]>(
      this.apiUrl + 'GetByLanguageCode/' + code
    );
  }
}
