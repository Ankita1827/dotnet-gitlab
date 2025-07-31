import { Component } from '@angular/core';
import { Route, Router, RouterLink } from '@angular/router';
import { Login } from '../login/login';
import { Register } from '../register/register';
import { NewVenue } from '../new-venue/new-venue';
import { ShowVenue } from '../show-venue/show-venue';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css'
})
export class Navbar {
  lc = localStorage
  constructor(private router: Router){}
  navigateToHome() {
    this.router.navigate(['/home']);
  }
  navigateToLogin() {
    this.router.navigate(['/login']);
  }
  navigateToRegister() {
    this.router.navigate(['/register']);
  }
  navigateToShowDetails() {
    this.router.navigate(['/show-details']);
  }
  navigateToAbout(){
    this.router.navigate(['/about']);
  }
  logouthandler(){
    localStorage.setItem('username','')
    localStorage.setItem('status','notloggedin')
  }
}
