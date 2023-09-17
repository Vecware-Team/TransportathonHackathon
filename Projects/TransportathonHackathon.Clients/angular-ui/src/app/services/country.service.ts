import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Country, State, City, ICity, ICountry } from 'country-state-city';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  constructor(private httpClient: HttpClient) {}

  getCountries(): ICountry[] {
    return Country.getAllCountries();
  }

  getCitiesByCountry(countryCode: string): ICity[] | undefined {
    return City.getCitiesOfCountry(countryCode);
  }
}
