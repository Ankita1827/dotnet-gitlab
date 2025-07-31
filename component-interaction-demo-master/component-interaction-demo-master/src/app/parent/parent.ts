import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Child } from '../child/child';
import { Order } from '../models/order';

@Component({
  selector: 'app-parent',
  imports: [FormsModule,Child],
  templateUrl: './parent.html',
  styleUrl: './parent.css'
})
export class Parent {
parentdata:string='anil'
o:Order = new Order()
constructor(){
  this.o.id =100;
  this.o.name ="bingo"
}
nameChangeHandler(event:any){
  alert('data changed' +event.value)
}
}
