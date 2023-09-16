import { PaymentRequest } from '../../domain-models/paymentRequest';

export interface GetByCompanyAndCustomerTransportRequestResponse {
  id: string;
  transportTypeId: string;
  transportType: string;
  isPaid: boolean;
  customerFirstName: string;
  customerLastName: string;
  companyName: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  placeSize: string;
  approvedByCompany: boolean | null;
  isFinished: boolean;
  paymentRequest: PaymentRequest;
  createdDate: Date;
  updatedDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
