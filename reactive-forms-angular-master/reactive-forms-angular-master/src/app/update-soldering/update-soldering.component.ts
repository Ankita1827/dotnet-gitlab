import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-update-soldering',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './update-soldering.component.html',
  styleUrl: './update-soldering.component.css'
})
export class UpdateSolderingComponent {
constructor(public builder:FormBuilder) {
    // Initialization logic can go here
    this.builder.group({
      // Define your form controls here
      orderId: [''],
      status: [''],
      remarks: ['dfdfdf'],
      image: ['fdfdf'],
      startDate: ['2025-07-24T07:41:01.0866667'],
      endDate: ['2025-07-24T07:41:01.0866667'],
      empId: [1]
    });
  }
}
