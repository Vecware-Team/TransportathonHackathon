import { Entity } from 'src/app/core/models/entities/entity';

export interface AppUserRole extends Entity<string> {
  userId: string;
  roleId: string;
}
