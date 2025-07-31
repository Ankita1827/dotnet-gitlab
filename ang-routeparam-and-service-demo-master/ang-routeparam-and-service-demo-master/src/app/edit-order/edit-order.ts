import { Component, inject} from '@angular/core';
import { Order } from '../models/order';
import { ActivatedRoute } from '@angular/router';
import { Orderservice } from '../services/orderservice';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-order',
  imports: [FormsModule],
  templateUrl: './edit-order.html',
  styleUrl: './edit-order.css'
})
export class EditOrder {
o:Order = new Order()
id:number=0;
os = inject(Orderservice)
constructor(private ar:ActivatedRoute){
  this.ar.params.subscribe((p)=>{
        this.id = p['id']
        this.o = this.os.getOrderById(this.id) ?? new Order();
      })
}
 cancelHandler(){
  
   }
   saveHandler(id:number){
 
   }
}
