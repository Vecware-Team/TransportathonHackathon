export interface GetByCustomerIdPaymentRequestResponse {
  transportRequestId: string;
  isPaid: boolean;
  price: number;
  createdDate: string;
  updatedDate: string;
}
