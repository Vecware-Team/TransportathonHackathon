import { BasePageModel } from 'src/app/core/models/pagination/basePageModel';
import { Translate } from '../../domain-models/translate';

export interface GetListLanguageResponse {
  id: string;
  code: string;
  globallyName: string;
  locallyName: string;
  translates: Translate[];
}
