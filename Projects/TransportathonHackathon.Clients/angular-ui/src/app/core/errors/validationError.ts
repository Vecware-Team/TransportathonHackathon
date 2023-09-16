import { BaseError } from './baseError';

export interface ValidationError extends BaseError {
  Errors: ValidationExceptionModel[];
}

export interface ValidationExceptionModel {
  property: string | null;
  Errors: string[] | null;
}
