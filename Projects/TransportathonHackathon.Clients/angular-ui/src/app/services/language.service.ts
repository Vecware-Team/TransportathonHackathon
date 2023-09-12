import { Injectable } from '@angular/core';
import { PageRequest } from '../core/requests/pageRequest';
import { Paginate } from '../core/models/pagination/paginate';
import { GetListLanguageResponse } from '../models/response-models/languages/getListLanguageResponse';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  apiUrl = environment.apiUrl + 'languages/';
  constructor(private httpClient: HttpClient) {}

  getList(): Observable<GetListLanguageResponse[]> {
    return this.httpClient.get<GetListLanguageResponse[]>(
      this.apiUrl + 'getlist'
    );
  }
}
