import { Language } from '../../language';


export interface CreatedTranslateResponse {
    id: string;
    languageId: string;
    key: string;
    value: string;
    language: Language;
}
