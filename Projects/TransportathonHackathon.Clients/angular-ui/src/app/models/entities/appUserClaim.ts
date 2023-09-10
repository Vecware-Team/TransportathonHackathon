import { Entity } from "src/app/core/models/entities/entity";

export interface AppUserClaim extends Entity<string>{
    userId: string;
    claimType: string | null;
    claimValue: string | null;
}