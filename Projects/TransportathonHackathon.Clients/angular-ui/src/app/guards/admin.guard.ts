import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { TokenService } from '../services/token.service';

export const adminGuard: CanActivateFn = (route, state) => {
  let tokenService = inject(TokenService);

  let user = tokenService.getUserWithJWT();
  if (user != null && user?.id != null && user?.email != null && user?.userType == "Admin")
    return true;

  return false;
};
