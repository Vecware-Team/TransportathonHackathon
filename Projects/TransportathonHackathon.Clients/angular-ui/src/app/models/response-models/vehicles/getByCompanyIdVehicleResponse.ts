import { Car } from "../../domain-models/car";
import { Driver } from "../../domain-models/driver";
import { PickupTruck } from "../../domain-models/pickupTruck";
import { Truck } from "../../domain-models/truck";


export interface GetByCompanyIdVehicleResponse {
    id: string;
    companyId: string;
    driverId: string;
    createdDate: string;
    updatedDate: string | null;
    deletedDate: string | null;
    driver: Driver | null;
    car: Car | null;
    truck: Truck | null;
    pickupTruck: PickupTruck | null;
}