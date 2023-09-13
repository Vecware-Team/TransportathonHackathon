import { PageRequest } from 'src/app/core/requests/pageRequest';
import { DynamicQuery } from '../../domain-models/dynamicQuery';

export interface GetListDynamicCompanyRequest {
  dynamicQuery: DynamicQuery;
  pageRequest: PageRequest;
}
