import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpResponse,
} from '@angular/common/http';
import { TokenService } from '../services/token.service';
import { RefreshTokenService } from '../services/refresh-token.service';
import { SettingsService } from '../services/settings.service';
import { AuthService } from '../services/auth.service';
import { ErrorService } from '../services/error.service';
import { environment } from '../../environments/environment';
import { catchError, filter, switchMap, take } from 'rxjs/operators';
import { from, Observable, ObservableInput, throwError } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  accessToken: string = '';
  refreshToken: string = '';
  apiUrl: string = environment.apiUrl;
  storageType: string = '';
  constructor(
    private tokenService: TokenService,
    private refreshTokenService: RefreshTokenService,
    private settingsService: SettingsService,
    private authService: AuthService,
    private errorService: ErrorService
  ) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    let newRequest: HttpRequest<any>;
    this.accessToken = this.tokenService.get()!;
    this.refreshToken = this.refreshTokenService.get()!;
    this.storageType = this.tokenService.getStorageType();

    newRequest = request.clone({
      headers: request.headers
        .set('Authorization', 'Bearer ' + this.accessToken ?? '')
        .append('refreshToken', this.refreshToken ?? '')
        .append(
          'language',
          this.settingsService.getLanguageCodeFromLocalStorage()
        )
        .append('Access-Control-Allow-Origin', '*')
        // .append(
        //   'Access-Control-Allow-Headers',
        //   'Origin, X-Requested-With, Content-Type, Accept'
        // )
        // .append(
        //   'Access-Control-Allow-Methods',
        //   'GET, POST, PUT, DELETE, OPTIONS, HEAD'
        // ),
    });

    return next.handle(newRequest).pipe(
      catchError((error) => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          return this.handleUnauthorizedError(newRequest, next);
        } else {
          return throwError(error);
        }
      })
    );
  }

  handleUnauthorizedError(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    let refreshTokenRequest = request.clone({
      method: 'POST',
      url: this.apiUrl + 'auth/refreshtoken',
    });

    next.handle(refreshTokenRequest).subscribe(
      (response) => {
        if (response instanceof HttpResponse) {
          this.setToken(
            response.body.data.accessToken.token,
            response.body.data.refreshToken.token
          );
        }
      },
      (responseError) => {
        this.tokenService.remove();
        this.refreshTokenService.remove();
      }
    );

    return next.handle(request);
  }

  setToken(accessToken: string, refreshToken: string) {
    if (localStorage.getItem('token') !== null) {
      this.tokenService.setLocal(accessToken);
      this.refreshTokenService.setLocal(refreshToken);
    } else {
      this.tokenService.setSession(accessToken);
      this.refreshTokenService.setSession(refreshToken);
    }
  }
}
