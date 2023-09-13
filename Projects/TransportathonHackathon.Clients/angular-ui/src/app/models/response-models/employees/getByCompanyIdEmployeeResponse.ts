import { Carrier } from '../../domain-models/carrier';
import { Driver } from '../../domain-models/driver';

export interface GetByCompanyIdEmployeeResponse {
  appUserId: string;
  companyId: string;
  firstName: string;
  lastName: string;
  age: number;
  isOnTransitNow: boolean;
  carrier: Carrier | null;
  driver: Driver | null;
}
