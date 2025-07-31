import { Component, inject, OnInit } from '@angular/core';
import { Venueservices } from '../services/venueservices';
import { Router } from '@angular/router';
import { Venue } from '../models/venue';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home implements OnInit {
  venue: Array<Venue> = [];
  private os = inject(Venueservices);
  private router = inject(Router);
  venueid! : string;

  ngOnInit() {
    this.loadVenues();
  }

  loadVenues() {
    this.os.getVenues().subscribe({
      next: (data) => {
        this.venue = data;
        this.venueid = this.venue[0].id!; // Assuming you want the first venue's ID
        console.log('Loaded venues:', this.venue[0].id);
      },
      error: (error) => {
       // this.toastr.error('Failed to load venues: ' + error.message, 'Error');
        console.error('Load venues error:', error);
      }
    });
  }

  // editVenue(id: string | undefined) {
  //   alert(id)
  //   if (id) {
  //     this.router.navigate(['/edit-venue', id]);
  //   }
  // }

  // deleteVenue(id: string) {
  //   if (confirm('Are you sure you want to delete this venue?')) {
  //     this.os.deleteVenue(id).subscribe({
  //       next: () => {
  //       //  this.toastr.success('Venue deleted successfully', 'Success');
  //         this.loadVenues(); // refresh the list from backend after delete
  //       },
  //       error: (err) => {
  //       //  this.toastr.error('Failed to delete venue: ' + err.message, 'Error');
  //         console.error('Delete error:', err);
  //       }
  //     });
  //   }
  // }
  
  userBooking(id:string|undefined){  
    alert(id)
    this.router.navigate(['/user-booking',id])
  }
}
