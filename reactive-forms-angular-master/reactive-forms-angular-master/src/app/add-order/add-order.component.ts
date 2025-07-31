import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-order',
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule],
  templateUrl: './add-order.component.html',
  styleUrl: './add-order.component.css'
})
export class AddOrderComponent {
   model:string=''
   orderForm = new FormGroup({
    model: new FormControl('',[Validators.required,Validators.maxLength(10)]),
    year: new FormControl('',[Validators.required]),
    damageType:new FormControl('',[Validators.required])
  });
  submitHandler(){
    alert(JSON.stringify(this.orderForm.value))
  }
}
