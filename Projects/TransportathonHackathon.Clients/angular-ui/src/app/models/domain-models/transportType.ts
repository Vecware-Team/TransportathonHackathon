import { Entity } from 'src/app/core/models/entity';
import { TransportRequest } from './transportRequest';

export interface TransportType extends Entity<string> {
  type: string;
  transportRequests: TransportRequest[] | null;
}
