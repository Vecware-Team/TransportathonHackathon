import { PaymentRequest } from '../pay-models/paymentModel';

export interface ApproveAndPayTransportRequestCommand {
  id: string;
  isApproved: boolean;
  paymentRequest: PaymentRequest;
}
