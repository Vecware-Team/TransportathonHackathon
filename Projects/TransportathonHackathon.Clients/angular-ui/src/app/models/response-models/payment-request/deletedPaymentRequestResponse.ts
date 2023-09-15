export interface DeletedPaymentRequestResponse {
  transportRequestId: string;
  isPaid: boolean;
  price: number;
  createdDate: Date;
  updatedDate: Date;
}
