import { Token } from './../models/entities/token';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ItemResponseModel } from '../core/models/responseModels/ItemResponseModel';
import { LoginModel } from '../models/entities/loginModel';
import { TokenService } from './token.service';
import { RegisterModel } from '../models/entities/registerModel';
import { environment } from '../../environments/environment';
import { CustomerForRegisterDto } from '../models/dtos/customerForRegisterDto';
import { ResponseModel } from '../core/models/responseModels/responseModel';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl = environment.apiUrl + 'auth/';

  constructor(
    private httpClient: HttpClient,
    private tokenService: TokenService
  ) {}

  login(loginModel: LoginModel): Observable<ItemResponseModel<Token>> {
    return this.httpClient.post<ItemResponseModel<Token>>(
      this.apiUrl + 'login',
      loginModel
    );
  }

  register(registerModel: RegisterModel): Observable<ItemResponseModel<Token>> {
    return this.httpClient.post<ItemResponseModel<Token>>(
      this.apiUrl + 'register',
      registerModel
    );
  }

  registerWithCustomer(
    customerForRegisterDto: CustomerForRegisterDto
  ): Observable<ItemResponseModel<Token>> {
    return this.httpClient.post<ItemResponseModel<Token>>(
      this.apiUrl + 'registerwithcustomer',
      customerForRegisterDto
    );
  }

  refreshToken(): Observable<ItemResponseModel<Token>> {
    return this.httpClient.post<ItemResponseModel<Token>>(
      this.apiUrl + 'refreshToken',
      null
    );
  }

  signOut() {
    this.httpClient
      .post<ResponseModel>(
        this.apiUrl + 'logout',
        this.tokenService.getUserWithJWT()
      )
      .subscribe((response) => {
        this.tokenService.remove();
        // this.refreshTokenService.remove();
      });
  }

  isSignedIn(): boolean {
    if (this.tokenService.get()) {
      return true;
    }
    return false;
  }

  getUser() {
    return this.tokenService.getUserWithJWT();
  }

  isAuthenticated() {
    let isAdmin = this.tokenService
      .getUserRolesWithJWT()
      .find((r) => r == 'admin');
    if (isAdmin) {
      return true;
    } else {
      return false;
    }
  }
}
