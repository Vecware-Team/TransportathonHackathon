import { Entity } from '../core/models/entity';
import { Language } from './language';

export interface Translate extends Entity<string> {
  languageId: string;
  key: string;
  value: string;
  language: Language;
}
