import { Entity } from 'src/app/core/models/entities/entity';

export interface AppRoleClaim extends Entity<string> {
  roleId: string;
  claimType: string | null;
  claimValue: string | null;
}
