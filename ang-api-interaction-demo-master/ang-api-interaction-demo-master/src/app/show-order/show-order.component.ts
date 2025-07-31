import { HttpClientModule ,HttpClient} from '@angular/common/http';
import { Component } from '@angular/core';
import { Order } from '../models/order';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-show-order',
  standalone: true,
  imports: [FormsModule,HttpClientModule,],
  templateUrl: './show-order.component.html',
  styleUrl: './show-order.component.css'
})
export class ShowOrderComponent {
  orders: Order[] = [];
   names:Array<string> =['india','israel','russia']
  // Inject HttpClient to make HTTP requests
    constructor(private readonly httpClient:HttpClient) {
    this.httpClient.get<Order[]>('https://wheelfactoryorderapi.azurewebsites.net/api/order')
      .subscribe({
        next: (data) => {
          this.orders = data;
        },
        error: (error) => {
          console.error('Error fetching orders:', error);
        }
      });
  }
}
