import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OrderstagesService {
  http= inject(HttpClient)
   
  
  getOrderProcessData() {
    return this.http.get('https://anilbackend.azurewebsites.net/api/orderprocess')
  }
  }
