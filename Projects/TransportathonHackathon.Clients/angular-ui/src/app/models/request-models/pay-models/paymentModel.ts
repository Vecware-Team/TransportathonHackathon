export interface PaymentRequest {
  cardNumber: string;
  fullName: string;
  month: number;
  year: number;
  cVV: number;
  price: number;
}
