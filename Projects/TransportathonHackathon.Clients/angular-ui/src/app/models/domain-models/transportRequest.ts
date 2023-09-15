import { Customer } from './customer';
import { Company } from './company';
import { TransportType } from './transportType';
import { Entity } from 'src/app/core/models/entity';
import { Comment } from './comment';

export interface TransportRequest extends Entity<string> {
  customerId: string;
  companyId: string;
  transportTypeId: string;
  countryFrom: string;
  countryTo: string;
  cityFrom: string;
  cityTo: string;
  placeSize: string;
  approvedByCompany: boolean;
  startDate: string;
  finishDate: string | null;
  customer: Customer;
  company: Company;
  transportType: TransportType;
  comment: Comment | null;
}
