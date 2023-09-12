import { BaseEntity } from '../../core/models/entity';
import { Driver } from './driver';

export interface DriverLicense extends BaseEntity {
  driverId: string;
  firstName: string;
  lastName: string;
  classes: string;
  isNew: boolean;
  licenseGetDate: string;
  driver: Driver;
}
