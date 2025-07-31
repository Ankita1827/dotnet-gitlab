import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Order } from '../models/order';

@Injectable({
  //ensures that only one instance of the service created durinng application lifetime
  providedIn: 'root', 
})
export class Orderservice {
    client = inject(HttpClient)
    orders:Array<Order> = []
   
  constructor(){
      this.client.get<Array<Order>>('https://wheelfactoryorderapi-hvgzhwgudzhdfhd0.canadacentral-01.azurewebsites.net/api/order')
      .subscribe((data)=>{
      this.orders = data;
     })
  }
  getOrders():Array<Order>
    {
      return this.orders;
    }
  addOrder(o:Order){
    this.client.post<Order>('https://wheelfactoryorderapi-hvgzhwgudzhdfhd0.canadacentral-01.azurewebsites.net/api/order',o)
    .subscribe({
                next:(data)=>{
                  alert('one order aded');
                this.orders.push(o)},
                error:(error)=>{alert(JSON.stringify(error))}
              })
  }
  modifyOrder(id:number,o:Order){
    this.client.put(`http://localhost:5432/api/order/${id}`,o)
  }
  getOrderById(id:number):Order |undefined{
    return this.orders.find((o)=>o.id==id)
  }
}
