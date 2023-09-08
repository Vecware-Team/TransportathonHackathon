import { UserClaim } from '../entities/userClaim';
import { User } from '../entities/user';

export interface UserOperationClaimDetailsDto {
  userOperationClaimId: number;
  user: User;
  userClaim: UserClaim;
}
