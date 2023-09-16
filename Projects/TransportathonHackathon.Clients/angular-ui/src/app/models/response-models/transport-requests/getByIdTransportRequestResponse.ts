export interface GetByIdTransportRequestResponse {
  id: string;
  transportTypeId: string;
  transportType: string;
  customerFirstName: string;
  customerLastName: string;
  companyName: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  isFinished: boolean;
  placeSize: string;
  createdDate: Date;
  updatedDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
