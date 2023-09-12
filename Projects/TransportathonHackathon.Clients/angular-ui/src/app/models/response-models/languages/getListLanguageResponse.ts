import { Translate } from "../../domain-models/translate";

export interface GetListLanguageResponse {
    id: string;
    code: string;
    globallyName: string;
    locallyName: string;
    translates: Translate[];
}