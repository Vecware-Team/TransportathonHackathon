import { Company } from './company';
import { Driver } from './driver';
import { Car } from './car';
import { Entity } from 'src/app/core/models/entity';
import { Truck } from './truck';
import { PickupTruck } from './pickupTruck';

export interface Vehicle extends Entity<string> {
  companyId: string;
  driverId: string;
  company: Company;
  driver: Driver | null;
  car: Car | null;
  truck: Truck | null;
  pickupTruck: PickupTruck | null;
}
