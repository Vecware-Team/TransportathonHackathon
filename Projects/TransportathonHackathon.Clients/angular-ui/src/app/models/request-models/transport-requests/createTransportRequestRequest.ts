export interface CreateTransportRequestRequest {
  customerId: string;
  companyId: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  isOfficce: boolean;
  placeSize: string;
  startDate: Date;
  finishDate: Date | null;
}