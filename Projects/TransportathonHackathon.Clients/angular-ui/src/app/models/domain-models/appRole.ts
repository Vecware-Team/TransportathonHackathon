import { Entity } from "../../core/models/entity";

export interface AppRole extends Entity<string> {
  name: string | null;
  normalizedName: string | null;
  concurrencyStamp: string | null;
}
