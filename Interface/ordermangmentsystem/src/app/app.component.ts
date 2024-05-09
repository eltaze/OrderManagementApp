import { Component } from '@angular/core';
import { Stcok } from './Models/Stock';
import { Order } from './Models/Orders';
import { OrdersService } from './Services/orders.service';
import { StcokOrders } from './Models/StockOrders';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'App';
  stcokorders: StcokOrders[] =[];
  readonly APIURL="https://localhost:7124/api/Order";
  constructor(private http:HttpClient){}
  

  ngOnIt():void
  {

    
    console.log("Test new Angular");

   
  }
}
