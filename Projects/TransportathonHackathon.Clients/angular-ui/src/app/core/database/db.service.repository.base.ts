import { ItemResponseModel } from '../models/responseModels/ItemResponseModel';
import { ListResponseModel } from '../models/responseModels/ListResponseModel';
import { ResponseModel } from '../models/responseModels/responseModel';
import { DbServiceRepository } from './db.service.repository';

export class DbServiceRepositoryBase<T> implements DbServiceRepository<T> {
  data: T[] = [];
  constructor() {}

  add(entity: T): ResponseModel {
    this.data.push(entity);
    return {
      success: true,
      message: 'success',
    };
  }
  delete(entity: T): ResponseModel {
    const entityIndex = this.data.findIndex((item) => item === entity);
    this.data.splice(entityIndex, 1);

    return {
      success: true,
      message: 'success',
    };
  }
  getAll(): ListResponseModel<T> {
    return { success: true, message: 'success', data: this.data };
  }

  update(entity: T): ResponseModel {
    const entityIndex = this.data.findIndex((item) => item === entity);
    this.data[entityIndex] = entity;

    return {
      success: true,
      message: 'success',
    };
  }
}
