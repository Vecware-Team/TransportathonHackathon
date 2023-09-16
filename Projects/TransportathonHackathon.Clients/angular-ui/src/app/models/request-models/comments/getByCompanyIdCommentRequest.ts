import { PageRequest } from 'src/app/core/requests/pageRequest';

export interface GetByCompanyIdCommentRequest {
  companyId: string;
  pageRequest: PageRequest;
}
