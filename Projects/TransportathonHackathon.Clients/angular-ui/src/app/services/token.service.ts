import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { storageTypes } from '../constants/storageTypes';
import { User } from '../models/entities/user';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  private jwtHelperService: JwtHelperService = new JwtHelperService();
  private tokenString: string = 'token';

  constructor(private localStorageService: LocalStorageService) {}

  decode(token: string) {
    return this.jwtHelperService.decodeToken(token);
  }

  get(): string | null {
    let token: string = this.localStorageService.getItem(this.tokenString)!;
    if (token == null) {
      token = sessionStorage.getItem(this.tokenString)!;
      if (token == null) {
        return null;
      }
    }

    return token;
  }

  getStorageType(): string {
    // if (this.cookieService.get(this.tokenString) !== null) {
    //   return storageTypes.cookie;
    // }
    if (this.localStorageService.getItem(this.tokenString) !== null) {
      return storageTypes.localStorage;
    } else if (sessionStorage.getItem(this.tokenString) !== null) {
      return storageTypes.sessionStorage;
    } else {
      return '';
    }
  }

  // setCookie(token: string): void {
  //   this.cookieService.put(this.tokenString, token);
  // }

  setLocal(token: string): void {
    this.localStorageService.setItem(this.tokenString, token);
  }

  setSession(token: string): void {
    sessionStorage.setItem(this.tokenString, token);
  }

  remove(): void {
    localStorage.removeItem(this.tokenString);
    sessionStorage.removeItem(this.tokenString);
    // this.cookieService.remove(this.tokenString);
  }

  isExpired(token: string): boolean {
    let isExpired = this.jwtHelperService.isTokenExpired(this.get()!);

    return isExpired;
  }

  getExpirationDate(): Date {
    let result = this.jwtHelperService.getTokenExpirationDate(this.get()!);
    if (result == null) {
      return new Date('0000-00-0T00:00:00');
    }
    return result;
  }

  getUserRolesWithJWT(): string[] {
    let token = this.decode(this.get()!);

    if (token != null) {
      let roles =
        token[Object.keys(token).filter((r) => r.endsWith('/role'))[0]];

      if (!Array.isArray(roles)) {
        let array = new Array();
        array.push(roles);

        return array;
      }

      return roles;
    }

    return [];
  }

  getUserWithJWT(): User {
    let token = this.decode(this.get()!);

    if (token != null) {
      let userModel: User = {
        id: +token[
          Object.keys(token).filter((t) => t.endsWith('nameidentifier'))[0]
        ],
        email: token.email,
        firstName:
          token[Object.keys(token).filter((t) => t.endsWith('name'))[0]],
        lastName:
          token[Object.keys(token).filter((t) => t.endsWith('lastname'))[0]],
        status: Boolean(token.status),
      };

      return userModel;
    }

    return {} as User;
  }
}
