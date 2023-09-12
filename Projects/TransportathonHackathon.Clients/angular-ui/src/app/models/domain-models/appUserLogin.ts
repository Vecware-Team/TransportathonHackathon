import { Entity } from "../../core/models/entity";

export interface AppUserLogin extends Entity<string> {
  loginProvider: string;
  providerKey: string;
  providerDisplayName: string | null;
}
