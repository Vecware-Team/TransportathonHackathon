import { Actions } from '@ngrx/effects';
import { Observable } from 'rxjs';
import { EffectsRepository } from './../abstracts/effects.repository';

export class EffectsRepositoryBase<T> implements EffectsRepository<T> {
  constructor(private actions$: Actions<any>) {}
  TActions: any;

  getAll$: Observable<T[]>;
  add$: Observable<T>;
  delete$: Observable<T>;
  update$: Observable<T>;
}
