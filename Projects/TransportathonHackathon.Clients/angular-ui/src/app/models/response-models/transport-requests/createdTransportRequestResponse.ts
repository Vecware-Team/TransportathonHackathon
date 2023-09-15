export interface CreatedTransportRequestResponse {
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
  createdDate: Date;
  approverByCompany: boolean;
  startDate: Date;
  finishDate: Date | null;
}


