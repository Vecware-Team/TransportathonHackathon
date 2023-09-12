import { Entity } from "../core/models/entity";

export interface AppUserRole extends Entity<string> {
  userId: string;
  roleId: string;
}
