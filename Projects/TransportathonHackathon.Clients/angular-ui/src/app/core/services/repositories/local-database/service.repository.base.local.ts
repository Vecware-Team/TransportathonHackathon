import { DbServiceRepositoryBase } from '../../database/db.service.repository.base';
import { ServiceRepositoryLocal } from './service.repository.local';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ItemResponseModel } from '../../models/responseModels/ItemResponseModel';
import { ListResponseModel } from '../../models/responseModels/ListResponseModel';
import { ResponseModel } from '../../models/responseModels/responseModel';
import { ServiceRepository } from '../service.repository';

export class ServiceRepositoryLocalBase<T>
  implements ServiceRepositoryLocal<T>
{
  constructor(protected dbService: DbServiceRepositoryBase<T>) {}

  add(entity: T): ResponseModel {
    return this.dbService.add(entity);
  }
  delete(entity: T): ResponseModel {
    return this.dbService.delete(entity);
  }
  getAll(): ListResponseModel<T> {
    return this.dbService.getAll();
  }

  update(entity: T): ResponseModel {
    return this.dbService.update(entity);
  }
}
