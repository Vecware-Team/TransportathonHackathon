import { PaymentRequest } from '../../domain-models/paymentRequest';
import { Vehicle } from '../../domain-models/vehicle';

export interface GetByCompanyIdTransportRequestResponse {
  id: string;
  customerFirstName: string;
  customerLastName: string;
  transportTypeId: string;
  transportType: string;
  isPaid: boolean;
  companyName: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  placeSize: string;
  approvedByCompany: boolean;
  paymentRequest: PaymentRequest;
  isFinished: boolean;
  vehicle: Vehicle;
  createdDate: Date;
  updatedDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
