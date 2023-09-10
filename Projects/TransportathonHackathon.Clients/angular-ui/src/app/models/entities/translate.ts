import { Entity } from 'src/app/core/models/entities/entity';
import { Language } from './language';

export interface Translate extends Entity<string> {
  languageId: string;
  key: string;
  value: string;
  language: Language;
}
