import { Entity } from "../../core/models/entity";

export interface AppUserClaim extends Entity<string>{
    userId: string;
    claimType: string | null;
    claimValue: string | null;
}