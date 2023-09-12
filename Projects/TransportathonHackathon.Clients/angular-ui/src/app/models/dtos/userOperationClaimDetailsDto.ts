import { UserClaim } from '../entities/userClaim';
import { User } from '../entities/appRole';

export interface UserOperationClaimDetailsDto {
  userOperationClaimId: number;
  user: User;
  userClaim: UserClaim;
}
