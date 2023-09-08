import { Observable } from 'rxjs';

export interface EffectsRepository<T> {
  TActions: any;
  getAll$: Observable<T[]>;
  add$: Observable<T>;
  delete$: Observable<T>;
  update$: Observable<T>;
}
