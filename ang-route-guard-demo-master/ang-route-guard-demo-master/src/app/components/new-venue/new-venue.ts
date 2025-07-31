import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Venue } from '../models/venue';
import { Venueservices } from '../services/venueservices';
 
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-venue',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './new-venue.html',
  styleUrl: './new-venue.css'
})
export class NewVenue {
  ns = inject(Venueservices);
 
  private router = inject(Router);

  v = {
    name: '',
    description: '',
    address: '',
    city: '',
    capacity: 0,
    amenitiesInput: '',
    imageUrlsInput: ''
  };

  saveHandler() {
    const venueToSave: Venue = {
      name: this.v.name,
      description: this.v.description,
      address: this.v.address,
      city: this.v.city,
      capacity: this.v.capacity,
      amenities: this.v.amenitiesInput.split(',').map(a => a.trim()),
      images: this.v.imageUrlsInput.split(',').map(url => url.trim())
    };

    this.ns.addVenue(venueToSave).subscribe({
      next: () => {
         

        // Optional: Navigate to show-venue page
        this.router.navigate(['/show-venue']);

        // Optional: Reset the form fields
        this.v = {
          name: '',
          description: '',
          address: '',
          city: '',
          capacity: 0,
          amenitiesInput: '',
          imageUrlsInput: ''
        };
      },
      error: (error) => {
     
        console.error('Add venue error:', error);
      }
    });
  }
}
