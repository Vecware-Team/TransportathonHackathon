import { Entity } from 'src/app/core/models/entities/entity';

export interface AppUserLogin extends Entity<string> {
  loginProvider: string;
  providerKey: string;
  providerDisplayName: string | null;
}
