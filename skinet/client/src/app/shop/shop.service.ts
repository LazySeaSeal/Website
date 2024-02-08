import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brand } from 'app/shared/models/brand';
import { Pagination } from 'app/shared/models/pagination';
import { Product } from 'app/shared/models/product';
import { Type } from 'app/shared/models/type';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl= 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }
  
  getProducts(brandId?:number , typeId?:number){
    let params= new HttpParams();
    if (brandId) params = params.append('brandId',brandId);
    if (typeId) params = params.append('typeId',typeId);
    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products' ,{params});
  }
getBrands() {
  return this.http.get<Brand[]>(this.baseUrl + 'products/brands');
}
getTypes() {
  return this.http.get<Type[]>(this.baseUrl + 'products/types');
}

}
