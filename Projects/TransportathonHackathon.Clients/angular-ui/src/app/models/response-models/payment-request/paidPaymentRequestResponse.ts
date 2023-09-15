export interface PaidPaymentRequestResponse {
  transportRequestId: string;
  isPaid: boolean;
  price: number;
  createdDate: Date;
  updatedDate: DataViewConstructor;
}
