import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { TokenService } from '../services/token.service';
import { RouterService } from '../services/router.service';

export const loginGuard: CanActivateFn = (route, state) => {
  let tokenService = inject(TokenService);
  let routerService = inject(RouterService);

  let user = tokenService.getUserWithJWT();
  if (user != null && user?.id != null && user?.email != null) return true;

  routerService.loginRoute();
  return false;
};
