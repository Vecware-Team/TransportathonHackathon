import { BaseEntity } from '../../core/models/entity';
import { AppUser } from "./appUser";

export interface Customer extends BaseEntity {
    appUserId: string;
    firstName: string;
    lastName: string;
    appUser: AppUser;
}