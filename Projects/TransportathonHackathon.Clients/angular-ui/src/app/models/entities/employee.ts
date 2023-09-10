import { Carrier } from "./carrier";
import { Driver } from "./driver";
import { Company } from "./company";
import { AppUser } from "./appUser";
import { BaseEntity } from "src/app/core/models/entities/entity";

export interface Employee extends BaseEntity{
    appUserId: string;
    companyId: string;
    firstName: string;
    lastName: string;
    age: number;
    isOnTransitNow: boolean;
    carrier: Carrier | null;
    driver: Driver | null;
    company: Company;
    appUser: AppUser;
}