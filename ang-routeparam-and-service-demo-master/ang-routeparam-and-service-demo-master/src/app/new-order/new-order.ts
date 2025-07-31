import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { Order } from '../models/order';
import { FormsModule } from '@angular/forms';
import { Orderservice } from '../services/orderservice';

@Component({
  selector: 'app-new-order',
  imports: [HttpClientModule,FormsModule],
  templateUrl: './new-order.html',
  styleUrl: './new-order.css'
})
export class NewOrder {
   ns = inject(Orderservice)
    o:Order = new Order();
    saveHandler(){
    this.ns.addOrder(this.o)
  }
}
