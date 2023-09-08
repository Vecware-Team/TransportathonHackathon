import { OperationClaim } from '../entities/operationClaim';
import { User } from '../entities/user';

export interface UserOperationClaimDetailsDto {
  userOperationClaimId: number;
  user: User;
  operationClaim: OperationClaim;
}
