import { PaymentRequest } from '../../domain-models/paymentRequest';

export interface ApproveAndPayTransportRequestRequest {
  id: string;
  isApproved: boolean;
  price: number;
}
