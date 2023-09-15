export interface UpdatedPaymentRequestResponse {
  transportRequestId: string;
  isPaid: boolean;
  price: number;
  createdDate: Date;
  updatedDate: Date;
}
