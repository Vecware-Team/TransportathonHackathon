import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Translate } from '../models/entities/translate';
import { User } from '../models/entities/user';
import { ServiceRepositoryBase } from '../core/services/repositories/service.repository.base';

@Injectable({
  providedIn: 'root',
})
export class UserService extends ServiceRepositoryBase<User> {
  override apiUrl = environment.apiUrl + 'users/';
  constructor(protected override httpClient: HttpClient) {
    super('users', httpClient);
  }
}
