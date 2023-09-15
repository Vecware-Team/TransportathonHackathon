import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { TokenService } from '../services/token.service';
import { RouterService } from '../services/router.service';

export const adminGuard: CanActivateFn = (route, state) => {
  let tokenService = inject(TokenService);
  let routerService = inject(RouterService);

  let user = tokenService.getUserWithJWT();
  let userRoles = tokenService.getUserRolesWithJWT();
  if (
    user != null &&
    user?.id != null &&
    user?.email != null &&
    user?.userType == 'Admin'
  )
    return true;

  if (
    user != null &&
    user?.id != null &&
    user?.email != null &&
    userRoles?.includes('admin')
  ) {
  }

  routerService.homeRoute();
  return false;
};
