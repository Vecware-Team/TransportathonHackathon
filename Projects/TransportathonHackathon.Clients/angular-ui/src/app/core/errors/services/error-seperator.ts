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
    if (error.status === 400 && error.type == 'Business') {
      this.handleBusinessError(error);
    } else if (error.status === 400 && error.type == 'Validation') {
      let validationError = error as ValidationError;
      this.handleValidationError(validationError);
    } else if (error.status === 401 && error.type == 'Unauthorized') {
      this.handleUnauthorizedError(error);
    } else if (error.status === 403 && error.type == 'Authorization') {
      this.handleAuthorizationDeniedError(error);
    } else if (error.status === 404 && error.type == 'NotFound') {
      this.handleNotFoundError(error);
    } else {
      this.handleBaseError(error);
    }
  }

  handleValidationError(error: ValidationError) {
    console.log(error);

    console.log(error.Errors);

    error.Errors?.forEach((e) => {
      e?.Errors?.forEach((c) => {
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
