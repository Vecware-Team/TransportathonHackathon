import { TransportRequest } from '../../domain-models/transportRequest';

export interface GetByCompanyIdCommentResponse {
  transportRequestId: string;
  title: string;
  description: string;
  point: number;
  transportRequest: TransportRequest;
}
