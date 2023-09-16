import { TransportRequest } from '../../domain-models/transportRequest';

export interface CreatedCommentResponse {
  transportRequestId: string;
  title: string;
  description: string;
  point: number;
  transportRequest: TransportRequest;
}
