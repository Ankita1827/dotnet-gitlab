import { Component, inject } from '@angular/core';
import { Order } from '../models/order';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Orderservice } from '../services/orderservice';
import { NewOrder } from '../new-order/new-order';
import { Router, RouterModule, RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-show-order',
  imports: [HttpClientModule,NewOrder,RouterOutlet,RouterModule],
  templateUrl: './show-order.html',
  styleUrl: './show-order.css'
})
export class ShowOrder {
   orders:Array<Order> = []
   os = inject(Orderservice)
   isEdit:boolean = false;
   constructor( private router:Router){
     this.orders = this.os.getOrders();
   }
   editHandler(id:number){
     this.router.navigate(['edit-order',id])
   }
   
}
