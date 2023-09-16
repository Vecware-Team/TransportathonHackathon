import { TransportRequest } from "../../domain-models/transportRequest";

export interface DeletedCommentResponse {
  transportRequestId: string;
  title: string;
  description: string;
  point: number;
  transportRequest: TransportRequest;
}
