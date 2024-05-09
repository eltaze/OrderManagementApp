import { Injectable } from '@angular/core';
import { Stcok } from '../Models/Stock';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StcokOrders } from '../Models/StockOrders';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  

  constructor(private http: HttpClient) { }
  public getStcokOrders() : Observable<StcokOrders[]>
  {
   return this.http.get<StcokOrders[]>(environment.apiurl);
  }
}
