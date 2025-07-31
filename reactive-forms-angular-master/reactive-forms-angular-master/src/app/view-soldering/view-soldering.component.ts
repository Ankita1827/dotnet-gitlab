import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { OrderstagesService } from '../services/orderstages.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-view-soldering',
  standalone: true,
  imports: [ReactiveFormsModule,DatePipe],
  templateUrl: './view-soldering.component.html',
  styleUrl: './view-soldering.component.css'
})
export class ViewSolderingComponent implements OnInit {
  orderdata: any;
  constructor(private readonly orderStagesService: OrderstagesService)  {}

  ngOnInit():void
    {
    // Initialization logic can go here
    this.orderStagesService.getOrderProcessData().subscribe(
      (data) => {
        this.orderdata = data;
       // console.log('from component: ' + JSON.stringify(this.orderdata));
      });
    
  }
  startSoldering() {
    // Handle form submission logic here
    alert('Form submitted');
  }
}
