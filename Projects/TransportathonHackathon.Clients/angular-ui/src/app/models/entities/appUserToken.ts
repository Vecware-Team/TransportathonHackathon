import { Entity } from 'src/app/core/models/entities/entity';

export interface AppUserToken extends Entity<string> {
  userId: string;
  loginProvider: string;
  name: string;
}