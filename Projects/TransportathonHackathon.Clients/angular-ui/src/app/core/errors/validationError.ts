import { BaseError } from './baseError';

export interface ValidationError extends BaseError {
  errors: ValidationExceptionModel[];
}

export interface ValidationExceptionModel {
  property: string | null;
  errors: string[] | null;
}
