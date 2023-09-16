import { Car } from '../../domain-models/car';
import { Driver } from '../../domain-models/driver';
import { PickupTruck } from '../../domain-models/pickupTruck';
import { Truck } from '../../domain-models/truck';

export interface GetByCompanyIdVehicleResponse {
  id: string;
  companyId: string;
  driverId: string;
<<<<<<< Updated upstream
  brand: string;
  model: string;
  modelYear: number;
  createdDate: string;
  updatedDate: string | null;
  deletedDate: string | null;
=======
  createdDate: string;
  updatedDate: string | null;
  deletedDate: string | null;
  brand: string;
  model: string;
  modelYear: number;
>>>>>>> Stashed changes
  driver: Driver | null;
  car: Car | null;
  truck: Truck | null;
  pickupTruck: PickupTruck | null;
}
