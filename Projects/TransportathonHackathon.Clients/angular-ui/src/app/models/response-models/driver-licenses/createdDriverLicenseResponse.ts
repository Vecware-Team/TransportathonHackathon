import { Driver } from '../../driver';

export interface CreatedDriverLicenseResponse {
  driverId: string;
  firstName: string;
  lastName: string;
  classes: string;
  isNew: boolean;
  licenseGetDate: string;
  driver: Driver;
}
