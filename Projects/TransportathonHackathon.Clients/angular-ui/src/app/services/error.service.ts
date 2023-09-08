import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ErrorDetails } from '../models/entities/errorDetails';
import { allTranslates } from './translation.service';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root',
})
export class ErrorService {
  constructor(
    private toastrService: ToastrService,
    private translateService: TranslateService
  ) {}

  getErrorDetails(responseError: any): ErrorDetails {
    let returnedError: ErrorDetails = responseError.error;
    return returnedError;
  }

  writeErrorMessages(responseError: any) {
    let returnedError = responseError.error;
    if (returnedError.ExceptionType === undefined) {
      this.toastrService.error(
        returnedError.message,
        this.translateService.instant('error')
      );
      return;
    }

    if (returnedError.ExceptionType === 'Exception') {
      this.toastrService.error(returnedError.ErrorMessage, 'Hata');
    } else if (returnedError.ExceptionType === 'ValidationException') {
      for (let i = 0; i < returnedError.ValidationErrors.length; i++) {
        this.toastrService.error(
          returnedError.ValidationErrors[i],
          'Doğrulama Hatasi'
        );
      }
    } else {
      this.toastrService.error(returnedError.ErrorMessage, 'Hata');
    }
  }
}
