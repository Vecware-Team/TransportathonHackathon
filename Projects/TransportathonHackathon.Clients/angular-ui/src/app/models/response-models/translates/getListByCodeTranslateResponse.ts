import { Language } from '../../domain-models/language';

export interface GetListByCodeTranslateResponse {
  id: string;
  languageId: string;
  key: string;
  value: string;
  language: Language;
}
