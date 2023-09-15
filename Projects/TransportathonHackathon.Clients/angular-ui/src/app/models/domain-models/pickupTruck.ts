import { BaseEntity } from 'src/app/core/models/entity';
import { Vehicle } from './vehicle';

export interface PickupTruck extends BaseEntity {
  vehicleId: string;
  size: number;
  vehicle: Vehicle;
}
