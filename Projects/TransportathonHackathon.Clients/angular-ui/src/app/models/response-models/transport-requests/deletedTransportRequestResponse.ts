export interface DeletedTransportRequestResponse {
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
  placeSize: string;
  approverByCompany: boolean;
  createdDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
