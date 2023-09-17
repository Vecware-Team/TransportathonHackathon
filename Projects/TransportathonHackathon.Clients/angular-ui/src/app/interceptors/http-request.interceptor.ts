import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HTTP_INTERCEPTORS,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenService } from '../services/token.service';
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {
  constructor(
    private tokenService: TokenService,
    private toastrService: ToastrService,
    private translate: TranslateService,
    private router: Router
  ) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    let token = this.tokenService.getToken();
    if (token == null) return next.handle(request);
    if (this.tokenService.isTokenExpired()) {
      this.tokenService.removeToken();
      this.router.navigate(['/login']).finally(() => {
        this.toastrService
          .info(
            this.translate.instant('yourSessionTimeExpired'),
            this.translate.instant('goingToLoginPage')
          )
          .onHidden.subscribe(() => {
            location.reload();
          });
      });
    }

    request = request.clone({
      setHeaders: { Authorization: 'Bearer ' + token },
    });

    return next.handle(request);
  }
}

export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true },
];
