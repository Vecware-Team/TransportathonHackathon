import { PaymentRequest } from '../pay-models/paymentModel';

export interface PayPaymentRequestRequest {
  transportRequestId: string;
  paymentRequest: PaymentRequest;
}
