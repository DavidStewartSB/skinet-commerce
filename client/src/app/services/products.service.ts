import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  
  url = "http://localhost:5005";
  
  constructor(private http: HttpClient) { }

  GetProducts(): Observable<IProduct[]> {
    return this.http.get<IProduct[]>(`${this.url}/api/products`);
  }

  GetProductId() {

  }
}
