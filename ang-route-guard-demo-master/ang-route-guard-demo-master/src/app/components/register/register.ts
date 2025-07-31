import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Registermodel } from '../models/registermodel';
import { Userservice } from '../services/userservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  imports: [FormsModule, HttpClientModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
o:Registermodel=new Registermodel();
client= inject(HttpClient);
rs=inject(Userservice)
  saveHandler() {
    console.log('Registering user:', this.o.userName, this.o.email);
    this.client.post<Register>('http://localhost:5270/api/users',this.o)
      .subscribe((data)=>{
        alert('one data added')
      });
    }
    constructor(private router: Router){}
  navigateToLogin() {
    this.router.navigate(['/login']);
  }
}


 // this.rs.addRegister(this.o)
// o:Registermodel = new Registermodel();
// client = inject(Registermodel);
 // Implement registration logic here
    // console.log('Registering user:', this.username, this.email);
    // alert('register')
    // You might want to call a service to handle the registration