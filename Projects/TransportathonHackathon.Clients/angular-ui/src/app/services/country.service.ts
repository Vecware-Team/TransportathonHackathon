import { Injectable } from '@angular/core';
import { Country } from '../models/country';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class CountryService {
  apiUrl = 'https://api.countrystatecity.in/v1/';
  constructor(private httpClient: HttpClient) {}

  getCountries(): Observable<Country[]> {
    var headers = new HttpHeaders();
    headers.append('X-CSCAPI-KEY', 'eXFwd0g5ekpFdms1NFVaWmFJckRyN1ZpOFVTRll4QjRQSmpVejY3Sw== ');
    
    var requestOptions = {
     method: 'GET',
     headers: headers,
     redirect: 'follow'
    };

    return this.httpClient.get<Country[]>(this.apiUrl + 'countries', requestOptions);
  }
}
