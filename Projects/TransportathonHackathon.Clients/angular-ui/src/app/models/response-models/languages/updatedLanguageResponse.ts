import { Translate } from '../../translate';

export interface UpdatedLanguageResponse {
  id: string;
  code: string;
  globallyName: string;
  locallyName: string;
  translates: Translate[];
}

