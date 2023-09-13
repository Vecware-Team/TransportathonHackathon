import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { StorageService } from './storage.service';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  private jwtHelperService: JwtHelperService = new JwtHelperService();
  private tokenString: string = 'token';

  constructor(private storageService: StorageService) { }

  decodeToken(token: string) {
    return this.jwtHelperService.decodeToken(token);
  }

  getToken(): string | null {
    return this.storageService.getItem(this.tokenString);
  }

  setToken(token: string): void {
    this.storageService.setItem(this.tokenString, token);
  }

  removeToken(): void {
    this.storageService.removeItem(this.tokenString);
  }

  isTokenExpired(): boolean {
    let isExpired = this.jwtHelperService.isTokenExpired(this.getToken());

    return isExpired != null ? isExpired : true;
  }

  getTokenExpirationDate(): Date | null {
    if (this.getToken() == null)
      return null;

    return this.jwtHelperService.getTokenExpirationDate(this.getToken()!);
  }

  getUserRolesWithJWT(): string[] | null {
    if (this.getToken() == null)
      return null;

    let token = this.decodeToken(this.getToken()!);
    let roles = token[Object.keys(token).filter((r) => r.endsWith('/role'))[0]];

    if (Array.isArray(roles))
      return roles;

    let array = [];
    array.push(roles);
    return array;
  }

  getUserWithJWT(): object | null {
    if (this.getToken() == null)
      return null;

    let token = this.jwtHelperService.decodeToken(this.getToken()!);

    let userModel = {
      id: token[Object.keys(token).filter((t) => t.endsWith('nameidentifier'))[0]],
      email: token.email,
      userName: token.userName,
      userType: token.UserType,
      roles: this.getUserRolesWithJWT(),
    };

    return userModel;
  }
}
