import { Employee } from './employee';
import { AppUser } from './appUser';
import { BaseEntity } from 'src/app/core/models/entities/entity';

export interface Company extends BaseEntity {
  appUserId: string;
  companyName: string;
  driverCount: number;
  completedJobsCount: number;
  employees: Employee[] | null;
  appUser: AppUser;
}
