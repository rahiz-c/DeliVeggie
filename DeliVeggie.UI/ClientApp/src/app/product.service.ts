import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from './interfaces/IProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }


  getItems(){
    return  this.http.get('https://localhost:7213/api/product/list');
  }

  getItemById(id:string):Observable<IProduct>{

    return this.http.get<IProduct>(`https://localhost:7213/api/product/details/${id}`);
    
  }
}
