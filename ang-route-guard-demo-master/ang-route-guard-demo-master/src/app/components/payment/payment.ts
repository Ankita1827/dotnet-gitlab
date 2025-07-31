import { CommonModule } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment',
  imports: [FormsModule,CommonModule],
  templateUrl: './payment.html',
  styleUrl: './payment.css'
})
export class Payment {
  
  rate: number | null = null;
  email: string = '';
  phone: string = '';
  slotNo: number = 0; // ← set this when navigating to payment

  slotNos: number[] = [];
selectedSlots: any[] = [];


  constructor(private route: ActivatedRoute, private router: Router, private http: HttpClient) {
    const nav = this.router.getCurrentNavigation();
    const state = nav?.extras?.state;
  
    if (state) {
      this.rate = state['totalAmount'] || null;
      this.slotNos = state['slotNos'] || [];
      this.selectedSlots = state['selectedSlots'] || [];
      console.log("Received slotNos:", this.slotNos);
    }
    
    this.route.params.subscribe(params => {
      const routeRate = +params['totalAmount'];
      if (!this.rate) this.rate = routeRate || null;
    });
  }
  
  payWithRazorpay() {
    const options: any = {
      key: 'rzp_test_kESBguNp5NhCql',
      amount: (this.rate ?? 0) * 100,
      currency: 'INR',
      name: 'Your Venue Booking',
      description: 'Booking Slot Payment',
      image: 'https://yourdomain.com/logo.png',
      handler: (response: any) => {
        alert('Payment successful!');
      
        const bookingPayload = {
          slotNos: this.slotNos, // list of slot numbers
          customerId: this.email,
          bookingDate: new Date().toISOString()
        };
      
        this.http.put('http://localhost:5160/api/Slot/book-multiple', bookingPayload, {
          headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }).subscribe({
          next: () => alert('All selected slots booked successfully!'),
          error: (err) => alert('Booking failed: ' + err.message)
        });
      },
      prefill: {
        email: this.email,
        contact: this.phone,
      },
      theme: {
        color: '#3399cc'
      }
    };

    const rzp = new (window as any).Razorpay(options);
    rzp.open();
  }
}
  
  

