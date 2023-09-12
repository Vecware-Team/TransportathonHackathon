import { Translate } from '../../translate';


export interface DeletedLanguageResponse {
    id: string;
    code: string;
    globallyName: string;
    locallyName: string;
    translates: Translate[];
}
