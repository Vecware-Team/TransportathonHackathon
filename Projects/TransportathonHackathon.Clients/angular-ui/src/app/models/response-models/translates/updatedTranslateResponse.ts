import { Language } from '../../language';

export interface UpdatedTranslateResponse {
  id: string;
  languageId: string;
  key: string;
  value: string;
  language: Language;
}

