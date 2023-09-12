import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AppUser } from '../models/appUser';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  private jwtHelperService: JwtHelperService = new JwtHelperService();
  private tokenString: string = 'token';

  constructor() {}

  getUserWithJWT(): AppUser {
    return {} as AppUser;
  }
}
