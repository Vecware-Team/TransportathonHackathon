import { BaseEntity, Entity } from 'src/app/core/models/entities/entity';
import { Employee } from './employee';

export interface Carrier extends BaseEntity {
  employeeId: string;
  employee: Employee;
}
