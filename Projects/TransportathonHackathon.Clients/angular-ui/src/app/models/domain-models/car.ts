import { BaseEntity } from 'src/app/core/models/entity';
import { Vehicle } from './vehicle';

export interface Car extends BaseEntity {
  vehicleId: string;
  brand: string;
  model: string;
  modelYear: number;
  vehicle: Vehicle;
}
