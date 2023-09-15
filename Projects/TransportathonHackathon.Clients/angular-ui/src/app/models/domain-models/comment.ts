import { BaseEntity } from 'src/app/core/models/entity';
import { TransportRequest } from './transportRequest';

export interface Comment extends BaseEntity {
  transportRequestId: string;
  title: string;
  description: string | null;
  point: number;
  transportRequest: TransportRequest;
}
