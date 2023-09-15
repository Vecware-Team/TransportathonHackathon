export interface ApproveTransportRequestResponse {
  id: string;
  customerFirstName: string;
  transportTypeId: string;
  transportType: string;
  customerLastName: string;
  companyName: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  isOfficce: boolean;
  placeSize: string;
  approvedByCompany: boolean;
  createdDate: Date;
  updatedDate: Date;
  startDate: Date;
  finishDate: Date | null;
}
