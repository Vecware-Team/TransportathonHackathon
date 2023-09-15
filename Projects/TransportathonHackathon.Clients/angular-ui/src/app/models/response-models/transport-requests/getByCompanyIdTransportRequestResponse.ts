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
  approverByCompany: boolean;
  createdDate: Date;
  updatedDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
