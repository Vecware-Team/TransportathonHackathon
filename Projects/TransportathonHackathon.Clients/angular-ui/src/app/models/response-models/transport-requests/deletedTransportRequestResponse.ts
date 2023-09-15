export interface DeletedTransportRequestResponse {
  id: string;
  customerFirstName: string;
  customerLastName: string;
  companyName: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  placeSize: string;
  createdDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
