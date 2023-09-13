import { Employee } from '../../domain-models/employee';

export interface GetListDynamicCompanyResponse {
  appUserId: string;
  email: string;
  userName: string;
  companyName: string;
  driverCount: number;
  completedJobsCount: number;
  employees: Employee[] | null;
}
