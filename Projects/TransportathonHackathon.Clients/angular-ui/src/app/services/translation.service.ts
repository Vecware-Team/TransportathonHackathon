import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Translate } from '../models/entities/translate';
import { TranslateLoader } from '@ngx-translate/core';
import { ListResponseModel } from '../core/models/responseModels/ListResponseModel';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../core/models/responseModels/responseModel';
import { ServiceRepositoryBase } from '../core/services/repositories/service.repository.base';

export let allTranslates: Map<string, string> = new Map<string, string>();

@Injectable({
  providedIn: 'root',
})
export class TranslationApiService
  extends ServiceRepositoryBase<Translate>
  implements TranslateLoader
{
  override apiUrl = environment.apiUrl + 'translates/';
  values: Translate[] = [];

  constructor(protected override httpClient: HttpClient) {
    super('translates', httpClient);
  }

  addMultiple(translates: Translate[]): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      this.apiUrl + 'addmultiple',
      translates
    );
  }

  getAllByLanguage(
    languageId: number
  ): Observable<ListResponseModel<Translate>> {
    return this.httpClient.get<ListResponseModel<Translate>>(
      this.apiUrl + 'getallbylanguage?languageId=' + languageId
    );
  }

  getAllByCode(code: string): Observable<ListResponseModel<Translate>> {
    return this.httpClient.get<ListResponseModel<Translate>>(
      this.apiUrl + 'getallbycode?code=' + code
    );
  }

  getTranslation(code: string): Observable<any> {
    return this.httpClient.get<ListResponseModel<Translate>>(
      this.apiUrl + 'getallbycode?code=' + code
    );
  }

  setTranslates() {
    this.values.forEach((v) => {
      allTranslates.set(v.key, v.value);
    });
  }
}
