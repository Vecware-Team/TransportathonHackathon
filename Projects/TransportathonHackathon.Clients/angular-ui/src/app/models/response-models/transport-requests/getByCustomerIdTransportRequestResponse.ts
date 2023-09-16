import { PaymentRequest } from '../../domain-models/paymentRequest';

export interface GetByCustomerIdTransportRequestResponse {
  id: string;
  customerFirstName: string;
  customerLastName: string;
  transportTypeId: string;
  transportType: string;
  companyId: string;
  companyName: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  approvedByCompany: boolean | null;
  isFinished: boolean;
  isPaid: boolean;
  placeSize: string;
  paymentRequest: PaymentRequest;
  createdDate: Date;
  updatedDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
