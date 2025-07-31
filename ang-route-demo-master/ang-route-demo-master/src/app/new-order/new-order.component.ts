import { Component } from '@angular/core';
import { Order } from '../models/order';
import{FormsModule} from '@angular/forms'
@Component({
  selector: 'app-new-order',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './new-order.component.html',
  styleUrl: './new-order.component.css'
})
export class NewOrderComponent {
o:Order = new Order();
constructor(){
   
}
submitHandler(){
    alert(JSON.stringify(this.o))

}
inputHandler(e:any){

}
}
