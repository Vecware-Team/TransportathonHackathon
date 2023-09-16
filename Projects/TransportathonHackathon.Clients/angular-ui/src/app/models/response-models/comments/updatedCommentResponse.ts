import { TransportRequest } from '../../domain-models/transportRequest';

export interface UpdatedCommentResponse {
  transportRequestId: string;
  title: string;
  description: string;
  point: number;
  transportRequest: TransportRequest;
}
