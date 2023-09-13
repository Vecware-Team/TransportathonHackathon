import { Injectable } from '@angular/core';
import { CreateCustomerRequest } from '../models/request-models/customers/createCustomerRequest';
import { CreateCompanyRequest } from '../models/request-models/company/createCompanyRequest';
import { CreateCarrierRequest } from '../models/request-models/carriers/createCarrierRequest';
import { CreateDriverRequest } from '../models/request-models/drivers/createDriverRequest';
import { Observable } from 'rxjs';
import { AccessToken } from '../models/domain-models/accessToken';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LoginDto } from '../models/dtos/loginDto';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl = environment.apiUrl + 'auth/';
  constructor(private httpClient: HttpClient) {}

  registerAsCustomer(
    registerModel: CreateCustomerRequest
  ): Observable<AccessToken> {
    return this.httpClient.post<AccessToken>(
      this.apiUrl + 'registerCustomer',
      registerModel
    );
  }
  registerAsCompany(
    registerModel: CreateCompanyRequest
  ): Observable<AccessToken> {
    return this.httpClient.post<AccessToken>(
      this.apiUrl + 'registerCompany',
      registerModel
    );
  }
  registerAsCarrier(
    registerModel: CreateCarrierRequest
  ): Observable<AccessToken> {
    return this.httpClient.post<AccessToken>(
      this.apiUrl + 'registerCarrier',
      registerModel
    );
  }
  registerAsDriver(
    registerModel: CreateDriverRequest
  ): Observable<AccessToken> {
    return this.httpClient.post<AccessToken>(
      this.apiUrl + 'registerDriver',
      registerModel
    );
  }

  login(loginModel: LoginDto): Observable<AccessToken> {
    return this.httpClient.post<AccessToken>(this.apiUrl + 'login', loginModel);
  }

  signOut() {
    return true;
  }
}
