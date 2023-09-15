export interface UpdateTransportRequestRequest {
  id: string;
  customerId: string;
  companyId: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  placeSize: string;
  startDate: Date;
  finishDate: Date | null;
}
