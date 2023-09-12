import { Language } from '../../domain-models/language';

export interface GetListTranslateResponse {
  id: string;
  languageId: string;
  key: string;
  value: string;
  language: Language;
}
