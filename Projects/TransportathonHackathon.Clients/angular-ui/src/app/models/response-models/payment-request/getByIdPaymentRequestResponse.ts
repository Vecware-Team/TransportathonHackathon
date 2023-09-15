export interface GetByIdPaymentRequestResponse {
  transportRequestId: string;
  isPaid: boolean;
  price: number;
  createdDate: Date;
  updatedDate: Date;
}
