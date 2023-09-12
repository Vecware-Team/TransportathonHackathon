import { Entity } from "../core/models/entity";

export interface AppUserToken extends Entity<string> {
  userId: string;
  loginProvider: string;
  name: string;
}