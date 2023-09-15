import { PaymentRequest } from '../../domain-models/paymentRequest';

export interface PayPaymentRequestRequest {
  transportRequestId: string;
  paymentRequest: PaymentRequest;
}
