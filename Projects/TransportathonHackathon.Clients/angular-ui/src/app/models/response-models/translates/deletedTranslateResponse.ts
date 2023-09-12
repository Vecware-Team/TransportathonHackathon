import { Language } from '../../language';


export interface DeletedTranslateResponse {
    id: string;
    languageId: string;
    key: string;
    value: string;
    language: Language;
}

