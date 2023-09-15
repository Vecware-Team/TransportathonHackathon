export interface FinishedTransportRequestResponse {
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
  approvedByCompany: boolean;
  isFinished: boolean;
  createdDate: Date;
  updatedDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
