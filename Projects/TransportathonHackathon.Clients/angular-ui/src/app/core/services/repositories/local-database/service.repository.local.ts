import { Observable } from 'rxjs';
import { ListResponseModel } from '../../models/responseModels/ListResponseModel';
import { ResponseModel } from '../../models/responseModels/responseModel';

export interface ServiceRepositoryLocal<T> {
  add(entity: T): ResponseModel;
  delete(entity: T): ResponseModel;
  getAll(): ListResponseModel<T>;
  update(entity: T): ResponseModel;
}
