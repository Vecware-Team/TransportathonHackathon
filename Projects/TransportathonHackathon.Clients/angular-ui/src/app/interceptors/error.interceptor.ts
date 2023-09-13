import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, catchError, retry, throwError } from 'rxjs';
import { BaseError } from '../core/errors/baseError';
import { ErrorSeperator } from '../core/errors/services/error-seperator';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private errorSeperator: ErrorSeperator) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error) => {
        let exceptionError: BaseError = error.error;
        this.errorSeperator.handleErrors(error.error);
        return throwError('errorMsg');
      })
    );
  }
}
