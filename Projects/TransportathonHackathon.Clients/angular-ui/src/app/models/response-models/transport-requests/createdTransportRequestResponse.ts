export interface CreatedTransportRequestResponse {
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
  startDate: Date;
  finishDate: Date | null;
}

