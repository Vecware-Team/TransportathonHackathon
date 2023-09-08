import { ItemResponseModel } from '../models/responseModels/ItemResponseModel';
import { ListResponseModel } from '../models/responseModels/ListResponseModel';
import { ResponseModel } from '../models/responseModels/responseModel';

export interface DbServiceRepository<T> {
  data:T[];
  add(entity: T): ResponseModel;
  delete(entity: T): ResponseModel;
  getAll(): ListResponseModel<T>;
  update(entity: T): ResponseModel;
}
