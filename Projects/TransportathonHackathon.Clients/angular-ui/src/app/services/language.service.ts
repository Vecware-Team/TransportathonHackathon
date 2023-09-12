import { Injectable } from '@angular/core';
import { PageRequest } from '../core/requests/pageRequest';
import { Paginate } from '../core/models/pagination/paginate';
import { GetListLanguageResponse } from '../models/response-models/languages/getListLanguageResponse';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CreateLanguageRequest } from '../models/request-models/languages/createLanguageRequest';
import { CreatedLanguageResponse } from '../models/response-models/languages/createdLanguageResponse';
import { UpdateLanguageRequest } from '../models/request-models/languages/updateLanguageRequest';
import { DeleteLanguageRequest } from '../models/request-models/languages/deleteLanguageRequest';
import { UpdatedLanguageResponse } from '../models/response-models/languages/updatedLanguageResponse';
import { DeletedLanguageResponse } from '../models/response-models/languages/deletedLanguageResponse';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  apiUrl = environment.apiUrl + 'languages/';
  constructor(private httpClient: HttpClient) {}

  create(
    languageModel: CreateLanguageRequest
  ): Observable<CreatedLanguageResponse> {
    return this.httpClient.post<CreatedLanguageResponse>(
      this.apiUrl + 'create',
      languageModel
    );
  }

  update(
    languageModel: UpdateLanguageRequest
  ): Observable<UpdatedLanguageResponse> {
    return this.httpClient.put<UpdatedLanguageResponse>(
      this.apiUrl + 'update',
      languageModel
    );
  }

  delete(
    languageModel: DeleteLanguageRequest
  ): Observable<DeletedLanguageResponse> {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      body: languageModel,
    };

    return this.httpClient.delete<DeletedLanguageResponse>(
      this.apiUrl + 'delete',
      httpOptions
    );
  }

  getList(): Observable<GetListLanguageResponse[]> {
    return this.httpClient.get<GetListLanguageResponse[]>(
      this.apiUrl + 'getlist'
    );
  }
}
