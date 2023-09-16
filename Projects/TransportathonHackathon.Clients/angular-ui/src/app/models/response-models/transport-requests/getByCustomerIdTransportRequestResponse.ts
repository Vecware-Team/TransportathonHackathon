export interface GetByCustomerIdTransportRequestResponse {
  id: string;
  customerFirstName: string;
  customerLastName: string;
  transportTypeId: string;
  transportType: string;
  companyName: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  approvedByCompany: boolean | null;
  isFinished: boolean;
  placeSize: string;
  createdDate: Date;
  updatedDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
