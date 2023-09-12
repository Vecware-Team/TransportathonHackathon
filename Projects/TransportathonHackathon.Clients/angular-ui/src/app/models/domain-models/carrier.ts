import { BaseEntity } from '../../core/models/entity';
import { Employee } from './employee';

export interface Carrier extends BaseEntity {
  employeeId: string;
  employee: Employee;
}
