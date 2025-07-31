import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Order } from '../models/order';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-child',
  imports: [FormsModule],
  templateUrl: './child.html',
  styleUrl: './child.css'
})
export class Child {
@Input() order:Order=new Order();
@Output() nameChanged = new EventEmitter<string>();
color:string=''
sendHandler(){
  this.nameChanged.emit(this.color)
}
}
