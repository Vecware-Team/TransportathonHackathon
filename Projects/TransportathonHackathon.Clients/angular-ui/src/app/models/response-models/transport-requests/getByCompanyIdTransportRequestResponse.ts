export interface GetByCompanyIdTransportRequestResponse {
  id: string;
  customerFirstName: string;
  customerLastName: string;
  companyName: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  isOfficce: boolean;
  placeSize: string;
  createdDate: Date;
  updatedDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
