import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct, Product } from '../models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  baseUrl!: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl + "api/products/"
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl);
  }

  addProduct(productDto: IProduct): Observable<Product> {
    return this.http.post<Product>(this.baseUrl, {
      name: productDto.name,
      description: productDto.description,
      price: productDto.price,
      itemCode: productDto.itemCode,
      quantityInStock: productDto.quantityInStock
    })
  }
}
