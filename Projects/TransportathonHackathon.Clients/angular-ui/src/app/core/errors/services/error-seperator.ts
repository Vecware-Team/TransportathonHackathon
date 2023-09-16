import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BaseError } from '../baseError';
import { ValidationError } from '../validationError';
import { UnauthorizedError } from '../unauthorizedError';
import { AuthorizationDeniedError } from '../authorizationDeniedError';
import { BusinessError } from '../businessError';
import { NotFoundError } from '../notFoundError';

@Injectable({
  providedIn: 'root',
})
export class ErrorSeperator {
  constructor(private toastrService: ToastrService) {}

  handleErrors(error: BaseError) {
    console.log(error);

    if (error.statusCode === 400 && error.title === 'BusinessException') {
      this.handleBusinessError(error);
    } else if (
      error.statusCode === 400 &&
      error.title === 'ValidationException'
    ) {
      let validationError = error as ValidationError;
      this.handleValidationError(validationError);
    } else if (error.statusCode === 401) {
      this.handleUnauthorizedError(error);
    } else if (error.statusCode === 403) {
      this.handleAuthorizationDeniedError(error);
    } else if (error.statusCode === 404) {
      this.handleNotFoundError(error);
    } else {
      this.handleBaseError(error);
    }
  }

  handleValidationError(error: ValidationError) {
    error.errors.forEach((e) => {
      e.errors?.forEach((c) => {
        this.toastrService.error(c, e.property!);
      });
    });
  }

  handleUnauthorizedError(error: UnauthorizedError) {
    this.toastrService.error(error.detail, error.title);
  }

  handleAuthorizationDeniedError(error: AuthorizationDeniedError) {
    this.toastrService.error(error.detail, error.title);
  }

  handleBusinessError(error: BusinessError) {
    this.toastrService.error(error.detail, error.title);
  }

  handleNotFoundError(error: NotFoundError) {
    this.toastrService.error(error.detail, error.title);
  }

  handleBaseError(error: BaseError) {
    // this.toastrService.error(error.detail, error.title);
  }
}
