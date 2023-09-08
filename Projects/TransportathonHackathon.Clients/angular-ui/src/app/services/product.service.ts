import { Injectable } from '@angular/core';
import { ServiceRepositoryBase } from '../core/services/repositories/service.repository.base';
import { Product } from '../models/entities/product';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProductService extends ServiceRepositoryBase<Product> {
  override apiUrl = environment.apiUrl + 'products/';
  constructor(protected override httpClient: HttpClient) {
    super('products', httpClient);
  }
}
