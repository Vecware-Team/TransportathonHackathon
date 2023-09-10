import { Entity } from "src/app/core/models/entities/entity";

export interface AppRole extends Entity<string> {
  name: string | null;
  normalizedName: string | null;
  concurrencyStamp: string | null;
}
