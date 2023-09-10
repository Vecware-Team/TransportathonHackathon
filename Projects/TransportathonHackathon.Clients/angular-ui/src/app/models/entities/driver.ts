import { BaseEntity } from 'src/app/core/models/entities/entity';
import { DriverLicense } from './driverLicense';
import { Employee } from './employee';

export interface Driver extends BaseEntity {
  employeeId: string;
  driverLicense: DriverLicense | null;
  employee: Employee;
}
