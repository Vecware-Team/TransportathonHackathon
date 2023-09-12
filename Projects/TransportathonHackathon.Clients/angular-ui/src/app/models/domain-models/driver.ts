import { BaseEntity } from '../../core/models/entity';
import { DriverLicense } from './driverLicense';
import { Employee } from './employee';

export interface Driver extends BaseEntity {
  employeeId: string;
  driverLicense: DriverLicense | null;
  employee: Employee;
}
