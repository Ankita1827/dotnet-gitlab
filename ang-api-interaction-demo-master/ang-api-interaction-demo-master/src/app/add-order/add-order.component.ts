import { Component, inject } from '@angular/core';
import { Order } from '../models/order';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-order',
  standalone: true,
  imports: [HttpClientModule,FormsModule],
  templateUrl: './add-order.component.html',
  styleUrl: './add-order.component.css'
})
export class AddOrderComponent {
order:Order = new Order();
 client = inject(HttpClient)

saveHandler(){
  //alert(JSON.stringify(this.order))
  this.client.post<Order>('https://wheelfactoryorderapi.azurewebsites.net/api/order',this.order)
  .subscribe(
    {
      next:(data)=>{alert('saved one order')},
      error:(error)=>{alert('Problem'+JSON.stringify(error))}})
 }
}
