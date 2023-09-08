import { Observable } from 'rxjs';
import { ItemResponseModel } from '../../models/responseModels/ItemResponseModel';
import { ListResponseModel } from '../../models/responseModels/ListResponseModel';
import { ResponseModel } from '../../models/responseModels/responseModel';

export interface ServiceRepository<T> {
  apiUrl: string;
  add(entity: T): Observable<ResponseModel>;
  delete(entity: T): Observable<ResponseModel>;
  getAll(): Observable<ListResponseModel<T>>;
  getById(id: number): Observable<ItemResponseModel<T>>;
  update(entity: T): Observable<ResponseModel>;
}
