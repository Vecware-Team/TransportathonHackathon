import { BaseEntity } from 'src/app/core/models/entity';
import { Vehicle } from './vehicle';

export interface Truck extends BaseEntity {
  vehicleId: string;
  brand: string;
  model: string;
  modelYear: number;
  size: number;
  vehicle: Vehicle;
}
