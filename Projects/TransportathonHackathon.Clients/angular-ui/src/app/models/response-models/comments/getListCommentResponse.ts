import { TransportRequest } from '../../domain-models/transportRequest';

export interface GetListCommentResponse {
  transportRequestId: string;
  title: string;
  description: string;
  point: number;
  transportRequest: TransportRequest;
}
