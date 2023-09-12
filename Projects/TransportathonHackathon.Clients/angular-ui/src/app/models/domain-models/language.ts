import { BaseEntity, Entity } from '../../core/models/entity';
import { Translate } from './translate';

export interface Language extends Entity<string> {
  code: string;
  globallyName: string;
  locallyName: string;
  translates: Translate[] | null;
}
