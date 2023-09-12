import { Entity } from "../core/models/entity";

export interface AppRoleClaim extends Entity<string> {
  roleId: string;
  claimType: string | null;
  claimValue: string | null;
}
