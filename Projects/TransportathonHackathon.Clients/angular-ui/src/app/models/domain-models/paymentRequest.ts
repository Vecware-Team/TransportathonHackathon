import { BaseEntity } from 'src/app/core/models/entity';
import { TransportRequest } from './transportRequest';

export interface PaymentRequest extends BaseEntity {
  transportRequestId: string;
  isPaid: boolean;
  price: number;
  transportRequest: TransportRequest;
}
